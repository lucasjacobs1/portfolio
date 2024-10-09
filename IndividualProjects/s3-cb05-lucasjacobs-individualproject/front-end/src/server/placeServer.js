import http from "./serverBase";

const getAllPlaces = () => {
    return http.get("/place",{
        headers: {
            'Authorization': "Bearer " + JSON.parse(localStorage.getItem("tokens")).accessToken
        }
    });
};

const getPlaceById = (id) => {
    return http.get(`/place/${id}`,{
        headers: {
            'Authorization': "Bearer " + JSON.parse(localStorage.getItem("tokens")).accessToken
        }
    });
};

const getPlaceByName = (name) => {
    return http.get(`/place/getPlaceName/${name}`,{
        headers: {
            'Authorization': "Bearer " + JSON.parse(localStorage.getItem("tokens")).accessToken
        }
    });
};


const placesService={
    getAllPlaces,
    getPlaceById,
    getPlaceByName
}

export default placesService;