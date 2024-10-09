import http from "./serverBase";

const create = (data) => {
    return http.post("/match", data,{
        headers: {
            'Authorization': "Bearer " + JSON.parse(localStorage.getItem("tokens")).accessToken
        }
    });
};

const getUserMatchesByLoggedInId = () => {
    return http.get(`/match/filterById`, {
        headers: {
            'Authorization': "Bearer " + JSON.parse(localStorage.getItem("tokens")).accessToken
        }
    })
}

const getMatchById = (id) => {
    return http.get(`/match/${id}`, {
        headers: {
            'Authorization': "Bearer " + JSON.parse(localStorage.getItem("tokens")).accessToken
        }
    })
}



const matchBuddies = {
    create,
    getUserMatchesByLoggedInId,
    getMatchById
    
};

export default matchBuddies;