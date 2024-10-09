import styles from "./login.css";

function HeaderLogin() {
    return (
        <div className={styles.login}>
            <div className="flexboxHeader">
                <div className="flexboxHeaderContent">
                    <p className="headerFont">Find your own travel buddy!</p>
                    <p>Are you ready to never travel on your own?</p>
                </div>

            </div>
        </div>


    )
}
export default HeaderLogin;