<template>
	<nav>
		<span>
			<router-link to="/">Home</router-link> |
			<span v-if="!auth">
				<router-link :to="{ name: 'login' }">Login</router-link> |
				<router-link :to="{ name: 'register' }">Register</router-link> |
			</span>
			<span v-else>
				<router-link to="/dashboard">Dashboard</router-link> |
				<a href="#" @click.prevent="onLogout">Logout</a>
			</span>
		</span>
		<!-- <div v-if="loading">Loading</div> -->
		<div v-if="status">{{ status }}</div>
		<router-view />
	</nav>
</template>

<script setup>
import { computed, inject, onBeforeMount, onMounted, ref } from 'vue'
import store from '@/store/store'

const auth = computed(() => store.state.loggedIn)
const status = computed(() => store.state.status)
const loading = computed(() => store.state.loading)
const onLogout = () => store.dispatch('logout')

const user = inject('User')
onMounted(() => {
	store.dispatch('checkToken')
})
</script>