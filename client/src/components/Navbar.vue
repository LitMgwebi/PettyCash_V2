<template>
	<nav>
		<span>
			<router-link to="/">Home</router-link> | <router-link to="/about">About</router-link> |
			<router-link to="/purposes">Purposes</router-link> |
			<router-link to="/departments">Departments</router-link> |
			<router-link to="/offices">Offices</router-link>
		</span>
		<div v-if="loading">Loading</div>
		<div v-if="status">{{ status }}</div>
		<router-view />
	</nav>
</template>

<script setup>
import { computed } from 'vue'
import store from '@/store/index'

const status = computed(() => store.state.status)
const loading = computed(() => store.state.loading)
</script>