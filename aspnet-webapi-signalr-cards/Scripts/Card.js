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
            var cardFront = "../Images/" + this.props.data.FrontImageFileName;
            return (
                <div>
                    <img src={cardFront}/>
                </div>
            );
        } else {
            return (null);
        }
    }
}

module.exports = Card;