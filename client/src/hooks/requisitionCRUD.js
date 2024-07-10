import store from '@/store/store.js'
import axios from 'axios'
import { ref } from 'vue'

export function getRequisitions() {
    store.commit('setLoading')
    const requisitions = ref([])
    axios({
        method: 'GET',
        url: 'Requisitions/index'
    })
        .then((res) => (requisitions.value = res.data))
        .catch((error) => store.dispatch('setStatus', error.response.data))
        .finally(() => store.commit('doneLoading'))

    return { requisitions }
}

export function getRequisitionsByApplicant() {
    store.commit('setLoading')
    const requisitions = ref([])
    axios({
        method: 'GET',
        url: 'Requisitions/applicant_index'
    })
        .then((res) => (requisitions.value = res.data))
        .catch((error) => store.dispatch('setStatus', error.response.data))
        .finally(() => store.commit('doneLoading'))

    return { requisitions }
}

export function getRequisitionsForManagerApproval() {
    store.commit('setLoading')
    const requisitions = ref([])
    axios({
        method: 'GET',
        url: 'Requisitions/manager_index'
    })
        .then((res) => (requisitions.value = res.data))
        .catch((error) => store.dispatch('setStatus', error.response.data))
        .finally(() => store.commit('doneLoading'))

    return { requisitions }
}

export function getRequisitionsForFinanceApproval() {
    store.commit('setLoading')
    const requisitions = ref([])
    axios({
        method: 'GET',
        url: 'Requisitions/finance_index'
    })
        .then((res) => (requisitions.value = res.data))
        .catch((error) => store.dispatch('setStatus', error.response.data))
        .finally(() => store.commit('doneLoading'))

    return { requisitions }
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

export function editRequisition(requisition) {
    store.commit('setLoading')
    axios({
        method: 'PUT',
        url: 'Requisition/edit',
        data: requisition
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
