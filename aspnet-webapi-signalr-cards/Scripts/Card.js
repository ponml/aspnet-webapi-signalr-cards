import React from 'react';
import ReactDOM from 'react-dom';


//If you don't use something in render(), it shouldn't be in the state.
class Card extends React.Component {
    constructor(props) {
        super(props);
        this.state = { date: new Date() };
        this.id = "-1";
    }

    componentDidMount() {
        this.timerID = setInterval(
            () => this.tick(),
            1000
        );
    }

    componentWillUnmount() {
        clearInterval(this.timerID);
    }

    tick() {
        this.setState({
            date: new Date()
        });
    }

    render() {
        return (
            <div>
                <h1> Hello, {this.props.name} and id is {this.id} </h1>
                <h2>It is {this.state.date.toLocaleTimeString()}.</h2>
            </div>
        )
    }
}

module.exports = Card;