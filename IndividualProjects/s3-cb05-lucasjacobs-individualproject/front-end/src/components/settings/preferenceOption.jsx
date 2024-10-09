import React, { useState, useEffect } from "react";
import styles from './settings.css';
import UserService from "../../server/userServer";
import PreferenceService from "../../server/preferenceServer";
import PlaceService from "../../server/placeServer";
import NotifyService from "../notification/customNotification";
function PreferenceOption() {

    const [currentUserPreference, setUserCurrentPreference] = useState();
    const [place, setPlace] = useState([]);
    //const [placeName] = useState(place[currentUserPreference.preference.placeId].name);
    const [initialUserState,setinitialUserState] = useState();
    const [gender, setGender] = useState();
    const [currentPlace, setCurrentPlace] = useState();
    const [placeId, setPlaceId] = useState();
    const getPreference =  () => {
            UserService.getUser()
            .then(response => {
                setUserCurrentPreference(response.data);
                setGender(response.data.preference.gender);
                setCurrentPlace(response.data.preference.place.id);
                setinitialUserState({
                    minAge: response.data.preference.minAge,
                    maxAge: response.data.preference.maxAge,
                    place: response.data.preference.place.id,
                    gender: response.data.preference.gender
            });
            })
            .catch(e => {
                console.log(e);
            });
        
    };

    function handleChangePlace(e){
        setCurrentPlace(e.target.value);
        setPlaceId(e.target.id);
       
            PlaceService.getPlaceByName(e)
            .then(response => {
                setCurrentPlace(response.data.id);
                
            });
        
           
        
    }
   
    const updatePreference = () => {
        

        var data = {
            minAge: document.getElementById("minAge").value,
            maxAge: document.getElementById("maxAge").value,
            placeId: currentPlace,
            gender: document.getElementById("gender").value
        };

        
        PreferenceService.update(data)
            .then(response => {
                if (response.status === 204) {
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

  
    const retrievePlaces = () => {
        PlaceService.getAllPlaces()
            .then(response => {
                setPlace(response.data.places);
            })
            .catch(e => {
                console.log(e);
            });
    };

    useEffect(() => {
        getPreference();
        retrievePlaces();
    }, []);
    

    
    if (currentUserPreference == undefined) {
        return (<p>loading...</p>)
    }
    else{
    return (
        <div className={styles.settings}>
            <form>
            <div className="flexbox">
                <div className="flexboxPreferenceContent">
                    <div className="header"><p>Preferences</p></div>
                    <p>Minimum age</p>
                    <input id="minAge" type="text" placeholder={currentUserPreference.preference.minAge}></input>

                    <p>Maximum age</p>
                    <input id="maxAge" type="text" placeholder={currentUserPreference.preference.maxAge}></input>

                    <p>Place</p>
                    <select id="place" name="place" value={currentPlace} onChange={handleChangePlace}  >
                        <optgroup label="Select">
                            {place.map(place => {
                                return(
                                    <option value={place.id} id={place.id}>
                                        {place.name} 
                                    </option>
                                )})}
                        </optgroup>
                    </select>

                    <p>Gender</p>
                    <select id="gender" name="gender" value={gender} onChange={(e) => setGender(e.target.value)}>
                        <optgroup label="Select">
                            <option value=""  name="gender" >...</option>
                            <option value="MALE"  name="gender" >MALE</option>
                            <option value="FEMALE"  name="gender" >FEMALE</option>
                            <option value="OTHER"  name="gender" >OTHER</option>
                            <option value="" name="gender" ></option>
                        </optgroup>

                    </select>

                    <button onClick={updatePreference}>Update</button>


                </div>
            </div>
            </form>
        </div>


    )    
}
}

export default PreferenceOption;