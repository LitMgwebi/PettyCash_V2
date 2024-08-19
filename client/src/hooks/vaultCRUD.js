import store from '@/store/store'
import axios from 'axios'
import { ref } from 'vue'

export function getVault() {
    store.commit('setLoading')
    const vault = ref([])
    async function getter() {
        try {
            const res = await axios({
                method: 'GET',
                url: 'Vaults/details'
            })
            vault.value = res.data
        } catch (error) {
            store.dispatch('setStatus', error.response.data)
        } finally {
            store.commit('doneLoading')
        }
    }

    return { vault, getter }
}
