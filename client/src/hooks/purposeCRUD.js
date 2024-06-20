import axios from "axios";
import { ref } from "vue";
import store from "@/store/index";

function getPurposes() {
	const purposes = ref([]);

	axios({
		method: "GET",
		url: "Purposes/index",
	})
		.then((res) => {
			purposes.value = res.data;
		})
		.catch((error) => {
			store.dispatch("setStatus", error.response.data);
		});

	return { purposes };
}

function editPurpose(purpose) {
	axios({
		method: "PUT",
		url: "Purposes/edit",
		data: purpose,
	})
		.then((res) => {
			store.dispatch("setStatus", res.message);
		})
		.catch((error) => {
			store.dispatch("setStatus", error.response.data);
		});
}

function addPurpose(purpose) {
	axios({
		method: "POST",
		url: "Purposes/create",
		data: purpose,
	})
		.then((res) => {
			store.dispatch("setStatus", res.message);
		})
		.catch((error) => {
			store.dispatch("setStatus", error.response.data);
		});
}

function deletePurpose(purpose) {
	axios({
		method: "DELETE",
		url: "Purposes/delete",
		data: purpose,
	})
		.then((res) => {
			store.dispatch("setStatus", res.message);
		})
		.catch((error) => {
			store.dispatch("setStatus", error.response.data);
		});
}

export { getPurposes, editPurpose, addPurpose, deletePurpose };
