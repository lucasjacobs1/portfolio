import http from "./serverBase";

const getAllAlgo= () => {
    return http.get("/BuddyMatchAlgo",{
        headers: {
            'Authorization': "Bearer " + JSON.parse(localStorage.getItem("tokens")).accessToken
        }
    });
};

const getPlaceByName = (name) => {
    return http.get(`/BuddyMatchAlgo/getAlgoName/${name}`,{
        headers: {
            'Authorization': "Bearer " + JSON.parse(localStorage.getItem("tokens")).accessToken
        }
    });
};

const algorithmBuddyService={
    getAllAlgo,
    getPlaceByName
}



export default algorithmBuddyService;