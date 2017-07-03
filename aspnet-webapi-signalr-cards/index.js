import React from 'react';
import ReactDOM from 'react-dom';
import axios from 'axios';
import Card from './Scripts/Card.js'

var uri = 'api/cards';

//var foundCard = new Card({
//    name: "SOME CARd"
//});

function formatItem(item) {
    return item.Name + ': ' + item.Value;
}

function find() {
    var id = $('#cardId').val();
    return axios.get(uri, { params: { id: id } }).then(function (response) {
        $('#card').text(formatItem(response.data));
    });
}

$(document).ready(function () {
    // Send an AJAX request
    axios.get(uri).then(function (response) {
        // On success, 'data' contains a list of cards.
        var data = response.data;
        data.forEach(function (item) {
            $('<li>', { text: formatItem(item) }).appendTo($('#cards'));
        });
    });

    document.getElementById("find").addEventListener("click", find);

    var chat = $.connection.chatHub;
    // Create a function that the hub can call to broadcast messages.
    chat.client.broadcastMessage = function (name, message) {
        // Html encode display name and message.
        var encodedName = $('<div />').text(name).html();
        var encodedMsg = $('<div />').text(message).html();
        // Add the message to the page.
        $('#discussion').append('<li><strong>' + encodedName
            + '</strong>:&nbsp;&nbsp;' + encodedMsg + '</li>');
    };
    // Get the user name and store it to prepend to messages.
    var dateName = new Date();
    $('#displayname').val(dateName);
    // Set initial focus to message input box.
    $('#message').focus();
    // Start the connection.
    $.connection.hub.start().done(function () {
        $('#sendmessage').click(function () {
            // Call the Send method on the hub.
            chat.server.send($('#displayname').val(), $('#message').val());
            // Clear text box and reset focus for next comment.
            $('#message').val('').focus();
        });
    });


    ReactDOM.render(
        <Card name="test"/>,
        document.getElementById('root')
    );

});