<template>
	<h2>Petty Cash Requests</h2>

	<router-link :to="{ name: 'requistion_create' }" custom v-slot="{ navigate }">
		<button @click="navigate" role="link">Create</button>
	</router-link>
	<div>
		<ApplicantList />
	</div>
</template>

<script setup>
import ApplicantList from '@/components/Requisition/ApplicantList.vue'
</script>