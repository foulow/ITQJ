const connection = new signalR.HubConnectionBuilder()
    .withUrl("/chatHub")
    .configureLogging(signalR.LogLevel.Error)
    //.withAutomaticReconnect([0, 2000, 10000, 30000]) // yields the default behavior
    .withAutomaticReconnect()
    .build(),
  chatButton = $("#fixed-right-chat-button"),
  messageInput = $("#message"),
  sendButton = $("#send"),
  chatContainer = $("#chat-container"),
  chatForm = $("#chat-form"),
  chatPlaceholder = $("#chat-placeholder"),
  userPlaceholder = $("#users-placeholder"),
  userListContainer = $("#user-list"),
  userList = $("#connected-users"),
  messageList = $("#messages-list");

var tryConnectCount = 0,
  isChatVisible = false,
  projectId,
  userId,
  toUserId,
  connectedUsers,
  errorMessages,
  isProfesional;

$(document).ready(async () => {
  connection.on("UpdateConnectedUsers", (data) => {
    updatePostulantsList(data);
  });

  connection.on("UpdateUnreadMessages", (data) => {
    if (data && !isProfesional) {
      var user = connectedUsers.filter((x) => x.userId === data);
      if (toUserId === data || user.length <= 0) return;

      let messageCount = $(`#count-${data}`).text();
      messageCount = messageCount ? ++messageCount : "1";
      $(`#count-${data}`).text(messageCount);

      const audio = id("notification-audio");
      audio.play();
    }
  });

  connection.on("ReceiveConversation", (data) => {
    messageList.empty();
    if (data) {
      data.forEach((element) => {
        if (element.fromUserId === userId) element.fromUserName = "Me";
        const message = createMessage(element);
        messageList.append(message);
      });
    }
  });

  connection.on("ReceiveMessage", (data) => {
    if (data) {
      if (data.fromUserId !== toUserId) return;

      const message = createMessage(data);
      messageList.append(message);
    }
  });

  sendButton.click(sendMessage);

  messageInput.bind("input", updateMessageBox);

  getErrorMessages();

  chatContainer.hide();
  userListContainer.hide();
  loader.hide();
  updateMessageBox();
});

function getErrorMessages() {
  fetch("chat/getErrorMessages", { method: "GET" })
    .then((response) => {
      return response.json();
    })
    .then((data) => {
      errorMessages = data;
    })
    .catch((e) => error(e));
}

function toggleChat() {
  isChatVisible = !isChatVisible;
  if (isChatVisible) {
    chatButton.hide();
    chatContainer.show();
  } else {
    chatButton.show();
    chatContainer.hide();
  }
}

function startChat(id, fromId, name, toId, isProfesional) {
  $("#trigger-button-chat").attr("onclick", "toggleChat()");
  toggleChat();

  projectId = id;
  userId = fromId;
  userName = name;
  toUserId = toId;
  connect(isProfesional);
}

function connect(isProfesional = "False") {
  loader.show();

  connection
    .start()
    .then(() => {
      connection
        .invoke("Connect")
        .then(() => {
          showRoom(isProfesional);
        })
        .catch((e) => {
          error(e);
          showAlert(errorMessages["UserIsConnected"], "alert-danger", 5000);
        });
    })
    .catch((e) => {
      showAlert(e.toString(), "alert-danger", 5000);
    });
}

function showRoom(profesional) {
  debugger;
  isProfesional = profesional;

  if (isProfesional == "True") {
    messageList.append(
      createMessage({
        userName: "sistema",
        messageDate: "",
        text:
          "Envia un mensage para aumentar tus chanses de ser elegido para este proyecto.",
      })
    );

    requestMessages(projectId, userId, toUserId);
    chatPlaceholder.hide();
    messageInput.val("").focus();
  } else {
    userListContainer.show();
    getConnectedUsers();
  }

  loader.hide();
}

function updatePostulantsList(data) {
  userList.empty();
  if (data) {
    connectedUsers = data;
    if (data.length > 0) {
      connectedUsers.forEach((element) => {
        var user = createUser({
          userName: element.userName,
          id: element.id,
          messageCount: element.messageCount,
        });
        userList.append(user);
      });
      userPlaceholder.hide();
    } else userPlaceholder.show();
  }
}

function getConversation(id) {
  if (toUserId === id) return;

  messageList.empty();
  toUserId = id;
  requestMessages(projectId, userId, toUserId);
}

function sendMessage() {
  const message = messageInput.val(),
    messageDetails = {
      projectId: projectId,
      fromUserId: userId,
      toUserId: toUserId,
      userName: userName,
      messageDate: new Date(),
      text: message,
    },
    method = toUserId ? "SendPrivateMessage" : "CacheMessage";

  connection
    .invoke(method, messageDetails)
    .then(() => {
      messageDetails.userName = "Yo";
      const messageBody = createMessage(messageDetails);
      messageList.append(messageBody);
    })
    .catch((e) => {
      error(e);
      showAlert(errorMessages["UserIsDisconnected"], "alert-danger", 5000);
    });

  messageInput.val("").focus();
  updateMessageBox();
}

function requestMessages(projectId, fromId, toId) {
  connection
    .invoke("GetMessages", projectId, fromId, toId)
    .then(() => {
      chatPlaceholder.hide();
      $(`#count-${toUserId}`).text("");
    })
    .catch((e) => {
      error(e);
      showAlert(errorMessages["UserIsDisconnected"], "alert-danger", 5000);
    });
}

function updateMessageBox() {
  const text = messageInput.val(),
    isButtonDisabled = text.length <= 0 && text.length >= 501;

  setCount($("#message-count"), text);
  sendButton.prop("disabled", isButtonDisabled);
}

function getConnectedUsers() {
  connection.invoke("GetPostulants", projectId).catch((e) => {
    error(e);
    showAlert(errorMessages["UnableToGetConnectedUsers"], "alert-danger", 5000);
  });
}

function createMessage(data) {
  let formattedDate = "";
  if (data.messageDate)
    formattedDate = $.format.date(data.messageDate, "dd/MM/yy hh:mm:ss a");

  const message = data.text
      .replace(/&/g, "&amp;")
      .replace(/</g, "&lt;")
      .replace(/>/g, "&gt;"),
    userName = data.userName,
        messageColor =   
      userName === "sistema"
        ? "background-color:#535252"
        : userName === "Yo"
        ? "background-color:#ADADAD"
        : "background-color:#007ACC",
    messageSender = `<p class="mb-0">${userName}</p>`,
    messageDate = `<p class="mb-0">${formattedDate}</p>`,
    messageHeader = `<div class="d-flex justify-content-between">${messageSender}${messageDate}</div>`,
    messageText = `<p class="mb-0">${message}</p>`,
      messageBody = `<div class="text-white p-2 my-2" style="${messageColor}" >${messageHeader}${messageText}</div>`;

  return messageBody;
}

function createUser(data) {
  const userName = data.userName,
    _userId = data.id,
    messageCount = data.messageCount !== 0 ? data.messageCount : "",
    buttonClass =
      'class="list-group-item list-group-item-action d-flex justify-content-between user-item"',
    messageIndicator = `<span class="badge badge-primary badge-pill" id="count-${_userId}">${messageCount}</span>`,
    templateData = `type="button" name="${userName}" id="${_userId}" ${buttonClass}`,
    buttonCommand = `onclick="getConversation(this.id)"`,
    userButton = `<button ${templateData} ${buttonCommand}>${userName} ${messageIndicator}</button>`;

  return userButton;
}

function showPostulationNeed() {
  alert("Postulate, para tener acceso a esta función.");
}
