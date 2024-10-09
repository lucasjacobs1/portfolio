const getCurrentUserRole = () => {
    const user = getCurrentUser();
    if (user) {
        return decodeToken(user).roles;
    }
    return null;
}

const getCurrentUserId = () => {
    const user = getCurrentUser();
    if(user){
        return decodeToken(user).id;
    }
    return null;
}
const getCurrentUsername = () => {
    const user = getCurrentUser();
    if(user){
        return decodeToken(user).sub;
    }
    return null;
}


const getUserMatched = (data) => {
    if(data.buddy1.id !== getCurrentUserId()){
        return data.buddy1;
    }
    else{
        return data.buddy2;
    }
    
}

const getUserFromBuddyMatch = (data) => {
    if(data.buddy1.id === getCurrentUserId()){
        return data.buddy1;
    }
    else{
        return data.buddy2;
    }
}



const decodeToken = (token) => {
    const base64Url = token.accessToken.split('.')[1];
    const base64 = base64Url.replace('-', '+').replace('_', '/');
    const decode = JSON.parse(window.atob(base64));
    return decode;
}

const getCurrentUser = () => {
    return JSON.parse(localStorage.getItem('tokens'));
}

const authLogin = {
    getCurrentUserRole,
    decodeToken,
    getCurrentUser,
    getCurrentUserId,
    getUserMatched,
    getUserFromBuddyMatch,
    getCurrentUsername
};

export default authLogin;