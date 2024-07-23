import store from '@/store/store.js'
import axios from 'axios'
import { ref } from 'vue'

export function addMotivation(File) {
    store.commit('setLoading')
    console.log(File.append)
    axios({
        method: 'POST',
        url: 'Motivations/create',
        data: { File: File.append, id: 40 },
        headers: {
            'Content-Type': 'multipart/form-data'
        }
    })
        .then((res) => store.dispatch('setStatus', res.data.message))
        // .catch((error) => store.dispatch('setStatus', error.response.data))
        .catch((error) => console.log(error.response))
        .finally(() => store.commit('doneLoading'))
}
