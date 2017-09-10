import React from 'react';
import ReactDOM from 'react-dom';
import ChatWindow from './ChatWindow.js';

class Lobby extends React.Component {
    constructor(props) {
        super(props);
        var me = this;
        debugger;
        me.state = {
            
        };
    }

    render() {
        return (
            <div>
                <h1>Lobby Name {me.props.name}</h1>
                <h2>Chat</h2>
                <ChatWindow />
            </div>
        );
    }
}

module.exports = Lobby;