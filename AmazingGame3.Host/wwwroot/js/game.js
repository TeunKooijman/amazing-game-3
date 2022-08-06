"use strict";

var connection = new signalR.HubConnectionBuilder().withUrl("/game").build();
var messageInput = document.getElementById("messageInput");
messageInput.disabled = true;

var historicCommands = [];
connection.on("clear", function () {
    $("#console").empty();
});

connection.on("read", function () {
    messageInput.disabled = false;
    messageInput.focus();
})

connection.on("write", function (line) {

    if (line == null || line == "" || line == " " || line == "\n" || line == "\r\n" || line == "\n\r") {
        line = "&nbsp;";
    }
    var lineElement = document.createElement("p");
    lineElement.innerHTML = line;

    document.getElementById("console").appendChild(lineElement);
});

connection.start().then(function () {

})


messageInput.addEventListener("keypress", function (event) {
    if (event.key === "Enter") {
        var typedValue = messageInput.value;
        currentHistoryIndex = -1;
        messageInput.value = "";
        // Trigger the button element with a click
        messageInput.disabled = true;

        historicCommands.push(typedValue);
        var lineElement = document.createElement("p");
        lineElement.innerHTML = typedValue;

        document.getElementById("console").appendChild(lineElement);

        connection.invoke("ReceiveReadLine", typedValue).catch(function (err) {
            alert(err.toString())
            return console.error(err.toString());
        });
        event.preventDefault();
    }
});

var currentHistoryIndex = -1;
messageInput.addEventListener("keydown", function (event) {
    if (event.keyCode === 38) {
        event.preventDefault();

        if (historicCommands.length == 0) {
            return;
        }

        if (currentHistoryIndex == -1) {
            messageInput.value = historicCommands[historicCommands.length - 1];
            currentHistoryIndex = historicCommands.length - 1;
        }
        else if (currentHistoryIndex == 0) {
            return;
        }
        else {
            messageInput.value = historicCommands[currentHistoryIndex - 1];
            currentHistoryIndex = currentHistoryIndex - 1;
        }
    }
    else if (event.keyCode === 40) {
        event.preventDefault();

        if (historicCommands.length == 0) {
            return;
        }

        if (currentHistoryIndex == -1) {
            return
        }
        else if (currentHistoryIndex == historicCommands.length - 1)
        {
            messageInput.value = "";
            currentHistoryIndex = -1;
            return;
        }
        else {
            messageInput.value = historicCommands[currentHistoryIndex + 1];
            currentHistoryIndex = currentHistoryIndex + 1;
        }
    }
});