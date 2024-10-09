import React, { useEffect, useState } from "react";
import styles from './admin.css';
import userService from '../../server/userServer'
import UserList from './UserList'
function Admin() {
    const [userCards, setUserCards] = useState([]);
    const [filter, setFilter] = useState([]);
  

    const retrieveUserCards = async () => {
        const objectUserCards = await userService.getAllUsers()
        setUserCards(objectUserCards.data.users)
        console.log(userCards)
    }

    const filterByGender = async (gender) => {
        const objectUserCardsFilterGender = await userService.getUsersByGender(gender)
        setUserCards(objectUserCardsFilterGender.data.users);
        console.log(objectUserCardsFilterGender);
    }

    const handleChange = (e) => {
        setFilter(e.target.value);
    }

    useEffect(() => {
        switch (filter) {
            case "genderF":
                filterByGender("FEMALE");
                break;
            case "genderM":
                filterByGender("MALE");
                break;
            case "genderO":
                filterByGender("OTHER");
                break; 
            case "def":
                retrieveUserCards();
                break;
            default:
                retrieveUserCards();
        }

    }, [filter])




    return (
        <section className={styles.admin}>
            <div className="flexboxUserFunctions">
                <div className="flexboxUserFunctionsContent">
                    <div className="flexboxFilterby">
                        <p>sort by gender:</p>
                        <select onChange={handleChange} value={filter}>
                            <optgroup label="Select"  >
                                <option value="def" >show all</option>
                                <option value="genderF" >Female</option>
                                <option value="genderM" >Man</option>
                                <option value="genderO" >Other</option>
                            </optgroup>
                        </select>
                    </div>
                </div>
            </div>
            <UserList userCards={userCards} />



        </section>

    )
}


export default Admin;