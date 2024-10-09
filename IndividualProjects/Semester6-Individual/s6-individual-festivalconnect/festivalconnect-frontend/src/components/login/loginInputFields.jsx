import React, { useState } from "react";
import IdentityService from "../../server/identityService";
import NotifyService from "../notification/customNotification";
import './login.css';
import {CookiesProvider, useCookies} from 'react-cookie'

function LoginInputFields(props) {
    const [isLoggedIn, setLoggedIn] = useState(false);
    const [isError, setIsError] = useState(false);
    const [cookies, setCookie] = useCookies(['token'])

    const isFormValid = () => {
        return login.password.trim() !== '' && login.email.trim() !== '';
    };

    const validateEmail = (email) => {
        const emailPattern = /^[^\s@]+@[^\s@]+\.[^\s@]+$/;
        return emailPattern.test(email);
    };

    const initialLoginState = {
        email: "",
        password: ""
    };
    const [login, setLogin] = useState(initialLoginState);

    const handleInputChange = event => {
        const { name, value } = event.target;
        setLogin({ ...login, [name]: value });
    };

    const saveLogin = () => {
        var data = {
            email: login.email,
            password: login.password,
        };

        if (!isFormValid()) {
            document.getElementById('error').innerText = 'Please fill out all fields.';
            return;
        }
        if(!validateEmail(login.email)){
            document.getElementById('error').innerText = 'Please enter a valid email.';
            NotifyService.loginMessage('Please enter a valid email.');
            return;
        }
        document.getElementById('error').innerText = ''; // Clear the error message
        IdentityService.login(data)
            .then(response => {
                if (response.status === 200) {
                    if (response.data.token == null){
                        NotifyService.loginMessage(response.data.message);
                    }
                    else{
                        setCookie('token', response.data.token, { path: '/', secure: true, maxAge: 60 * 60 * 24 * 1  }); //set cookie for 1 day
                        console.log(cookies.token)
                        setLoggedIn(true);
                    }
                    console.log(response.data);
                }
                else if(response.status === 500){
                    NotifyService.loginMessage("Our servers are currently unavailable. Please try again later.");
                }
                else {
                    setIsError(true);
                    NotifyService.warningAlert();
                }
            })
            .catch(e => {
                console.log(e);
                NotifyService.loginMessage("Our servers are currently unavailable. Please try again later.");
            });
    };

    if (isLoggedIn) {
        NotifyService.successLoginAlert();
        window.location.href = '/';
    }
    return (

        <CookiesProvider>

        <div className='container'>
            <div className='centeredDivLogin'>
                    <div className="headerinformation"><h1>Login</h1></div>
                    
                    <input type="text" className='textInput' placeholder="Email" id="email" value={login.username} onChange={handleInputChange} name="email" required></input>
                    <input type="password" className='textInput' placeholder="Password" id="password" value={login.password} onChange={handleInputChange} name="password" required></input>
                    <button type="submit" onClick={() => { saveLogin(); }}>Login </button>
                    <div id="error"></div>
                    <p>Don't have a account yet? <a href onClick={event => window.location.href = '/register'}>register</a></p>
                </div>
            </div>
        </CookiesProvider>


    )
}
export default LoginInputFields;