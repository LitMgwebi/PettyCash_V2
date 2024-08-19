import store from '@/store/store.js'
import axios from 'axios'
import { ref } from 'vue'

export function getDocuments() {
    store.commit('setLoading')
    const documents = ref([])
    async function getter(command, id) {
        try {
            const res = await axios({
                method: 'GET',
                url: 'Documents/index',
                headers: {
                    'Content-Type': 'multipart/form-data'
                },
                params: {
                    command,
                    requisitionId: id
                }
            })
            documents.value = res.data
        } catch (error) {
            store.dispatch('setStatus', error.response.data)
        } finally {
            store.commit('doneLoading')
        }
    }

    return { documents, getter }
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
