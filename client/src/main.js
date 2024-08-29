import { createApp, provide } from 'vue'
import App from './App.vue'
import router from './router/router'
import store from './store/store'
import { middlewareSettings } from './router/axios'
import './main.css'
import 'vuetify/styles'
import { createVuetify } from 'vuetify/lib/framework.mjs'
import * as components from 'vuetify/components'
import * as directives from 'vuetify/directives'

const user = JSON.parse(localStorage.getItem('User'))
const vuetify = createVuetify({
    components,
    directives
})
//#region Enums used for commands to server

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
    Deposit: 'Deposit',
    All: 'All',
    Change: 'Change'
})
const getRequisitionStates = Object.freeze({
    All: 'all',
    ForOne: 'forOne',
    Recommendation: 'recommendation',
    Approval: 'approval',
    Opened: 'open',
    Issued: 'issue',
    Returned: 'return',
    Receiving: 'receiving',
    Tracking: 'tracking',
    Closing: 'closing'
})
const issuedRequisitionState = Object.freeze({
    Red: 'red',
    Green: 'green'
})
//#endregion

createApp(App)
    .provide('User', user)
    .provide('editRequisitionStates', editRequisitionStates)
    .provide('getRequisitionStates', getRequisitionStates)
    .provide('typeOfFile', typeOfFile)
    .provide('typeOfGLGet', typeOfGLGet)
    .provide('typeOfTransaction', typeOfTransaction)
    .provide('issuedRequisitionState', issuedRequisitionState)
    .use(store)
    .use(middlewareSettings)
    .use(router)
    .use(vuetify)
    .mount('#app')
