
import http from "./serverBase";
import React, { useState } from "react";

const create = (data) => {
    return http.post("/login", data);
};

const LoginServer ={
    create,
};

export default LoginServer;