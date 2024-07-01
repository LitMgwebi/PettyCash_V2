import { createApp, provide } from 'vue'
import App from './App.vue'
import router from './router/router'
import store from './store/store'
import { middlewareSettings } from './router/axios'
import './main.css'

const user = JSON.parse(localStorage.getItem('User'))

createApp(App).provide('User', user).use(store).use(middlewareSettings).use(router).mount('#app')
