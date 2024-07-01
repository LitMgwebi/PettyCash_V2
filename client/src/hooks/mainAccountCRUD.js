import store from '@/store/store.js'
import axios from 'axios'
import { ref } from 'vue'

export function getMainAccounts() {
    store.commit('setLoading')
    const mainAccounts = ref([])
    axios({
        method: 'GET',
        url: 'MainAccounts/index'
    })
        .then((res) => (mainAccounts.value = res.data))
        .catch((error) => store.dispatch('setStatus', error.response.data))
        .finally(() => store.commit('doneLoading'))

    return { mainAccounts }
}

export function addMainAccount(mainAccount) {
    store.commit('setLoading')
    axios({
        method: 'POST',
        url: 'MainAccounts/create',
        data: mainAccount
    })
        .then((res) => store.dispatch('setStatus', res.data.message))
        .catch((error) => store.dispatch('setStatus', error.response.data))
        .finally(() => store.commit('doneLoading'))
}

export function editMainAccount(mainAccount) {
    store.commit('setLoading')
    axios({
        method: 'PUT',
        url: 'MainAccounts/edit',
        data: mainAccount
    })
        .then((res) => store.dispatch('setStatus', res.data.message))
        .catch((error) => store.dispatch('setStatus', error.response.data))
        .finally(() => store.commit('doneLoading'))
}

export function deleteMainAccount(mainAccount) {
    store.commit('setLoading')
    axios({
        method: 'DELETE',
        url: 'MainAccounts/delete',
        data: mainAccount
    })
        .then((res) => store.dispatch('setStatus', res.data.message))
        .catch((error) => store.dispatch('setStatus', error.response.data))
        .finally(() => store.commit('doneLoading'))
}
