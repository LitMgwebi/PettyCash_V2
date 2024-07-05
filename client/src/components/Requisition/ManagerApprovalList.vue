<template>
	Your departments requests
	<div v-for="requisition in requisitions" :key="requisition.requisitionId">
		<span>
			{{ requisition.applicant.fullName }} - {{ requisition.amountRequested }} -
			{{ requisition.description }}</span
		>
		<!-- <span class="dropdown">
			<select :disabled="statuses.length == 0" v-model="updatedStatus.tripStatusId">
				<option value="" disabled>Select a sub account</option>
				<option
					v-for="statuse in statuses"
					:value="statuse.subAccountId"
					:key="subAccount.subAccountId"
				>
					{{ subAccount.name }}
				</option>
			</select>
		</span> -->
		<button @click="requisitionApproval('approve')">Approve</button>
		<button @click="requisitionApproval('decline')">Decline</button>
	</div>
</template>

<script setup>
import { getRequisitionsForManagerApproval } from '@/hooks/requisitionCRUD'
import { getApprovalStatuses } from '@/hooks/statusCRUD'

const { requisitions } = getRequisitionsForManagerApproval()
const { statuses } = getApprovalStatuses()

const updatedStatus = ref({
	tripStatusId: ''
})
const requisitionApproval = (answer) => {
	console.log(answer)
}
</script>
