import store from '@/store/store.js'
import axios from 'axios'
import { ref } from 'vue'

export function getApprovalStatuses() {
    store.commit('setLoading')
    const statuses = ref([])
    async function getter() {
        try {
            const res = await axios({
                method: 'GET',
                url: 'Statuses/get_approved'
            })
            statuses.value = res.data
        } catch (error) {
            store.dispatch('setStatus', error.response.data)
        } finally {
            store.commit('doneLoading')
        }
    }
    return { statuses, getter }
}

export function getRecommendationStatuses() {
    store.commit('setLoading')
    const statuses = ref([])
    async function getter() {
        try {
            const res = await axios({
                method: 'GET',
                url: 'Statuses/get_recommended'
            })
            statuses.value = res.data
        } catch (error) {
            store.dispatch('setStatus', error.response.data)
        } finally {
            store.commit('doneLoading')
        }
    }
    return { statuses, getter }
}

export function getStatesStatuses() {
    store.commit('setLoading')
    const statuses = ref([])
    async function getter() {
        try {
            const res = await axios({
                method: 'GET',
                url: 'Statuses/get_requisition_states'
            })
            statuses.value = res.data
        } catch (error) {
            store.dispatch('setStatus', error.response.data)
        } finally {
            store.commit('doneLoading')
        }
    }
    return { statuses, getter }
}

export function getAllStatuses() {
    store.commit('setLoading')
    const statuses = ref([])
    async function getter() {
        try {
            const res = await axios({
                method: 'GET',
                url: 'Statuses/index'
            })
            statuses.value = res.data
        } catch (error) {
            store.dispatch('setStatus', error.response.data)
        } finally {
            store.commit('doneLoading')
        }
    }
    return { statuses, getter }
}
