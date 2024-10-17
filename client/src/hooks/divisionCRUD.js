import store from '@/store/store'
import axios from 'axios'
import { ref } from 'vue'

export function getDivisions() {
    store.commit('setLoading')
    const divisions = ref([])
    async function getter() {
        try {
            const res = await axios({
                method: 'GET',
                url: 'Divisions/index'
            })
            divisions.value = res.data
        } catch (error) {
            store.dispatch('setStatus', error.response.data)
        } finally {
            store.commit('doneLoading')
        }
    }

    return { divisions, getter }
}

export function addDivision(division) {
    store.commit('setLoading')
    axios({
        method: 'POST',
        url: 'Divisions/create',
        data: division
    })
        .then((res) => store.dispatch('setStatus', res.data.message))
        .catch((error) => store.dispatch('setStatus', error.response.data))
        .finally(() => store.commit('doneLoading'))
}

export function editDivision(division) {
    store.commit('setLoading')
    axios({
        method: 'PUT',
        url: 'Divisions/edit',
        data: division
    })
        .then((res) => store.dispatch('setStatus', res.data.message))
        .catch((error) => store.dispatch('setStatus', error.response.data))
        .finally(() => store.commit('doneLoading'))
}

export function deleteDivision(division) {
    store.commit('setLoading')
    axios({
        method: 'DELETE',
        url: 'Divisions/delete',
        data: division
    })
        .then((res) => store.dispatch('setStatus', res.data.message))
        .catch((error) => store.dispatch('setStatus', error.response.data))
        .finally(() => store.commit('doneLoading'))
}
