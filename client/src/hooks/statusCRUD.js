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

export function getApprovalRecommendations() {
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
