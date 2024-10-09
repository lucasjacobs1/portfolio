import React, { useState, useEffect } from "react";
import PotentialUserMatches from "../../server/potentialUserMatchServer";
import NotifyService from "../notification/customNotification";
import PendingUserServer from "../../server/pendingUserMatchServer";
import DeniedUsersService from "../../server/deniedUsersService";
import ConvertService from "../../server/convertService";

function HomeFunctions() {
    const [userCards, setUserCards] = useState([]);
    const first = userCards[0];

    const retrieveUserCards = async () => {
        const objectUserCards = await PotentialUserMatches.getPotentialUserMatchesByReceivedUserId();
        setUserCards(objectUserCards.data.potentialUserMatches);
        //called twice because of strict mode.
        //that is why the makeUserCards is called twice.
        if(objectUserCards.data.potentialUserMatches.length < 1){
            makeUserCards();
            window.location.reload();
        }

    }

    const initialUserState = {
        fromUserId: first?.userReceived.id,
        receivedUserId: first?.userView.id,
    };


    const [user, setUser] = useState(initialUserState);

    const AddPendingUser = () => {
        var data = {
            fromUserId: first?.userReceived.id,
            receivedUserId: first?.userView.id,
        };


        PendingUserServer.create(data)
            .then(response => {
                if (response.status === 201) {
                    setUser({
                        fromUserId: first?.userReceived.id,
                        receivedUserId: first?.userView.id,
                    });
                    window.location.reload();
                    console.log(response.data);
                }
                else {
                    NotifyService.errorMessage();
                    console.log(response.data);
                }


            })
            .catch(e => {
                console.log(e);
                NotifyService.errorMessage();
            });
    };



    const deleteUserCard = (id) => {
        PotentialUserMatches.removePotentialById(id)
            .then(response => {
                console.log(response.data);
                NotifyService.successAlert();
                window.location.reload();

            })
            .catch(e => {
                NotifyService.errorMessage();
            });
    }

    const makeUserCards =  () => {
        const objectUserCards = PotentialUserMatches.MakePotentialUserMatchesMadeForPersonById();
        console.log(objectUserCards);
    }

    const initialDeniedUserState = {
        userId: first?.userReceived.id,
        denied_user_id: first?.userView.id,
    };


    const [denied, setDenied] = useState(initialDeniedUserState);

    const AddDeniedUser = () => {
        var data = {
            userId: first?.userReceived.id,
            deniedUserId: first?.userView.id,
        };


        DeniedUsersService.create(data)
            .then(response => {
                if (response.status === 201) {
                    setDenied({
                        userId: first?.userReceived.id,
                        deniedUserId: first?.userView.id,
                    });
                    window.location.reload();
                    console.log(response.data);
                }
                else {
                    NotifyService.errorMessage();
                    console.log(response.data);
                }


            })
            .catch(e => {
                console.log(e);
                NotifyService.errorMessage();
            });
    };

    


    useEffect(() => {
        retrieveUserCards();
    }, []);

   
  

    return (
        <section className="flexboxeBuddyPicker">
            <div className="InfoFlexBox">
                <div className="InfoFlexBoxImage InfoFlexBoxImage"></div>
                <div className="SizeText">
                    <p>Name: {first?.userView.firstName} {first?.userView.lastName}</p>

                    <p>I'm {ConvertService.getAge(first?.userView.birthday)} years old</p>
                    <p>Born on: {first?.userView.birthday} </p>
                    <p>Gender: {first?.userView.gender} </p>
                    <div className="buttonclass">
                        <button disabled={first === undefined} type="submit" onClick={() => { deleteUserCard(first?.id); AddDeniedUser(); }}  > <span></span> SKIP</button>
                        
                        <button disabled={first === undefined}
                            className="likebutton" onClick={() => { deleteUserCard(first?.id); AddPendingUser(); }} type="submit"> <span></span> LIKE</button>
                    </div>
                </div>
            </div>
        </section>
    )
}

export default HomeFunctions;