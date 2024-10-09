import React, { useState, useEffect } from 'react';
import { useNavigate, useLocation } from 'react-router-dom';
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome';
import { Link } from 'react-router-dom';
import UserService from "../../server/userService";
import IdentityService from "../../server/identityService";
import NotifyService from "../notification/customNotification";
import './settings.css';
import { CookiesProvider, useCookies } from 'react-cookie'
import notifyService from '../notification/customNotification';
import authService from '../../server/authService';

function SettingsCard(props) {
    const [cookies, setCookie, removeCookie] = useCookies(['token'])
    const initialUserState = {
        username: "",
    };
    const [user, setUser] = useState(initialUserState);
    const usertoken = authService.getUser();
    const [token, setToken] = useState(cookies.token || authService.getUser());

    useEffect(() => {
            console.log(token)
            UserService.getUser(token)
                .then(response => {
                    setUser({
                        username: response.data.username,
                    });
                })
                .catch(e => {
                    console.log(e);
                });
        
    }, []);

    const handleInputChange = event => {
        const { name, value } = event.target;
        setUser({ ...user, [name]: value });
    };

    const updateUser = () => {
        const data = {
            username: user.username,
        };
        const userToken = token
        if(data.username.length === 0){ return}
        // Check if the username has more than 3 characters
        if (data.username && data.username.length > 3) {
            UserService.update(data, userToken)
                .then(response => {
                    if (response.status === 200) {
                        setUser({
                            username: response.data.username,
                        });
                        NotifyService.successAlert();
                    } else {
                        NotifyService.errorMessage();
                    }
                })
                .catch(e => {
                    console.log(e);
                    NotifyService.errorMessage();
                });
        } else {
            // Handle the case where the username is invalid
            console.log('Username must be more than 3 characters');
            NotifyService.loginMessage('Username must be more than 3 characters');
        }
    };
    

    const deleteUser = () => {
        const confirm = window.confirm("Are you sure you want to delete this person? No undoing after removing!");
        if (confirm) {
            IdentityService.deleteUser(token)
                .then(response => {
                    console.log(response.data);
                    removeCookie('token')
                    setAuthToken("");
                    NotifyService.successAlert();
                    window.location.reload();
                })
                .catch(e => {
                    NotifyService.errorMessage();
                });
        }
    };

    return (
        <li>
            <div className="flexboxBodyUser">
                <div className="flexboxBodyUserContent">
                <div className="headerinformation">
                        <h1>User Information</h1>
                    </div>

                              <p>Username:</p>  
                                <input 
                                    type="text" 
                                    placeholder="Username" 
                                    value={user.username} 
                                    onChange={handleInputChange} 
                                    name="username" 
                                    required 
                                />
                            <button className="buttonUpdateUser" onClick={updateUser}>Update</button>
                            <button className="buttonDeleteUser" onClick={deleteUser}>Delete</button>
                </div>
            </div>
        </li>
    );
}

export default SettingsCard;