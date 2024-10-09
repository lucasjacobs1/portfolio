import React from "react";
import RegisterInputFields from "./registerInputFields";
import styles from './register.css';

function Register() {
    return (
        <nav className={styles.register}>
            <RegisterInputFields />
        </nav>

    )
}

export default Register;