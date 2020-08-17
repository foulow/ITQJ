function requestMessages(projectId, fromId, toId) {
	connection.invoke("GetProjectMessages", projectId, fromId, toId)
		.then(() => {
			chatPlaceholder.hide();
			$(`#count-${toUserId}`).text("");
		})
		.catch(e => {
			error(e);
			showAlert(errorMessages['UserIsDisconnected'], "alert-danger", 5000);
		});
}

function parseMessages(data) {
	userList.empty();
	if (data) {
		connectedUsers = data;
		if (data.length > 0) {
			connectedUsers.forEach(element => {
				var user = createUser({
					userName: element.userName,
					userId: element.id,
					messageCount: element.messageCount
				});
				userList.append(user);
			});
			userPlaceholder.hide();
		} else
			userPlaceholder.show();
	}
}
