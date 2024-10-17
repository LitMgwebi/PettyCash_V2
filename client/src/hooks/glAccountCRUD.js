import store from '@/store/store'
import axios from 'axios'
import { ref } from 'vue'

export function getGLAccounts() {
    store.commit('setLoading')
    const glAccounts = ref([])
    async function getter(command, divisionId = 0) {
        try {
            const res = await axios({
                method: 'GET',
                url: 'GLAccounts/index',
                params: {
                    command: command,
                    divisionId: divisionId
                }
            })
            glAccounts.value = res.data
        } catch (error) {
            store.dispatch('setStatus', error.response.data)
        } finally {
            store.commit('doneLoading')
        }
    }

    return { glAccounts, getter }
}

export function getGLAccount() {
    store.commit('setLoading')
    const glAccount = ref(null)
    async function getter(id) {
        try {
            const res = await axios({
                method: 'GET',
                url: 'GLAccounts/details',
                params: {
                    id
                }
            })
            glAccount.value = res.data
        } catch (error) {
            store.dispatch('setStatus', error.response.data)
        } finally {
            store.commit('doneLoading')
        }
    }

    return { glAccount, getter }
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
