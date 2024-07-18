<template>
	<h3>Requisitions requiring recommendation</h3>
	<div v-for="requisition in requisitions" :key="requisition.requisitionId">
		<span>
			{{ requisition.applicant.fullName }} - R{{ requisition.amountRequested }} ({{
				requisition.glaccount.name
			}}) - {{ requisition.description }}</span
		>
		<span class="dropdown">
			<select :disabled="statuses.length == 0" v-model="requisition.managerRecommendationId">
				<option value="" disabled>What is you're verdict</option>
				<option v-for="status in statuses" :value="status.statusId" :key="status.statusId">
					{{ status.description }}
				</option>
			</select>
		</span>
		<span v-if="requisition.managerRecommendationId == 4">
			<label>Would you like to leave a comment?: </label>
			<textarea v-model="requisition.managerComment" />
		</span>
		<button @click="handleSubmit(requisition)">Submit</button>
	</div>
</template>

<script setup>
import { getRequisitions, editRequisition } from '@/hooks/requisitionCRUD'
import { getRecommendationStatuses } from '@/hooks/statusCRUD'
import { ref } from 'vue'

const { requisitions } = getRequisitions('recommendation')
const { statuses } = getRecommendationStatuses()

const handleSubmit = (requisition) => {
	editRequisition(requisition, 'recommendation')
}
</script>
