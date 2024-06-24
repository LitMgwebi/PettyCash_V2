import { createStore } from 'vuex'
import { login as loginFunction } from '@/hooks/userCRUD'
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
                commit('setStatus', status)
                setTimeout(() => {
                    commit('setStatus', null)
                }, 10000)
            } catch (error) {
                console.log(error)
            }
            //  finally {
            //     setTimeout(() => location.reload(), 3000)
            // }
        },
        login: async ({ commit }, userDetails) => {
            commit('setLoading')
            await loginFunction(userDetails)
            commit('logIn')
            commit('doneLoading')
            router.push('/dashboard')
        },
        logout: ({ commit }) => {
            localStorage.removeItem('Token', null)
            localStorage.removeItem('User', null)
            commit('logOut')
            window.location.reload()
            router.push('/')
        }
    },
    modules: {}
})
