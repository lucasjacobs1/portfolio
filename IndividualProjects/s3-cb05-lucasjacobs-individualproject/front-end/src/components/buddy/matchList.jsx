import React from "react";
import MatchCard from "./matchCard";

function MatchList(props){
   
    return(
        
        <ul> 
            {props.matchCards?.map(matchCards =>(
                <MatchCard key={matchCards.id} matchCards={matchCards}/>
            ))}
        </ul>
    
    )
}
export default MatchList;