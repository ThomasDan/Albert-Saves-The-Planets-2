"use strict";

var connection = new signalR.HubConnectionBuilder().withUrl("/chatHub").build();

var dictionary = {
    0: "121164164110", // Mars
    1: "897121989", // Neptune
    2: "16916921689", // Juppiter
    3: "1034590137", // Earth
    4: "16317989137", // pluto
    5: "2021353134", // Mercury
    6: "16914689137", // venus
    7: "5716120143", // Uranus
    8: "9717780195" // Sayt'urn
}

connection.on("ReceiveMessage", function ( message) {
    let readerID = parseInt(message.substring(0, 1));
    let planetID = message.substring(1);
    let planet;
    console.log(readerID + ", " + planetID);

    if (dictionary[readerID] == planetID) {
        // Correct Planet/Reader lineup detected!
        switch (planetID) {
            case 0:
                planet = "Mars";
                break;
            case 1:
                planet = "Neptune";
                break;
            case 2:
                planet = "Jupiter";
                break;
            case 4:
                planet = "Pluto";
                break;
            case 5:
                planet = "Mercury";
                break;
            case 6:
                planet = "Venus";
                break;
            case 7:
                planet = "Uranus";
                break;
            case 8:
                planet = "Saturn";
                break;
            default:
                planet = "Earth";
                break;
        }
        let temp = "http://localhost:32258/Planets/" + planet; //message
        location.href = temp;
    }

    
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
