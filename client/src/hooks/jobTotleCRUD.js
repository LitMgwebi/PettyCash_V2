import store from '@/store/store'
import axios from 'axios'
import { ref } from 'vue'

export function getJobTitles() {
    store.commit('setLoading')
    const jobTitles = ref([])
    async function getter() {
        try {
            const res = await axios({
                method: 'GET',
                url: 'JobTitles/index'
            })
            jobTitles.value = res.data
        } catch (error) {
            store.dispatch('setStatus', error.response.data)
        } finally {
            store.commit('doneLoading')
        }
    }
    return { jobTitles, getter }
}
