import styles from './settings.css';
import PreferenceOption from "./preferenceOption";
import SearchOption from "./searchOption";

function SettingsPage(){
    return(
        <div className={styles.settings}>
                <PreferenceOption/>
                <SearchOption/>
            </div>


    )

}
export default SettingsPage;