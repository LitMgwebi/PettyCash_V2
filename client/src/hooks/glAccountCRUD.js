import store from '@/store/store'
import axios from 'axios'
import { ref } from 'vue'

export function getGLAccounts() {
    store.commit('setLoading')
    const glAccounts = ref([])
    axios({
        method: 'GET',
        url: 'GLAccounts/index'
    })
        .then((res) => (glAccounts.value = res.data))
        .catch((error) => store.dispatch('setStatus', error.response.data))
        .finally(() => store.commit('doneLoading'))

    return { glAccounts }
}

export function getGLAccountsByDepartment() {
    store.commit('setLoading')
    const glAccounts = ref([])
    axios({
        method: 'GET',
        url: 'GLAccounts/index_department'
    })
        .then((res) => (glAccounts.value = res.data))
        .catch((error) => store.dispatch('setStatus', error.response.data))
        .finally(() => store.commit('doneLoading'))

    return { glAccounts }
}

export function addGLAccount(glAccount) {
    store.commit('setLoading')
    axios({
        method: 'POST',
        url: 'GLAccounts/create',
        data: glAccount
    })
        .then((res) => store.dispatch('setStatus', res.data.message))
        .catch((error) => store.dispatch('setStatus', error.response.data))
        .finally(() => store.commit('doneLoading'))
}

export function editGLAccount(glAccount) {
    store.commit('setLoading')
    axios({
        method: 'PUT',
        url: 'GLAccounts/edit',
        data: glAccount
    })
        .then((res) => store.dispatch('setStatus', res.data.message))
        .catch((error) => store.dispatch('setStatus', error.response.data))
        .finally(() => store.commit('doneLoading'))
}

export function deleteGLAccount(glAccount) {
    store.commit('setLoading')
    axios({
        method: 'DELETE',
        url: 'GLAccounts/delete',
        data: glAccount
    })
        .then((res) => store.dispatch('setStatus', res.data.message))
        .catch((error) => store.dispatch('setStatus', error.response.data))
        .finally(() => store.commit('doneLoading'))
}
