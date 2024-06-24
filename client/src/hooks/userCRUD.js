import router from '@/router'
import store from '@/store'
import axios from 'axios'

export async function login(userDetails) {
    store.commit('setLoading')
    axios({
        method: 'POST',
        url: 'Users/login',
        data: userDetails
    })
        .then((res) => {
            console.log(res.data)
            localStorage.setItem('User', JSON.stringify(res.data.user))
            localStorage.setItem('Token', res.data.jwt.token)
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
            // localStorage.setItem('User', JSON.stringify(res.data.user))
            // localStorage.setItem('Token', res.data.jwt.token)
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
