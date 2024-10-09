import React from "react";
import RequestCards from "./requestCard";

function RequestList(props){
   
    return(
        
        <ul> 
            {props.requestCards?.map(requestCards =>(
                <RequestCards key={requestCards.id} requestCards={requestCards}/>
            ))}
        </ul>
    
    )
}
export default RequestList;