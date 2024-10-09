import React, { useState } from "react";
import styles from "./login.css";
import { useAuth } from "./auth";
import LoginService from "../../server/loginServer";
import NotifyService from "../notification/customNotification";
  

function LoginInputFields(props) {
    const [isLoggedIn, setLoggedIn] = useState(false);
    const [isError, setIsError] = useState(false);
    const { setAuthTokens } = useAuth();


    const initialLoginState = {
        username: "",
        password: ""
    };
    const [login, setLogin] = useState(initialLoginState);

    const handleInputChange = event => {
        const { name, value } = event.target;
        setLogin({ ...login, [name]: value });
    };

    const saveLogin = () => {
        var data = {
            username: login.username,
            password: login.password,
        };

        LoginService.create(data)
            .then(response => {
                if (response.status === 200) {

                    setAuthTokens(response.data);
                    setLoggedIn(true);
                    console.log(response.data);
                }
                else {
                    setIsError(true);
                    NotifyService.warningAlert();
                }
            })
            .catch(e => {
                console.log(e);
                NotifyService.loginMessage(e.response.data.message);
            });
    };

    if (isLoggedIn) {
        NotifyService.successLoginAlert();
        return window.location.href = '/';
    }
    return (


        <div className={styles.login}>
            <div className="flexboxLogin">
                <div className="flexboxLoginContent">
                    <div className="headerinformation"><h1>Login</h1></div>
                    
                    <input type="text" placeholder="Username" id="username" value={login.username} onChange={handleInputChange} name="username" required></input>
                    <input type="password" placeholder="Password" id="password" value={login.password} onChange={handleInputChange} name="password" required></input>
                    <button type="submit" onClick={() => { saveLogin(); }}>Login </button>
                    <p>Don't have a account yet? <a href onClick={event => window.location.href = '/register'}>register</a></p>
                </div>
            </div>

        </div>

    )
}
export default LoginInputFields;