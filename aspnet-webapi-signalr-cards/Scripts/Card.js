import React from 'react';
import ReactDOM from 'react-dom';

function Card(options) {
    if (!options) {
        options = {};
    }
    var me = this;


    ReactDOM.render(
        <h1>Hello, Cards!</h1>,
        document.getElementById('card-root')
    );

}

module.exports = Card;