import store from '@/store/store.js'
import axios from 'axios'
import { ref } from 'vue'

export function getMotivations(id) {
    store.commit('setLoading')
    const motivations = ref()
    axios({
        method: 'GET',
        url: 'Motivations/index',
        params: {
            requisitionId: id
        }
    })
        .then((res) => (motivations.value = res.data))
        .catch((error) => store.dispatch('setStatus', error.response.data))
        .finally(() => store.commit('doneLoading'))

    return { motivations }
}

export function addMotivation(File, id) {
    store.commit('setLoading')
    // console.log(File.append, id)
    axios({
        method: 'POST',
        url: 'Motivations/create',
        data: { File: File.append, requisitionId: id },
        headers: {
            'Content-Type': 'multipart/form-data'
        }
    })
        .then((res) => store.dispatch('setStatus', res.data.message))
        .catch((error) => store.dispatch('setStatus', error.response.data))
        .finally(() => store.commit('doneLoading'))
}
