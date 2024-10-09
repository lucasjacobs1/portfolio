import './App.css'
import { Route, Routes, BrowserRouter as Router, Link, json } from "react-router-dom";
import NavBar from './components/navbar/navbar';
import LoginPage from './components/login/loginpage';
import Register from './components/register/register';
import PrivateRoute from './PrivateRoute';
import { ToastContainer } from 'react-toastify';
import React, { useState } from "react";
import Missing from "./components/missing/missing";
import HomePage from './components/home/homePage';
import { useCookies } from "react-cookie";
import authService from "./server/authService";
import SettingsPage from './components/settings/settingspage';

function App() {

  //console.log("cookie", authService.getCurrentUser());
  //console.log("role", authService.getCurrentUserRole())
  return (
    <div className='App'>
        <Router>
          <NavBar />

          <Routes>
            <Route element={<PrivateRoute allowedRoles={['FESTIVALGOER', 'ADMIN', 'FESTIVALORGANIZER']} />}>
              <Route path="/" element={<HomePage />} />
              <Route path="/settings" element={<SettingsPage/>}/>
            </Route>

            <Route element={<PrivateRoute allowedRoles={['ADMIN']} />}>

            </Route>

            <Route element={<PrivateRoute allowedRoles={['FESTIVALORGANIZER']} />}>

            </Route>

            <Route path="/login" element={<LoginPage />} />
            <Route path="/register" element={<Register />} />
            <Route path="*" element={<Missing/>}/>

          </Routes>
        </Router>
        <ToastContainer />

    </div>
  );
}

export default App;
