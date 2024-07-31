<template>
	<div v-if="user">
		<h3>Welcome {{ user.fullName }}</h3>
	</div>
</template>

<script setup>
import { inject, ref } from 'vue'
const user = inject('User')
</script>