import { createStore } from 'vuex'

export default createStore({
    state: {
        status: null,
        loading: false
    },
    getters: {},
    mutations: {
        setStatus: (state, status) => (state.status = status),
        clearStatus: (state) => (state.status = ''),
        setLoading: (state) => (state.loading = true),
        doneLoading: (state) => (state.loading = false)
    },
    actions: {
        setStatus: ({ commit }, status) => {
            try {
                commit('setStatus', status)
                setTimeout(() => {
                    commit('setStatus', null)
                }, 10000)
            } catch (error) {
                console.log(error)
            } finally {
                location.reload()
            }
        }
    },
    modules: {}
})
