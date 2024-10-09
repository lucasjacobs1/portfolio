import moment from "moment/moment";

const MessageReceived = (props) => {
    return (

        <div class="container">
            <div className="Text-left">
            <b>{props.from}</b>: {props.text} {props.direct ? <b>(direct)</b> : ''}
            </div>
            <span class="time-right">{props.time}</span>
            
        </div>


    );
};

const ChatMessagesPlaceholder = (props) => {
    return (
        <div className="chatFunction">
            <div className="flexboxChat">
                <div className="flexboxChatContent">
                    <h2>Chat Messages</h2>
                    <h3>{moment().format('MMMM Do YYYY')}</h3>
                    {props.messagesReceived
                        .filter(message => message.from !== props.username)
                        .map(message => <MessageReceived key={message.id} from={message.from} direct={message.to} text={message.text} time={message.time} />)}
                </div>
            </div>
        </div>

    );
}

export default ChatMessagesPlaceholder;