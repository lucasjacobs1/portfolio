import React from "react";
import { useEffect } from "react";
import { useNavigate } from "react-router-dom";
import styles from './home.css';
import HomeFunction from './homeFunctions';
import HomeHeader from "./homeHeader";
function HomePage() {
	return (
		<nav className={styles.home}>
			<HomeHeader />
			<HomeFunction />


		</nav>
	)

}
export default HomePage;