import React from "react";
import LoginInputFields from "./loginInputFields";
import HeaderLogin from "./headerLogin";
import styles from './login.css';
import BackGround from "./loginBackground";
function LoginPage(){
    return(
        <section className={styles.login}>
            <BackGround/>
            <HeaderLogin/>
            <LoginInputFields/>

        </section>

        )

}
export default LoginPage;