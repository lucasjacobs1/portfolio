import './App.css';
import { Route, Routes, BrowserRouter as Router, Link, json } from "react-router-dom";
import NavBar from './components/navbar/navbar';
import HomePage from './components/home/homePage';
import LoginPage from './components/login/loginpage';
import BackGround from './components/background/background';
import Admin from './components/admin/admin';
import Register from './components/register/register';
import Settings from './components/settings/settingsPage';
import PrivateRoute from './PrivateRoute';
import { ToastContainer } from 'react-toastify';
import React, { useState } from "react";
import { AuthContext } from "./components/login/auth";
import Missing from "./components/Missing/Missing";
import Buddy from './components/buddy/buddyPage';
import Chat from './components/chat/chat';
function App() {
  const [authTokens, setAuthTokens] = useState(
    localStorage.getItem("tokens") || ""
  );

  const setTokens = (data) => {
    localStorage.setItem("tokens", JSON.stringify(data));
    setAuthTokens(data);
  };

  console.log("authTokens", authTokens);
  return (
    <div className='App'>
      <AuthContext.Provider value={{ authTokens, setAuthTokens: setTokens }}>
        <Router>
          <NavBar />
          <BackGround />

          <Routes>
            <Route element={<PrivateRoute allowedRoles={['USER', 'ADMIN']} />}>
              <Route path="/" element={<HomePage />} />
              <Route path="/settings" element={<Settings />} />
              <Route path="/buddies" element={<Buddy/>}/>
              <Route path="/chat/:matchId" element={<Chat/>}/>
            </Route>

            <Route element={<PrivateRoute allowedRoles={['ADMIN']} />}>
              <Route path="/admin" element={<Admin />} />
            </Route>


            <Route path="/login" element={<LoginPage />} />
            <Route path="/register" element={<Register />} />
            <Route path="*" element={<Missing/>}/>

          </Routes>
        </Router>
        <ToastContainer />
      </AuthContext.Provider>

    </div>
  );
}

export default App;
