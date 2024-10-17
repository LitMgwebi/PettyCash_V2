import axios from 'axios'
import { ref } from 'vue'
import store from '@/store/store'

export function getPurposes() {
    store.commit('setLoading')
    const purposes = ref([])
    async function getter() {
        try {
            const res = await axios({
                method: 'GET',
                url: 'Purposes/index'
            })
            purposes.value = res.data
        } catch (error) {
            store.dispatch('setStatus', error.response.data)
        } finally {
            store.commit('doneLoading')
        }
    }
    return { purposes, getter }
}

export function editPurpose(purpose) {
    store.commit('setLoading')
    axios({
        method: 'PUT',
        url: 'Purposes/edit',
        data: purpose
    })
        .then((res) => {
            store.dispatch('setStatus', res.data.message)
        })
        .catch((error) => {
            store.dispatch('setStatus', error.response.data)
        })
        .finally(() => {
            store.commit('doneLoading')
        })
}

export function addPurpose(purpose) {
    store.commit('setLoading')
    axios({
        method: 'POST',
        url: 'Purposes/create',
        data: purpose
    })
        .then((res) => {
            store.dispatch('setStatus', res.data.message)
        })
        .catch((error) => {
            store.dispatch('setStatus', error.response.data)
        })
        .finally(() => {
            store.commit('doneLoading')
        })
}

export function deletePurpose(purpose) {
    store.commit('setLoading')
    axios({
        method: 'DELETE',
        url: 'Purposes/delete',
        data: purpose
    })
        .then((res) => {
            store.dispatch('setStatus', res.data.message)
        })
        .catch((error) => {
            store.dispatch('setStatus', error.response.data)
        })
        .finally(() => {
            store.commit('doneLoading')
        })
}
