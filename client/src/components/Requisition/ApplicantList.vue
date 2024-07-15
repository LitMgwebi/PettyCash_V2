<template>
	Your Requisitions
	<div v-for="requisition in requisitions" :key="requisition.requisitionId">
		<span>
			{{ requisition.description }} - {{ requisition.amountRequested }} -
			{{ requisition.stage }}
			<span v-if="requisition.managerComment">- {{ requisition.managerComment }}</span>
			<span v-if="requisition.financeComment">- {{ requisition.financeComment }}</span>
		</span>
		<button @click="populateEdit(requistion)">Edit</button>
		<button @click="deleteRecord(requistion)">Delete</button>
	</div>
</template>

<script setup>
import { getRequisitions } from '@/hooks/requisitionCRUD'
import { inject } from 'vue'

const { requisitions } = getRequisitions('applicant')
</script>