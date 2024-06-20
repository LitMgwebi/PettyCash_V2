import { createStore } from "vuex";

export default createStore({
	state: {
		status: "",
	},
	getters: {},
	mutations: {
		setStatus: (state, status) => (state.status = status),
		clearStatus: (state) => (state.status = ""),
		setLoading: (state) => (state.loading = !state.loading),
	},
	actions: {
		setStatus: ({ commit }, status) => {
			commit("setStatus", status);
		},
	},
	modules: {},
});
