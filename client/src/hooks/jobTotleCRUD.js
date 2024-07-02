import store from '@/store/store'
import axios from 'axios'
import { ref } from 'vue'

export function getJobTitles() {
    store.commit('setLoading')
    const jobTitles = ref([])
    axios({
        method: 'GET',
        url: 'JobTitles/index'
    })
        .then((res) => (jobTitles.value = res.data))
        .catch((error) => store.dispatch('setStatus', error.response.data))
        .finally(() => store.commit('doneLoading'))

    return { jobTitles }
}
