import http from "./serverBase";

const getAllUsers = () => {
    return http.get("/users", {
        headers: {
            'Authorization': "Bearer " + JSON.parse(localStorage.getItem("tokens")).accessToken
        }
    });
};

const getUsersByGender = gender =>{
    return http.get(`/users/${gender}`, {
        headers: {
            'Authorization': "Bearer " + JSON.parse(localStorage.getItem("tokens")).accessToken
        }
    })
}

const create = (data) => {
    return http.post("/users", data,);
};

const update = (id, data) => {
    return http.put(`/users/${id}`, data, {
        headers: {
            'Authorization': "Bearer " + JSON.parse(localStorage.getItem("tokens")).accessToken
        }
    });
};

const remove = id => {
    return http.delete(`/users/${id}`, {
        headers: {
            'Authorization': "Bearer " + JSON.parse(localStorage.getItem("tokens")).accessToken
        }
    });
};

const getUser = () => {
    return http.get(`/users/filterById`, {
        headers: {
            'Authorization': "Bearer " + JSON.parse(localStorage.getItem("tokens")).accessToken
        }
    })
}

const updateAlgoChoice = (data) => {
    return http.put(`/users/updateMatching`, data, {
        headers: {
            'Authorization': "Bearer " + JSON.parse(localStorage.getItem("tokens")).accessToken
        }
    });
};

const UserService ={
    getAllUsers,
    create,
    update,
    remove,
    getUser,
    getUsersByGender,
    updateAlgoChoice
};

export default UserService;