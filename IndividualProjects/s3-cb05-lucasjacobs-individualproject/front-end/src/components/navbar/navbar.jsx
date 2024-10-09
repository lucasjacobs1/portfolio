import React, { useState } from "react";
import { NavLink } from "react-router-dom";
import styles from './navbar.css'
import { useAuth } from "../login/auth";
import authLogin from "../../server/authService";

function NavBar() {
    const { authTokens } = useAuth();
    const loggedInUser = authLogin.getCurrentUserRole();

    /*const setAuthToken = useState(
        localStorage.getItem("tokens") || ""
    );*/

    const [, setAuthToken] = useState(
        localStorage.getItem("tokens") || ""
      );



    const handleLogout = () => {
        const confirm = window.confirm("Are you sure to logout?");
        if (confirm) {
            localStorage.removeItem("tokens");
            setAuthToken("");
            window.location.reload();
        }

    };

    const linksAdmin = [
        {
            id: 1,
            path: "/admin",
            text: "manage users"
        },
    ]

    const links = [
        {
            id: 1,
            path: "/",
            text: "home"
        },
        {
            id: 2,
            path: "/buddies",
            text: "buddies"
        },
        {
            id: 5,
            path: "/settings",
            text: "settings"
        },

    ]

    const NonAuthlinks = [
        {
            id: 0,
            path: "/register",
            text: "register"
        }

    ]

    return (

        <nav className={styles.navbar}>
            <section className="top-nav">
                <div>
                    Find your travel buddy
                </div>
                <input id="menu-toggle" type="checkbox" />
                <label className='menu-button-container' htmlFor="menu-toggle">
                    <div className='menu-button'></div>
                </label>
                <ul className="menu">
                    {((loggedInUser && "USER" === loggedInUser[0]) || (loggedInUser && "ADMIN" === loggedInUser[0])) &&
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

                    {loggedInUser && "ADMIN" === loggedInUser[0] &&
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




                    {!loggedInUser &&
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

                    {authTokens ? (
                        <li><NavLink id="logout" onClick={handleLogout}> logout </NavLink></li>
                    ) : (
                        <li><NavLink to="/login">login</NavLink></li>
                    )
                    }

                </ul>
            </section>
        </nav>
    )
}

export default NavBar;
