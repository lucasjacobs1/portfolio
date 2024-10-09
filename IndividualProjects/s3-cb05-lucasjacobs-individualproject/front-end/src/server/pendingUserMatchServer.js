import http from "./serverBase";

const create = (data) => {
    return http.post("/PendingMatchUser", data,{
        headers: {
            'Authorization': "Bearer " + JSON.parse(localStorage.getItem("tokens")).accessToken
        }
    });
};

const removePendingById = (id) => {
    return http.delete(`/PendingMatchUser/${id}`,{
        headers: {
            'Authorization': "Bearer " + JSON.parse(localStorage.getItem("tokens")).accessToken
        }
    });
};

const getPendingUserMatchesByReceivedUserId = () => {
    return http.get(`/PendingMatchUser/filterById`, {
        headers: {
            'Authorization': "Bearer " + JSON.parse(localStorage.getItem("tokens")).accessToken
        }
    })
}

const PendingMatchUser = {
    create,
    removePendingById,
    getPendingUserMatchesByReceivedUserId,
};

export default PendingMatchUser;