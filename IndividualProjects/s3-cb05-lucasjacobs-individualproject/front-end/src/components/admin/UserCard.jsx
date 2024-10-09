import React from "react";
import userService from '../../server/userServer'
import NotifyService from "../notification/customNotification";
import { useState } from 'react';
import  { redirect } from 'react-router-dom'

function UserCard(props) {
    const deleteUser = () => {
        const confirm = window.confirm("Are you sure you want to delete this person? No undoing after removing!");
        if (confirm) {
            userService.remove(props.userCards.id)
                .then(response => {
                    console.log(response.data);
                    NotifyService.successAlert();
                    window.location.reload();

                })
                .catch(e => {
                    NotifyService.errorMessage();
                });
        };
    }




const initialUserState = {
        userName: props.userCards.userName,
        email: props.userCards.email,
        password: "",
    };
    const [user, setUser] = useState(initialUserState);

    const handleInputChange = event => {
        const { name, value } = event.target;
        setUser({ ...user, [name]: value });
    };

    const updateUser = () => {
        var data = {
            userName: user.userName,
            email: user.email,
            password: user.password,
        };

        
        userService.update(props.userCards.id,data)
            .then(response => {
                if (response.status === 204) {
                    setUser({
                        userName: response.data.userName,
                        email: response.data.email,
                        password: response.data.password,
                    });
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

   

    return (
        <li>
            <div className="flexboxBodyUser">
                <div className="flexboxBodyUserContent">

                    <div className="flextboxChangebleInfo">
                        <div className="flexboxChangebleInfoContent">
                            <div className="">Id: {props.userCards.id}</div>
                            <div className="">First name: {props.userCards.firstName}</div>
                            <div className="">Last name: {props.userCards.lastName}</div>
                            <div>Username:<input type="text" placeholder="Username" value={user.userName} onChange={handleInputChange} name="userName" required /></div>
                            <div>Email<input type="text" placeholder="Email" value={user.email} onChange={handleInputChange} name="email" required/></div>
                            <div className="">Gender: {props.userCards.gender}</div>
                            <div className="">Reset password</div>
                            <input type="password" placeholder="Password" value={user.password} onChange={handleInputChange} name="password" required />


                        </div>

                        <div className="flexboxOperationInfoContent">
                            <button className="buttonUpdateUser" onClick={updateUser} >Update</button>
                            <button className="buttonDeleteUser" onClick={deleteUser} >Delete</button>


                        </div>

                    </div>
                </div>
            </div>


        


        
   
        </li>

    )
}
export default UserCard;