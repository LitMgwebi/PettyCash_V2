import store from '@/store/index.js'
import axios from 'axios'
import { ref } from 'vue'

export function getSubAccounts() {
    store.commit('setLoading')
    const subAccounts = ref([])
    axios({
        method: 'GET',
        url: 'SubAccounts/index'
    })
        .then((res) => (subAccounts.value = res.data))
        .catch((error) => store.dispatch('setStatus', error.response.data))
        .finally(() => store.commit('doneLoading'))

    return { subAccounts }
}

export const addSubAccount = (subAccount) => {
    store.commit('setLoading')
    axios({
        method: 'POST',
        url: 'SubAccounts/create',
        data: subAccount
    })
        .then((res) => store.dispatch('setStatus', res.data.message))
        .catch((error) => store.dispatch('setStatus', error.response.data))
        .finally(() => store.commit('doneLoading'))
}

export function editSubAccount(subAccount) {
    store.commit('setLoading')
    axios({
        method: 'PUT',
        url: 'SubAccounts/edit',
        data: subAccount
    })
        .then((res) => store.dispatch('setStatus', res.data.message))
        .catch((error) => store.dispatch('setStatus', error.response.data))
        .finally(() => store.commit('doneLoading'))
}

export const deleteSubAccount = (subAccount) => {
    store.commit('setLoading')
    axios({
        method: 'DELETE',
        url: 'SubAccounts/delete',
        data: subAccount
    })
        .then((res) => store.dispatch('setStatus', res.data.message))
        .catch((error) => store.dispatch('setStatus', error.response.data))
        .finally(() => store.commit('doneLoading'))
}
