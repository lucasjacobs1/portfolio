import styles from "./home.css";

function HomeHeader() {
    return (
        <div className={styles.login}>
            <div className="flexboxHomeHeader">
                <div className="flexboxHomeHeaderContent">
                    <p className="headerFont">Search for a travel buddy!</p>
                </div>

            </div>
        </div>


    )
}
export default HomeHeader;