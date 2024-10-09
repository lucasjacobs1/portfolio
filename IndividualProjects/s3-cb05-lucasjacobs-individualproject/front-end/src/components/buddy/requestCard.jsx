import React, {useState} from "react";
import PendingMatchUser from "../../server/pendingUserMatchServer";
import NotifyService from "../notification/customNotification";
import MatchBuddies from "../../server/matchService";
import ConvertService from "../../server/convertService";
function RequestCard(props){
    const deleteRequest = () => {
            PendingMatchUser.removePendingById(props.requestCards.id)
                .then(response => {
                    console.log(response.data);
                    NotifyService.successAlert();
                    window.location.reload();

                })
                .catch(e => {
                    NotifyService.errorMessage();
                });
        
    }

    function alert(){
        const confirm = window.confirm("Are you sure you want to delete this request? No undoing after removing!");
        if(confirm){
            deleteRequest();
        }
    }

    const createMatch = () => {
        var data = {
            buddy1: props.requestCards.receivedUserId,
            buddy2: props.requestCards.fromUserId,
        };

        console.log(data)

        MatchBuddies.create(data)
            .then(response => {
                if (response.status === 201) {
                    NotifyService.successAlert();
                    window.location.reload();
                }
                else{
                    NotifyService.errorMessage();
                }

                
            })
            .catch(e => {
                console.log(e);
                NotifyService.errorMessage();
            });
    };

    return(
        <div className="flexboxRequest">
            <div className="flexboxRequestContent">
                <div className="flextboxInfoPendingUser">
                    <div className="flextboxInfoPendingUserContent">
                            <div className="style">Hi my name is: {props.requestCards.fromUserId.firstName} {props.requestCards.fromUserId.lastName}</div>
                            <div className="style">Gender: {props.requestCards.fromUserId.gender}</div>
                            <div className="style">I'm {ConvertService.getAge(props.requestCards.fromUserId.birthday)} years old</div>
                            <div className="style">Born on: {props.requestCards.fromUserId.birthday}</div>
                    </div>
                    <div className="flextboxInfoPendingButtonChoiceContent">
                            <button onClick={() => {createMatch(); deleteRequest()}} className="buttonAddPendingMatch">MATCH</button>
                            <button onClick={alert} className="buttonDeletePending">DELETE</button>

                    </div>
                </div>
            </div>
        </div>
    )
}

export default RequestCard;