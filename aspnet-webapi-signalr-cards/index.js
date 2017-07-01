import React from 'react';
import ReactDOM from 'react-dom';
import axios from 'axios';
import Card from './Scripts/Card.js'

var uri = 'api/products';
ReactDOM.render(
    <h1>Hello, world!</h1>,
    document.getElementById('root')
);

var card = new Card();

function formatItem(item) {
    return item.Name + ': $' + item.Price;
}

function find() {
    var id = $('#prodId').val();
    $.getJSON(uri + '/' + id)
        .done(function (data) {
            $('#product').text(formatItem(data));
        })
        .fail(function (jqXHR, textStatus, err) {
            $('#product').text('Error: ' + err);
        });
}

$(document).ready(function () {
    // Send an AJAX request
    axios.get(uri).then(function (response) {
        // On success, 'data' contains a list of products.
        var data = response.data;
        data.forEach(function (item) {
            $('<li>', { text: formatItem(item) }).appendTo($('#products'));
        });
    });

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
});