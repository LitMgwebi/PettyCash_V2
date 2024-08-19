import store from '@/store/store'
import axios from 'axios'
import { ref } from 'vue'

export function getDepartments() {
    store.commit('setLoading')
    const departments = ref([])
    async function getter() {
        try {
            res = await axios({
                method: 'GET',
                url: 'Departments/index'
            })
            departments.value = res.data
        } catch (error) {
            store.dispatch('setStatus', error.response.data)
        } finally {
            store.commit('doneLoading')
        }
    }

    return { departments, getter }
}
