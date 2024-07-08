<template>
	Your departments requests
	<div v-for="requisition in requisitions" :key="requisition.requisitionId">
		<span>
			{{ requisition.applicant.fullName }} - {{ requisition.amountRequested }} -
			{{ requisition.description }}</span
		>
		<span class="dropdown">
			<select :disabled="statuses.length == 0" v-model="requisition.managerRecommendationId">
				<option value="" disabled>What is you're verdict</option>
				<option v-for="status in statuses" :value="status.statusId" :key="status.statusId">
					{{ status.description }}
				</option>
			</select>
		</span>
		<button @click="handleSubmit(requisition)">Approve</button>
	</div>
</template>

<script setup>
import { getRequisitionsForManagerApproval } from '@/hooks/requisitionCRUD'
import { getRecommendationStatuses, editManagerRecommendation } from '@/hooks/statusCRUD'
import { ref } from 'vue'

const { requisitions } = getRequisitionsForManagerApproval()
const { statuses } = getRecommendationStatuses()

const handleSubmit = (requisition) => {
	editManagerRecommendation(requisition)
}
</script>
