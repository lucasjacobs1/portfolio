import React, { useState } from "react";
import { NavLink } from "react-router-dom";
import './navbar.css';
import authLogin from "../../server/authService";
import { CookiesProvider, useCookies } from 'react-cookie'

function NavBar() {
    const loggedInUserRole = authLogin.getCurrentUserRole();
    const [cookies, setCookie, removeCookie] = useCookies(['token'])

    const handleLogout = () => {
        console.log(loggedInUserRole)
        const confirm = window.confirm("Are you sure to logout?");
        if (confirm) {
            removeCookie('token')
            setAuthToken("");
            window.location.reload();
        }
    };

    const linksAdmin = [
        {
            id: 1,
            path: "/admin",
            text: "admin"
        },
    ]

    const links = [
        {
            id: 1,
            path: "/",
            text: "home"
        },
        {
            id: 5,
            path: "/settings",
            text: "settings"
        }
    ]

    const festivalOrganizerLink = [
        {
            id: 0,
            path: "/communityManager",
            text: "community manager"
        }
    ]

    const NonAuthlinks = [
        {
            id: 0,
            path: "/register",
            text: "register"
        }
    ]

    return (

            <section className="top-nav">
                <div>
                    FestivalConnect
                </div>
                <input id="menu-toggle" type="checkbox" />
                <label className='menu-button-container' htmlFor="menu-toggle">
                    <div className='menu-button'></div>
                </label>
                <ul className="menu">
                    {((loggedInUserRole && "FESTIVALGOER" === loggedInUserRole) || (loggedInUserRole && "ADMIN" === loggedInUserRole) || (loggedInUserRole && "FESTIVALORGANIZER" === loggedInUserRole)) && 
                    //Give all the links that are for each role available
                        links.map(link => {
                            return (
                                <li key={link.id}>
                                    {<NavLink to={link.path}>
                                        {link.text}
                                    </NavLink>
                                    }
                                </li>

                            )
                        })
                    }
                    {loggedInUserRole && "ADMIN" === loggedInUserRole &&
                        //Give all the links that are only for Admin
                        linksAdmin.map(link => {
                            return (
                                <li key={link.id}>
                                    {<NavLink to={link.path}>
                                        {link.text}
                                    </NavLink>
                                    }
                                </li>

                            )
                        })
                    }

                    {loggedInUserRole && "FESTIVALORGANIZER" === loggedInUserRole &&
                        //Give all the links that are only for Admin
                        festivalOrganizerLink.map(link => {
                            return (
                                <li key={link.id}>
                                    {<NavLink to={link.path}>
                                        {link.text}
                                    </NavLink>
                                    }
                                </li>

                            )
                        })
                    }

                    {!loggedInUserRole &&
                        NonAuthlinks.map(link => {
                            return (
                                <li key={link.id}>
                                    {<NavLink to={link.path}>
                                        {link.text}
                                    </NavLink>
                                    }
                                </li>
                            )
                        })
                    }

                    {loggedInUserRole ? (
                        <li><NavLink id="logout" onClick={handleLogout}> logout </NavLink></li>
                    ) : (
                        <li><NavLink to="/login">login</NavLink></li>
                    )
                    }
                </ul>
            </section>
    )
}
export default NavBar;
