import { useState } from 'react';
import { useNavigate, useLocation } from 'react-router-dom';
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome';
import { Link} from 'react-router-dom'
import IdentityService from "../../server/identityService";
import NotifyService from "../notification/customNotification";
import notifyService from '../notification/customNotification';

function Register() {
    const [role, setRole] = useState(0);
    const [email, setEmail] = useState('');
    const [username, setUsername] = useState('');
    const [password, setPassword] = useState('');
    const [confirmPassword, setConfirmPassword] = useState('');

    const isFormValid = () => {
        return username.trim() !== '' && password.trim() !== '' && confirmPassword.trim() !== '';
    };

    const validateEmail = (email) => {
        const emailPattern = /^[^\s@]+@[^\s@]+\.[^\s@]+$/;
        return emailPattern.test(email);
    };

    const handleClose = () => {
        navigate(location.pathname.replace('/register', '/'));
    };

    const handleRegister = async (event) => {
        event.preventDefault(); // Prevent default form submission

        try {
            if (!isFormValid()) {
                document.getElementById('error').innerText = 'Please fill out all required fields';
                return;
            }
            if(!validateEmail(email)){
                document.getElementById('error').innerText = 'Please enter a valid email';
                return;
            }
            if(password != confirmPassword){
                document.getElementById('error').innerText = 'The entered passwords are not the same';
                return;
            }
            const registerCredentials = {
                role: role,
                username: username,
                email: email,
                password: password,
                confirmPassword: confirmPassword
            }
            
            const response = await IdentityService.register(registerCredentials);
            if(response.status == 200 && response.data.flag !== false){
                //navigate(location.pathname.replace('/register', '/confirm'))
                NotifyService.successAlert();
            }else{
                //const errorMessage = await response.text();
                //document.getElementById('error').innerText = errorMessage;
                NotifyService.loginMessage(response.data.message);
            }
            
        } catch (error) {
            console.error('Error occurred:', error);
            NotifyService.errorMessage("Our servers are currently unavailable. Please try again later.");
        }
    };

    return (
            <div className="container">
                <div className="flexboxRegisterContent">
                    <div className="headerinformation">
                        <h1>Register</h1>
                    </div>
                    <form className="submit-form" onSubmit={handleRegister}>

                        <div className="form-group">
                            <select name="role" id="role" value={role} onChange={e => setRole(e.target.value)}>
                                <optgroup label="Select Role">
                                    <option value={0} onChange={e => setRole(e.target.value)} name="role" >Festival-Goer</option>
                                    <option value={1} onChange={e => setRole(e.target.value)} name="role" >Festival-Organizer</option>
                                </optgroup>

                            </select>
                            <input type="text" placeholder="Username" id="username" value={username} onChange={e => setUsername(e.target.value)} name="username" required />
                            <input type="text" placeholder="Email" id="email" value={email} onChange={e => setEmail(e.target.value)} name="email" />
                            <input type="password" placeholder="Password" id="password" value={password} onChange={e => setPassword(e.target.value)} name="password" required />
                            <input type="password" placeholder="confirmPassword" id="confirmPassword" value={confirmPassword} onChange={e => setConfirmPassword(e.target.value)} name="confirmPassword" required />
                            <br/>
                            <div id="error"></div>

                            <button type="submit">Register</button>
                        </div>
                    </form>
                    <p className='loginText'>Already have an account?</p><br/>
                   <Link to='/login'><button>Sign in</button></Link>


                </div>
            </div>

    );
};

export default Register;