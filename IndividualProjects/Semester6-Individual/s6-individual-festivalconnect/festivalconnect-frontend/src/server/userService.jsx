import http from "./serverBase";
import authService from "./authService";
import { useCookies } from 'react-cookie';

const update = (data, token) => {
    return http.put(`/user`, data, {
        headers: {
            'Authorization': "Bearer " + token
        }
    });
};


const getUser = (data) => {
    return http.get(`/User/GetByIdentityId`, {
        headers: {
            'Authorization': "Bearer " + data
        }
    })
}

const UserService ={
    update,
    getUser,
};

export default UserService;