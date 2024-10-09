import http from "./serverBase";

const create = (data) => {
    return http.post("/deniedUser", data,{
        headers: {
            'Authorization': "Bearer " + JSON.parse(localStorage.getItem("tokens")).accessToken
        }
    });
};

const deniedUsersService ={
    create,
};

export default deniedUsersService;