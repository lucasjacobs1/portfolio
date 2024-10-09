import React, { useState, useEffect } from "react";
import styles from './settings.css';
import algorithmBuddyService from "../../server/algorithmBuddyMatch";
import UserService from "../../server/userServer";
import NotifyService from "../notification/customNotification";
import PotentialUserMatches from "../../server/potentialUserMatchServer";
function SearchOption() {
    const [algorithms, setAlgorithms] = useState([]);
    const [currentAlgorithm, setCurrentAlgorithm] = useState();

    useEffect(() => {
        retrieveAlgorithms();
        getUser();
    }, []);

    const retrieveAlgorithms = () => {
        algorithmBuddyService.getAllAlgo()
            .then(response => {
                setAlgorithms(response.data.matchAlgorithms);
                console.log(response.data);
            })
            .catch(e => {
                console.log(e);
            });
    };

     const getUser =  () => {
            UserService.getUser()
            .then(response => {
               setCurrentAlgorithm(response.data.algoChoice.id);
            })
            .catch(e => {
                console.log(e);
            });
        
    };

    function handleChangeAlgorithms(e){
        setCurrentAlgorithm(e.target.value);
        
    }

    const updateAlgo = () => {
        

        var data = {
            id: currentAlgorithm,
        
        };

        
        UserService.updateAlgoChoice(data)
            .then(response => {
                if (response.status === 204) {
                    PotentialUserMatches.deleteAllByReceivedId();
                    window.location.reload();
                }
                else{
                    NotifyService.errorMessage();
                }
            })
            .catch(e => {
                console.log(e);
                NotifyService.errorMessage();
            });
    };



    return (
        <div className={styles.settings}>
            <div className="flexbox">
                <div className="flexboxSettingsContent">
                    <p>How do you want to find your travel buddy?</p>
                    <select id="algorithm" name="algorithm" value={currentAlgorithm} onChange={handleChangeAlgorithms} >
                        <optgroup label="Select">
                            {algorithms.map(algorithm => {
                                return(
                                    <option value={algorithm.id} id={algorithm.id}>
                                        {algorithm.name} 
                                    </option>
                                )})}
                                


                        </optgroup>

                    </select>
                    <button onClick={updateAlgo}>Update</button>
                    <p>*Standard Matching: Uses ALL your preferences to find your travel buddy</p>
                    <p>*Basic Matching: Uses your AGE preferences to find your travel buddy</p>
                    <p>*No Preferences Matching: Uses NO preferences to find your travel buddy</p>

                </div>
            </div>
        </div>

    )

}

export default SearchOption;