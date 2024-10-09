import http from "./serverBase";

const removePotentialById = id => {
    return http.delete(`/PotentialMatchUsers/${id}`, {
        headers: {
            'Authorization': "Bearer " + JSON.parse(localStorage.getItem("tokens")).accessToken
        }});
  };

  const deleteAllByReceivedId = () => {
    return http.delete(`/PotentialMatchUsers/deleteAll` , {
        headers: {
            'Authorization': "Bearer " + JSON.parse(localStorage.getItem("tokens")).accessToken
        }});
  };

  const getPotentialUserMatchesByReceivedUserId = () => {
    return http.get(`/PotentialMatchUsers/filterByReceivedId`, {
        headers: {
            'Authorization': "Bearer " + JSON.parse(localStorage.getItem("tokens")).accessToken
        }
    })
}

const MakePotentialUserMatchesMadeForPersonById = () => {
    return http.get(`/PotentialMatchUsers`, {
        headers: {
            'Authorization': "Bearer " + JSON.parse(localStorage.getItem("tokens")).accessToken
        }
    })
}

  const PotentialUserMatches = {
    removePotentialById,
    deleteAllByReceivedId,
    getPotentialUserMatchesByReceivedUserId,
    MakePotentialUserMatchesMadeForPersonById
    
};

export default PotentialUserMatches;