"use strict"

var connection = new signalR.HubConnectionBuilder().withUrl("/notificationHub").build();
connection.start()
connection.on("ReceiveMessage", (value) => {
    var li = document.createElement("li");
    li.textContent = value;
    document.getElementById("msgList").appendChild(li);
})
