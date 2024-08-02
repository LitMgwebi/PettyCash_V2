import store from '@/store/store'
import axios from 'axios'
import { ref } from 'vue'

export function getVault() {
    store.commit('setLoading')
    const vault = ref(null)
    axios({
        method: 'GET',
        url: 'Vaults/details'
    })
        .then((res) => (vault.value = res.data))
        .catch((error) => store.dispatch('setStatus', error.response.data))
        .finally(() => store.commit('doneLoading'))

    return { vault }
}
