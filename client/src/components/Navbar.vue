<template>
	<nav>
		<span>
			<router-link to="/">Home</router-link> |
			<span v-if="auth">
				<router-link to="/dashboard">Dashboard</router-link> |
				<span v-if="user.role == Admin">
					<router-link to="/purposes">Purposes</router-link> |
					<router-link to="/departments">Departments</router-link> |
					<router-link to="/sub_accounts">Sub-Accounts</router-link> |
					<router-link to="/main_accounts">Main Accounts</router-link> |
					<router-link to="/gl_accounts">GL Accounts</router-link> |
					<router-link to="/offices">Offices</router-link> |
				</span>
				<a href="#" @click.prevent="onLogout">Logout</a>
			</span>
			<span v-else>
				<router-link :to="{ name: 'login' }">Login</router-link> |
				<router-link :to="{ name: 'register' }">Register</router-link> |
			</span>
		</span>
		<div v-if="loading">Loading</div>
		<div v-if="status">{{ status }}</div>
		<router-view />
	</nav>
</template>

<script setup>
import { computed, inject } from 'vue'
import store from '@/store/index'

const auth = computed(() => store.state.loggedIn)
const status = computed(() => store.state.status)
const loading = computed(() => store.state.loading)
const onLogout = () => store.dispatch('logout')

const user = inject('User')
</script>