import { useState } from "react";
import moment from "moment/moment";
const SendMessagePlaceholder = (props) => {
  const [message, setMessage] = useState('');
  
  const onMessageSend = () => {
    if (!message) {
      alert('Please type a message!');
    }
    else{
      props.onMessageSend({ 'text': message, 'time':moment().calendar()  });
    }

    setMessage('');
  }

  const onSubmit = (event) => {
    event.preventDefault();
  }

  return (
    <form onSubmit={onSubmit}>

    <div className="flexMessage">
      <div className="flexMessageContent">
      <label htmlFor='message'>Message: </label>
      <input id='message' type='text' onChange={(event) => setMessage(event.target.value)} value={message}></input>
      <button className="buttonSend"  onClick={onMessageSend}><span></span>Send</button>
      </div>
      </div>
    </form>
  );
}

export default SendMessagePlaceholder;