import store from '@/store/store.js'
import axios from 'axios'
import { ref } from 'vue'

export function getRequisitions(command) {
    store.commit('setLoading')
    const requisitions = ref([])
    axios({
        method: 'GET',
        url: 'Requisitions/index',
        params: {
            command: command
        }
    })
        .then((res) => (requisitions.value = res.data))
        .catch((error) => store.dispatch('setStatus', error.response.data))
        .finally(() => store.commit('doneLoading'))

    return { requisitions }
}

export function getRequisition(id) {
    store.commit('setLoading')
    const requisition = ref(null)
    axios({
        method: 'GET',
        url: 'Requisitions/details',
        params: {
            id: id
        }
    })
        .then((res) => (requisition.value = res.data))
        .catch((error) => store.dispatch('setStatus', error.response.data))
        .finally(() => store.commit('doneLoading'))

    return { requisition }
}

export function addRequisition(requisition) {
    store.commit('setLoading')
    axios({
        method: 'POST',
        url: 'Requisitions/create',
        data: requisition
    })
        .then((res) => store.dispatch('setStatus', res.data.message))
        .catch((error) => store.dispatch('setStatus', error.response.data))
        .finally(() => store.commit('doneLoading'))
}

export function editRequisition(requisition, command) {
    store.commit('setLoading')
    axios({
        method: 'PUT',
        url: 'Requisitions/edit',
        data: {
            requisition: requisition,
            command: command
        }
    })
        .then((res) => store.dispatch('setStatus', res.data.message))
        .catch((error) => store.dispatch('setStatus', error.response.data))
        .finally(() => store.commit('doneLoading'))
}

export function deleteRequisition(requisition) {
    store.commit('setLoading')
    axios({
        method: 'DELETE',
        url: 'Requisition/delete',
        data: requisition
    })
        .then((res) => store.dispatch('setStatus', res.data.message))
        .catch((error) => store.dispatch('setStatus', error.response.data))
        .finally(() => store.commit('doneLoading'))
}
