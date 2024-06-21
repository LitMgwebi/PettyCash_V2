import store from '@/store/index'
import axios from 'axios'
import { ref } from 'vue'

export function getDepartments() {
    store.commit('setLoading')
    const departments = ref([])
    axios({
        method: 'GET',
        url: 'Departments/index'
    })
        .then((res) => (departments.value = res.data))
        .catch((error) => store.dispatch('setStatus', error.response.data))
        .finally(() => store.commit('doneLoading'))

    return { departments }
}

export function addDepartment(department) {
    store.commit('setLoading')
    axios({
        method: 'POST',
        url: 'Departments/create',
        data: department
    })
        .then((res) => store.dispatch('setStatus', res.data.message))
        .catch((error) => store.dispatch('setStatus', error.response.data))
        .finally(() => store.commit('doneLoading'))
}

export function editDepartment(department) {
    store.commit('setLoading')
    axios({
        method: 'PUT',
        url: 'Departments/edit',
        data: department
    })
        .then((res) => store.dispatch('setStatus', res.data.message))
        .catch((error) => store.dispatch('setStatus', error.response.data))
        .finally(() => store.commit('doneLoading'))
}

export function deleteDepartment(department) {
    store.commit('setLoading')
    axios({
        method: 'DELETE',
        url: 'Departments/delete',
        data: department
    })
        .then((res) => store.dispatch('setStatus', res.data.message))
        .catch((error) => store.dispatch('setStatus', error.response.data))
        .finally(() => store.commit('doneLoading'))
}
