<template>
	Your departments requests
	<div v-for="requisition in requisitions" :key="requisition.requisitionId">
		<span>
			{{ requisition.applicant.fullName }} - {{ requisition.amountRequested }} -
			{{ requisition.description }}</span
		>
		<button @click="requisitionApproval('approve')">Approve</button>
		<button @click="requisitionApproval('decline')">Decline</button>
	</div>
</template>

<script setup>
import { getRequisitionsForManagerApproval } from '@/hooks/requisitionCRUD'

const { requisitions } = getRequisitionsForManagerApproval()

const requisitionApproval = (answer) => {
	console.log(answer)
}
</script>
