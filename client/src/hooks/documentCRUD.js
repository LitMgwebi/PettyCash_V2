import store from '@/store/store.js'
import axios from 'axios'
import { ref } from 'vue'

export function getDocuments(command, id) {
    store.commit('setLoading')
    const documents = ref()
    axios({
        method: 'GET',
        url: 'Documents/index',
        params: {
            command,
            requisitionId: id
        }
    })
        .then((res) => (documents.value = res.data))
        .catch((error) => store.dispatch('setStatus', error.response.data))
        .finally(() => store.commit('doneLoading'))

    return { documents }
}

export function addDocument(File, id, command) {
    store.commit('setLoading')
    axios({
        method: 'POST',
        url: 'Documents/create',
        data: {
            command,
            File: File.append,
            requisitionId: id
        },
        headers: {
            'Content-Type': 'multipart/form-data'
        }
    })
        .then((res) => store.dispatch('setStatus', res.data.message))
        .catch((error) => store.dispatch('setStatus', error.response.data))
        .finally(() => store.commit('doneLoading'))
}

export function deleteDocument(document) {
    store.commit('setLoading')
    axios({
        method: 'DELETE',
        url: 'Documents/delete',
        data: document
    })
        .then((res) => store.dispatch('setStatus', res.data.message))
        .catch((error) => store.dispatch('setStatus', error.response.data))
        .finally(() => store.commit('doneLoading'))
}
