function requestMessages(projectId, fromId, toId = null) {
	connection.invoke("GetPostulantsMessages", projectId, fromId)
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
	if (data) {
		connectedUsers = data;
		const messages = connectedUsers.messages;
		if (messages) {
			messageList.empty();
			messages.forEach(element => {
				if (element.fromUserId === userId)
					element.fromUserName = "Me";
				const message = createMessage(element);
				messageList.append(message);
			});
		}
	}
}