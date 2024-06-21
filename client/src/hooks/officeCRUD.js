import store from '@/store/index.js'
import axios from 'axios'
import { ref } from 'vue'

export function getOffices() {
    store.commit('setLoading')
    const offices = ref([])
    axios({
        method: 'GET',
        url: 'Offices/index'
    })
        .then((res) => (offices.value = res.data))
        .catch((error) => store.dispatch('setStatus', error.response.data))
        .finally(() => store.commit('doneLoading'))

    return { offices }
}

export const addOffice = (office) => {
    store.commit('setLoading')
    axios({
        method: 'POST',
        url: 'Offices/create',
        data: office
    })
        .then((res) => store.dispatch('setStatus', res.data.message))
        .catch((error) => store.dispatch('setStatus', error.response.data))
        .finally(() => store.commit('doneLoading'))
}

export function editOffice(office) {
    store.commit('setLoading')
    axios({
        method: 'PUT',
        url: 'Offices/edit',
        data: office
    })
        .then((res) => store.dispatch('setStatus', res.data.message))
        .catch((error) => store.dispatch('setStatus', error.response.data))
        .finally(() => store.commit('doneLoading'))
}

export function deleteOffice(office) {
    store.commit('setLoading')
    axios({
        method: 'DELETE',
        url: 'Offices/delete',
        data: office
    })
        .then((res) => store.dispatch('setStatus', res.data.message))
        .catch((error) => store.dispatch('setStatus', error.response.data))
        .finally(() => store.commit('doneLoading'))
}
