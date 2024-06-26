import { createStore } from 'vuex'
import { login as loginFunction, logout } from '@/hooks/userCRUD'
import router from '@/router'

export default createStore({
    state: {
        status: null,
        loading: false,
        loggedIn: false
    },
    getters: {
        isAuthenticated: () => {
            const token = localStorage.getItem('Token')

            if (token != null || token != undefined) {
                if (token.length > 0) return true
                else return true
            } else return false
        }
    },
    mutations: {
        setStatus: (state, status) => (state.status = status),
        clearStatus: (state) => (state.status = ''),
        setLoading: (state) => (state.loading = true),
        doneLoading: (state) => (state.loading = false),
        logIn: (state) => (state.loggedIn = true),
        logOut: (state) => (state.loggedIn = false)
    },
    actions: {
        setStatus: ({ commit }, status) => {
            try {
                // location.reload()
                // setTimeout(() => location.reload(), 2500)
            } catch (error) {
                commit('setStatus', error)
            } finally {
                commit('setStatus', status)
                setTimeout(() => {
                    commit('setStatus', null)
                }, 5000)
            }
        },
        login: async ({ commit }, userDetails) => {
            try {
                await loginFunction(userDetails)
            } catch {
                return
            }
        },
        logout: () => {
            try {
                logout()
            } catch {
                return
            }
        },
        checkToken: ({ commit }) => {
            const token = localStorage.getItem('Token')
            if (token != null || token != undefined) {
                if (token.length > 0) commit('logIn')
                else commit('logOut')
            } else commit('logOut')
        }
    },
    modules: {}
})
