import { createApp, provide } from 'vue'
import App from './App.vue'
import router from './router/router'
import store from './store/store'
import { middlewareSettings } from './router/axios'
import './main.css'

const user = JSON.parse(localStorage.getItem('User'))

const editRequisitionStates = Object.freeze({
    Issuing: 'issuing',
    Recommendation: 'recommendation',
    Approval: 'approval',
    Edit: 'edit',
    Expenses: 'expenses',
    Close: 'close'
})
const typeOfFile = Object.freeze({
    Motivation: 'motivation',
    Receipt: 'receipt'
})
const typeOfGLGet = Object.freeze({
    All: 'all',
    Division: 'division'
})
const typeOfTransaction = Object.freeze({
    Withdrawal: 'Withdrawal',
    Deposit: 'Deposit'
})
const getRequisitionStates = Object.freeze({
    All: 'all',
    ForOne: 'forOne',
    Recommendation: 'recommendation',
    Approval: 'approval',
    Issuing: 'issuing',
    Receiving: 'receiving',
    Tracking: 'tracking',
    Closing: 'closing'
})

createApp(App)
    .provide('User', user)
    .provide('editRequisitionStates', editRequisitionStates)
    .provide('getRequisitionStates', getRequisitionStates)
    .provide('typeOfFile', typeOfFile)
    .provide('typeOfGLGet', typeOfGLGet)
    .provide('typeOfTransaction', typeOfTransaction)
    .use(store)
    .use(middlewareSettings)
    .use(router)
    .mount('#app')
