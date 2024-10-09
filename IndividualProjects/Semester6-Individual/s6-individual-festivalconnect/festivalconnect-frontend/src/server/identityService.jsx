import authService from "./authService";
import http from "./serverBase";

const login = (data) => {
    return http.post("/Identity/login", data);
};

const register = (data) => {
    return http.post("/Identity/register", data);
};

const deleteUser = (usertoken) => {
    return http.delete(`/Identity`, {
        headers: {
            'Authorization': "Bearer " + usertoken
        }
    });
};

const LoginServer ={
    login,
    register,
    deleteUser
};

export default LoginServer;