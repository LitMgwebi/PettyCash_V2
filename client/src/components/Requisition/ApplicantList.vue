<template>
	hi
	<div v-for="requisition in requisitions" :key="requisition.requisitionId">
		<span> {{ requisition.description }} - {{ requisition.amountRequested }} </span>
		<button @click="populateEdit(requistion)">Edit</button>
		<button @click="deleteRecord(requistion)">Delete</button>
	</div>
</template>

<script setup>
import { getRequisitionsByApplicant, getRequisitions } from '@/hooks/requisitionCRUD'
import { inject } from 'vue'

const user = inject('User')
const { requisitions } = getRequisitionsByApplicant(user.id)
</script>