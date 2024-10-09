import React from "react";
import {toast } from 'react-toastify';
import 'react-toastify/dist/ReactToastify.css';

    

    const successLoginAlert = () => {
        return toast("User logged in successfully", {
            position: "top-right",
            autoClose: 2000,
            hideProgressBar: false,
            closeOnClick: true,
            pauseOnHover: false,
            draggable: true,
            progress: undefined,
    
        });}

        const successAlert = () => {
            return toast("succesfull", {
                position: "top-right",
                autoClose: 2000,
                hideProgressBar: false,
                closeOnClick: true,
                pauseOnHover: false,
                draggable: true,
                progress: undefined,
        
            });}

        const warningAlert = () => {
            // window.alert("Invalid Credentials");
             return toast.error("Invalid Credentials", {
                position: "top-right",
                autoClose: 2000,
                hideProgressBar: false,
                closeOnClick: true,
                pauseOnHover: false,
                draggable: true,
                progress: undefined,
                
        
            });}

        const errorMessage =() => {
            return toast.error("something went wrong", {
                position: "top-right",
                autoClose: 2000,
                hideProgressBar: false,
                closeOnClick: true,
                pauseOnHover: false,
                draggable: true,
                progress: undefined,
        });}

        const loginMessage =(data) => {
            return toast.error(data, {
                position: "top-right",
                autoClose: 2000,
                hideProgressBar: false,
                closeOnClick: true,
                pauseOnHover: false,
                draggable: true,
                progress: undefined,
                toastId: "error-message",
        });}

   const notifyService ={
        successLoginAlert,
        warningAlert,
        successAlert,
        errorMessage,
        loginMessage
   }




export default notifyService;