import React, { useState } from "react";
import styles from './register.css';
import UserService from "../../server/userServer";
import NotifyService from "../notification/customNotification";


function AddUser() {

    const initialUserState = {
        firstName: "",
        lastName: "",
        userName: "",
        email: "",
        gender: "",
        birthday: "",
        password: "",
        role: 0
    };
    const [user, setUser] = useState(initialUserState);
    const [created, setCreated] = useState(false);
    const handleInputChange = event => {
        const { name, value } = event.target;
        setUser({ ...user, [name]: value });
    };

    const saveUser = () => {
        var data = {
            firstName: user.firstName,
            lastName: user.lastName,
            userName: user.userName,
            email: user.email,
            gender: user.gender,
            birthday: user.birthday,
            password: user.password,
            role: 0
        };

        
        UserService.create(data)
        
            .then(response => {
                    setCreated(true);
                    setUser({
                        firstName: response.data.firstName,
                        lastName: response.data.lastName,
                        userName: response.data.userName,
                        email: response.data.email,
                        gender: response.data.gender,
                        birthday: response.data.birthday,
                        password: response.data.password,
                        role: 0
                    });
                window.location.href = '/login';

                
            })
            .catch(e => {
                console.log(e);
                NotifyService.warningAlert();
            });
    };

    if(created){
        /*NotifyService.successAlert();*/
        window.location.href = '/login';
    }



    return (
        <section className={styles.register}>
            <div className="flexboxRegister">
                <div className="flexboxRegisterContent">
                    <div className="headerinformation">
                        <h1>Register</h1>
                    </div>
                    <form className="submit-form">

                        <div className="form-group">
                            <input type="text" placeholder="First name" id="firstName" value={user.firstName} onChange={handleInputChange} name="firstName" required />
                            <input type="text" placeholder="Last name" id="lastName" value={user.lastName} onChange={handleInputChange} name="lastName" required />
                            <input type="text" placeholder="Username" id="userName" value={user.userName} onChange={handleInputChange} name="userName" required />
                            <input type="text" placeholder="Email" id="email" value={user.email} onChange={handleInputChange} name="email" />
                            <p>Gender</p>
                            <select name="gender" id="gender" value={user.gender} onChange={handleInputChange}>
                                <optgroup label="Select">
                                    <option value="MALE" onChange={handleInputChange} name="gender" >Man</option>
                                    <option value="FEMALE" onChange={handleInputChange} name="gender" >Female</option>
                                    <option value="OTHER" onChange={handleInputChange} name="gender" >Other</option>
                                    <option value="" onChange={handleInputChange} name="gender" ></option>
                                </optgroup>

                            </select>
                            <p>Born on</p>
                            <input type="date" min='1900-01-01' max='2005-12-11' placeholder="birthday" id="birthday" value={user.birthday} onChange={handleInputChange} name="birthday" required />
                            <input type="password" placeholder="Password" id="password" value={user.password} onChange={handleInputChange} name="password" required />
                            <button onClick={() => { saveUser(); }}>Create</button>
                        </div>
                    </form>
                </div>
            </div>
        </section>

    );
};

export default AddUser;