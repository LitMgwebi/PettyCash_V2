import axios from 'axios'
import { ref } from 'vue'
import store from '@/store/index'

function getPurposes() {
    store.commit('setLoading')
    const purposes = ref([])
    axios({
        method: 'GET',
        url: 'Purposes/index'
    })
        .then((res) => {
            purposes.value = res.data
        })
        .catch((error) => {
            store.dispatch('setStatus', error.response.data)
        })
        .finally(() => {
            store.commit('doneLoading')
        })

    return { purposes }
}

function editPurpose(purpose) {
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

function addPurpose(purpose) {
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

function deletePurpose(purpose) {
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

export { getPurposes, editPurpose, addPurpose, deletePurpose }
