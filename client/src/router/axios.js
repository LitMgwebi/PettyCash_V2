import axios from 'axios'

export function middlewareSettings() {
    axios.defaults.baseURL = 'https://localhost:7167/api/'
    axios.defaults.headers.post['Content-Type'] = 'application/json; charset=utf-8'
    axios.defaults.headers.post['Accept'] = 'application/json'
    axios.defaults.headers.common['Access-Control-Allow-Origin'] = '*'
    const token = localStorage.getItem('Token')
    if (token) axios.defaults.headers.common['Authorization'] = `Bearer ${token}`
}

export function authGuard(to, from, next) {
    if (store.getters.isAuthenticated) {
        next()
    } else {
        router.push('/')
        next()
    }
}
