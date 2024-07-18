<template>
	<div>
		<h3>Requests for you to approve</h3>
		<div v-for="requisition in requisitions" :key="requisition.requisitionId">
			<span>
				{{ requisition.applicant.fullName }} - R{{ requisition.amountRequested }} ({{
					requisition.glaccount.name
				}})- {{ requisition.description }}</span
			>
			<span class="dropdown">
				<select :disabled="statuses.length == 0" v-model="requisition.financeApprovalID">
					<option value="" disabled>What is you're verdict</option>
					<option
						v-for="status in statuses"
						:value="status.statusId"
						:key="status.statusId"
					>
						{{ status.description }}
					</option>
				</select>
			</span>
			<span v-if="requisition.financeApprovalID == 2">
				<label>Would you like to leave a comment?: </label>
				<textarea v-model="requisition.financeComment" />
			</span>
			<button @click="handleApproval(requisition)">Submit</button>
		</div>
	</div>
</template>

<script setup>
import { getRequisitions, editRequisition } from '@/hooks/requisitionCRUD'
import { getApprovalStatuses, getRecommendationStatuses } from '@/hooks/statusCRUD'
import { ref } from 'vue'
import { inject } from 'vue'

const user = inject('User')

const { requisitions } = getRequisitions('approval')
const { statuses } = getApprovalStatuses()

const handleApproval = (requisition) => {
	editRequisition(requisition, 'approval')
}
</script>
