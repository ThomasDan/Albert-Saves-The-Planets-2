"use strict";

var connection = new signalR.HubConnectionBuilder().withUrl("/chatHub").build();

//Disable send button until connection is established
//document.getElementById("sendButton").disabled = true;

connection.on("ReceiveMessage", function ( message) {
    //var li = document.createElement("li");
    //document.getElementById("messagesList").appendChild(li);
    // We can assign user-supplied strings to an element's textContent because it
    // is not interpreted as markup. If you're assigning in any other way, you 
    // should be aware of possible script injection concerns.
    //li.textContent = ` says ${temp}`;

    console.log("Script Engaged! " + message);

    let temp = "http://localhost:32258/Planets/" + "Earth"; //message
    location.href = temp;
});

connection.start().then(function () {
    /*document.getElementById("sendButton").disabled = false;*/
//}).catch(function (err) {
//    return console.error(err.toString());

    console.log("bla blab");

});

//document.getElementById("sendButton").addEventListener("click", function (event) {
//    //var user = document.getElementById("userInput").value;
//    var message = document.getElementById("messageInput").value;
//    connection.invoke("SendMessage", message).catch(function (err) {
//        return console.error(err.toString());
//    });
//    event.preventDefault();
//});