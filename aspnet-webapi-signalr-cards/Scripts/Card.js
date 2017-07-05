import React from 'react';
import ReactDOM from 'react-dom';



//If you don't use something in render(), it shouldn't be in the state.
class Card extends React.Component {
    constructor(props) {
        super(props);
        this.data = props.data;
    }

    componentDidMount() {
    }

    componentWillUnmount() {
    }


    render() {
        return (
            <div>
                <li> {this.data.Name} has value {this.data.Value} and id {this.data.Id} </li>
            </div>
        )
    }
}

module.exports = Card;