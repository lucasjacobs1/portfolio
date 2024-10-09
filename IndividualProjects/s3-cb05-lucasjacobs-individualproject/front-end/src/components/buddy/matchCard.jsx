import { useEffect } from "react";
import authService from "../../server/authService";
import ConvertService from "../../server/convertService";
import Chat from "../chat/chat";
import { useParams, useNavigate } from 'react-router-dom';


function MatchCard(props){
    const user = authService.getUserMatched(props.matchCards);
    console.log(props);
    const Navigate = useNavigate();

    function redirectToChat(event){
        event.preventDefault();
        Navigate("/chat/" + props.matchCards.id);
    }
   
    return(
        <div className="flexboxMatch">
            <div className="flexboxMatchContent">
                <div className="flextboxInfoMatchUser">
                    <div className="flextboxInfoMatchUserContent">
                        <div className="style">Chat with: {user.firstName} {user.lastName}</div>
                        <div className="style">Age: {ConvertService.getAge(user.birthday)}</div>
                    </div>

                    <div className="flextboxInfoMatchChatButtonChoiceContent">
                        
                        <button className="buttonGoToChat" onClick={e => {redirectToChat(e);}}>CHAT</button>
                    </div>
                </div>

            </div>
        </div>
    )
}
export default MatchCard;