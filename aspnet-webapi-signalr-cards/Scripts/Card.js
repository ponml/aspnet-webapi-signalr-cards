import React from 'react';
import ReactDOM from 'react-dom';



//If you don't use something in render(), it shouldn't be in the state.
class Card extends React.Component {
    constructor(props) {
        super(props);
        var me = this;
    }

    componentDidMount() {
    }

    componentWillUnmount() {
    }


    render() {
        if (this.props.data) {
            return (<div> Card "{this.props.data.Name}" has value {this.props.data.Value} and id {this.props.data.Id} </div>);
        } else {
            return (null);
        }
    }
}

module.exports = Card;