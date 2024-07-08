import store from '@/store/store.js'
import axios from 'axios'
import { ref } from 'vue'

export function getApprovalStatuses() {
    store.commit('setLoading')
    const statuses = ref([])
    axios({
        method: 'GET',
        url: 'Statuses/get_approved'
    })
        .then((res) => (statuses.value = res.data))
        .catch((error) => store.dispatch('setStatus', error.response.data))
        .finally(() => store.commit('doneLoading'))

    return { statuses }
}

export function getRecommendationStatuses() {
    store.commit('setLoading')
    const statuses = ref([])
    axios({
        method: 'GET',
        url: 'Statuses/get_recommended'
    })
        .then((res) => (statuses.value = res.data))
        .catch((error) => store.dispatch('setStatus', error.response.data))
        .finally(() => store.commit('doneLoading'))

    return { statuses }
}

export function editManagerRecommendation(requisition) {
    store.commit('setLoading')
    axios({
        method: 'PUT',
        url: 'Requisitions/manager_recommendation',
        data: requisition
    })
        .then((res) => store.dispatch('setStatus', res.data.message))
        .catch((error) => store.dispatch('setStatus', error.response.data))
        .finally(() => store.commit('doneLoading'))
}
