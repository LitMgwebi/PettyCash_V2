import router from '@/router/index'
import store from '@/store/index'
import axios from 'axios'

export async function login(userDetails) {
    store.commit('setLoading')
    axios({
        method: 'POST',
        url: 'Users/login',
        data: userDetails
    })
        .then((res) => {
            localStorage.setItem('User', JSON.stringify(res.data.user))
            localStorage.setItem('Token', res.data.jwt.token)
            store.commit('logIn')
            router.push('/dashboard')
            store.dispatch('setStatus', res.data.message)
        })
        .catch((error) => store.dispatch('setStatus', error.response.data))
        .finally(() => store.commit('doneLoading'))
}

export function register(userDetails) {
    store.commit('setLoading')
    axios({
        method: 'POST',
        url: 'Users/register',
        data: userDetails
    })
        .then((res) => {
            store.dispatch('setStatus', res.data.message)
            router.push('/')
        })
        .catch((error) => {
            store.dispatch('setStatus', error.response.data)
            console.log(error)
        })
        .finally(() => {
            store.commit('doneLoading')
        })
}

export function logout() {
    store.commit('setLoading')
    try {
        localStorage.removeItem('Token', null)
        localStorage.removeItem('User', null)
        store.commit('logOut')
        store.dispatch('setStatus', 'You have logged out')
        router.push('/')
    } catch {
        store.dispatch('setStatus', 'System cannot logout. Please contact the ICT department.')
    } finally {
        store.commit('doneLoading')
    }
}
