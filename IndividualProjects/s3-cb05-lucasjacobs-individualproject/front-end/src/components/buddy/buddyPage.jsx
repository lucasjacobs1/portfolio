import React, { useEffect, useState } from "react";
import PendingMatchUser from "../../server/pendingUserMatchServer";
import authLogin from "../../server/authService";
import RequestList from "./requestList";
import RequestHeader from "./requestHeader";
import ChatHeader from "./chatHeader";
import MatchBuddies from "../../server/matchService";
import MatchList from "./matchList";
function Buddy(){
    const [requestCards, setRequestCards] = useState([]);
    const[matchCards, setMatchCards] = useState([]);

    const retrieveRequestCards = async () => {
        const objectRequestCards = await PendingMatchUser.getPendingUserMatchesByReceivedUserId()
        setRequestCards(objectRequestCards.data.pendingUserMatches)
    }

    const getMatches = async () => {
        const objectMatches = await MatchBuddies.getUserMatchesByLoggedInId();
        setMatchCards(objectMatches.data.buddyMatches);
    }

    useEffect(() => {
        retrieveRequestCards();
        getMatches()
    }, []);

    return(
      <section>
        <RequestHeader/>
        <RequestList requestCards={requestCards} />
        <ChatHeader/>
        <MatchList matchCards={matchCards}/>
      </section>
       

    )
}

export default Buddy;