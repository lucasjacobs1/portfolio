import axios from "axios";

let baseURL;
if(process.env.NODE_ENV ==='production'){
    baseURL = "http://festivalconnectapi.germanywestcentral.cloudapp.azure.com:8080/"
}else{
    baseURL = "http://localhost:5000/"
}

export default axios.create({
    baseURL,
    headers: {
        "Content-type": "application/json",
    }
});
