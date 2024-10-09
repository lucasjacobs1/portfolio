import React from "react";
import UserCard from "./UserCard";

function UserList(props){
   
    return(
        
        <ul> 
            {props.userCards?.map(userCards =>(
                <UserCard key={userCards.id} userCards={userCards}/>
            ))}
        </ul>
    
    )
}
export default UserList;