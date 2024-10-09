import React, { useState, useEffect } from 'react';
import { useParams } from 'react-router-dom';
import SockJS from 'sockjs-client';
import Stomp from 'stompjs';
import { v4 as uuidv4 } from 'uuid';
import MatchService from '../../server/matchService';
import UsernamePlaceholder from '../chat/usernamePlaceholder';
import SendMessagePlaceholder from '../chat/sendMessagePlaceHolder';
import ChatMessagesPlaceholder from '../chat/chatMessagePlaceHolder';
import authService from '../../server/authService';
import chat from './chat.css';
const ENDPOINT = "http://localhost:8080/ws";


function Chat(){
    const [stompClient, setStompClient] = useState();
    const [username, setUsername] = useState();
     const [messagesReceived, setMessagesReceived] = useState([]);
     //const [match, setMatch] = useState();
     const {matchId} = useParams();
    const userNameLoggedIn = authService.getCurrentUsername();
    
     /*const getMatchById = async () => {
         const objectMatch = await MatchService.getMatchById(matchId);
         setMatch(objectMatch.data);
        console.log(objectMatch.data);
     }*/



  useEffect(() => {
    //getMatchById();
    // use SockJS as the websocket client
    const socket = SockJS(ENDPOINT);
    // Set stomp to use websockets
    const stompClient = Stomp.over(socket);
    // connect to the backend
    stompClient.connect({}, () => {
      // subscribe to the backend
      stompClient.subscribe('/topic/public-messages', onMessageReceived, (data) => {
      });
    });
    // maintain the client for sending and receiving
    setStompClient(stompClient);
  }, []);


  // send the data using Stomp
  const sendMessage = (newMessage) => {
    
    const payload = { 'id': uuidv4(), 'from': userNameLoggedIn, 'to':""/*can add the person where you want to send to*/, 'text': newMessage.text, 'time': newMessage.time };
    if (payload.to !== "") {
      stompClient.send(`/user/${payload.to}/queue/inboxmessages`, {}, JSON.stringify(payload));
    } else {
      stompClient.send('/message', {}, JSON.stringify(payload));
    }
  };

  // display the received data
  const onMessageReceived = (data) => {
    const message = JSON.parse(data.body);
    setMessagesReceived(messagesReceived => [...messagesReceived, message]);
  };

  const onUsernameInformed = (username) => {
    setUsername(username);
    stompClient.subscribe(`/user/${username}/queue/inboxmessages`, (data) => {
      onMessageReceived(data);
    });
  }

return(
    <section className={chat} >
         <UsernamePlaceholder username={username} onUsernameInformed={onUsernameInformed} />
      <br></br>
      <ChatMessagesPlaceholder username={username} messagesReceived={messagesReceived} />
      <SendMessagePlaceholder username={username} onMessageSend={sendMessage} />

    </section>
)


}
export default Chat;