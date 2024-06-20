import axios from "axios";

function middlewareSettings() {
	axios.defaults.baseURL = "https://localhost:7167/api/";
	axios.defaults.headers.post["Content-Type"] = "application/json";
	axios.defaults.headers.common["Access-Control-Allow-Origin"] = "*";
	const token = localStorage.getItem("Token");
	if (token) axios.defaults.headers.common["Authorization"] = `Bearer ${token}`;
}

export default middlewareSettings;
