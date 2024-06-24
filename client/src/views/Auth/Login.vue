<template>
	<form @submit.prevent="onSubmit">
		<div><h2>Login</h2></div>
		<label for="email">Email</label>
		<input type="email" v-model="userDetails.email" required />

		<label for="Password">Password</label>
		<input type="password" v-model="userDetails.password" required />

		<div class="submit">
			<button type="submit">Login</button>&nbsp;
			<button>
				<router-link :to="{ name: 'home' }">Cancel</router-link>
			</button>
		</div>
	</form>
</template>
<script setup>
import store from '@/store/index'

const userDetails = {
	email: '',
	password: ''
}
async function onSubmit() {
	await store.dispatch('login', userDetails)
}
</script>