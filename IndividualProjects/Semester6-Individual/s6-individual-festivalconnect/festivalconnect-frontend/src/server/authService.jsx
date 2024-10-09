import { useCookies } from 'react-cookie';
import { jwtDecode } from 'jwt-decode';

const getCurrentUserRole = () => {
  const user = getCurrentUser();
  if (user) {
    return jwtDecode(user).roles;
  }
  return null;
};

const getUser = () => {
  return getCurrentUser();
}

const getCurrentUserId = () => {
    var token = document.cookie.split('=')[1]
    if(token){
        return jwtDecode(token).Id
    }
  return null;
};

const getCurrentUserEmail = () => {
    var token = document.cookie.split('=')[1]
    if(token){
        return jwtDecode(token).Email
    }
  return null;
};

const decodeToken = (token) => {
  const base64Url = token.split('.')[1];
  const base64 = base64Url.replace(/-/g, '+').replace(/_/g, '/');
  const decode = JSON.parse(window.atob(base64));
  return decode;
};

const getCurrentUser = () => {
    const [cookies] = useCookies(['token']);
    const token = cookies.token;
    if (token) {
      return token;
    }
    return null;
  };
  
const authService = {
  getCurrentUserRole,
  getCurrentUserId,
  decodeToken,
  getUser,
  getCurrentUser,
  getCurrentUserEmail
};

export default authService;