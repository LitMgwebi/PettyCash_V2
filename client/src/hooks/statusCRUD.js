import store from '@/store/store.js'
import axios from 'axios'
import { ref } from 'vue'

export function getApprovalStatuses() {
    store.commit('setLoading')
    const statuses = ref([])
    async function approvalGetter() {
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
    return { statuses, approvalGetter }
}

export function getRecommendationStatuses() {
    store.commit('setLoading')
    const statuses = ref([])
    async function recommendationGetter() {
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
    return { statuses, recommendationGetter }
}

export function getStatesStatuses() {
    store.commit('setLoading')
    const statuses = ref([])
    async function stateGetter() {
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
    return { statuses, stateGetter }
}

export function getAllStatuses() {
    store.commit('setLoading')
    const statuses = ref([])
    async function allGetter() {
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
    return { statuses, allGetter }
}
