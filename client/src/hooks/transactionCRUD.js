import store from '@/store/store'
import axios from 'axios'
import { ref } from 'vue'

export function getTransactions() {
    store.commit('setLoading')
    const transactions = ref([])
    async function getter(type) {
        try {
            const res = await axios({
                method: 'GET',
                url: 'Transactions/index',
                params: {
                    type
                }
            })
            transactions.value = res.data
        } catch (error) {
            store.dispatch('setStatus', error.response.data)
        } finally {
            store.commit('doneLoading')
        }
    }

    return { transactions, getter }
}

export function getTransaction() {
    store.commit('setLoading')
    const transaction = ref(null)
    axios({
        method: 'GET',
        url: 'Transactions/details'
    })
        .then((res) => (transaction.value = res.data))
        .catch((error) => store.dispatch('setStatus', error.response.data))
        .finally(() => store.commit('doneLoading'))

    return { transaction }
}

export function addTransaction(transactions) {
    store.commit('setLoading')
    axios({
        method: 'POST',
        url: 'Transactions/create',
        data: transactions
    })
        .then((res) => store.dispatch('setStatus', res.data.message))
        .catch((error) => store.dispatch('setStatus', error.response.data))
        .finally(() => store.commit('doneLoading'))
}
