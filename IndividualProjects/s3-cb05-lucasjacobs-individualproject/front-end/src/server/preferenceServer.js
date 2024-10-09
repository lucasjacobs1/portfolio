import http from "./serverBase";

const create = (data) => {
    return http.post("/preferences", data);
};

const update = (data) => {
    return http.put(`/preferences`, data,{
        headers: {
            'Authorization': "Bearer " + JSON.parse(localStorage.getItem("tokens")).accessToken
        }
    });
};

const PreferencesServer ={
    create,
    update,
};

export default PreferencesServer;