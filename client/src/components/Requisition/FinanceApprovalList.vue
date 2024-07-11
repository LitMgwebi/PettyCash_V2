<template>
	Requests for you to approve
	<div v-for="requisition in requisitions" :key="requisition.requisitionId">
		<span>
			{{ requisition.applicant.fullName }} - {{ requisition.amountRequested }} -
			{{ requisition.description }}</span
		>
		<span class="dropdown">
			<select :disabled="statuses.length == 0" v-model="requisition.financeApprovalID">
				<option value="" disabled>What is you're verdict</option>
				<option v-for="status in statuses" :value="status.statusId" :key="status.statusId">
					{{ status.description }}
				</option>
			</select>
		</span>
		<span v-if="requisition.financeApprovalID == 2">
			<label>Would you like to leave a comment?: </label>
			<textarea v-model="requisition.financeComment" />
		</span>
		<button @click="handleSubmit(requisition)">Submit</button>
	</div>
</template>

<script setup>
import { getRequisitionsForFinanceApproval, editRequisition } from '@/hooks/requisitionCRUD'
import { getApprovalStatuses } from '@/hooks/statusCRUD'
import { ref } from 'vue'

const { requisitions } = getRequisitionsForFinanceApproval()
const { statuses } = getApprovalStatuses()

const handleSubmit = (requisition) => {
	editRequisition(requisition, 'finance')
}
</script>
