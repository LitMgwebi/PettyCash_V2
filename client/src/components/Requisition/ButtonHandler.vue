<template>
	<!-- if user is an applicant -->
	<div v-if="user.id == requisition.applicant.id">
		<router-link
			v-if="requisition.managerRecommendationId == null"
			:to="{
				name: 'requisition_edit',
				params: {
					id: requisition.requisitionId
				}
			}"
		>
			<button>Edit</button>
		</router-link>
		<span v-if="requisition.issuerId == null">
			<button @click="deleteRecord">Delete</button>
		</span>
		<router-link
			:to="{
				name: 'applied_list'
			}"
		>
			<button>Back</button>
		</router-link>
	</div>

	<!-- used for approval -->
	<div
		v-if="
			(user.role == 'Senior_Employee' ||
				user.role == 'Manager' ||
				user.role == 'Executive') &&
			user.divisionId == 6 &&
			requisition.financeApproval == null &&
			requisition.managerRecommendation != null
		"
	>
		<span class="dropdown">
			<select
				:disabled="statusesForApproval.length == 0"
				v-model="requisition.financeApprovalID"
			>
				<option value="" disabled>What is you're verdict</option>
				<option
					v-for="status in statusesForApproval"
					:value="status.statusId"
					:key="status.statusId"
				>
					{{ status.option }}
				</option>
			</select>
		</span>
		<span v-if="requisition.financeApprovalID == 2">
			<label>Would you like to leave a comment?: </label>
			<textarea v-model="requisition.financeComment" />
		</span>
		<button @click="handleApproval(requisition)">Submit</button>
	</div>
</template>

<script setup>
import { inject, defineProps, toRefs } from 'vue'
import { deleteRequisition, editRequisition } from '@/hooks/requisitionCRUD'
import { getRecommendationStatuses, getApprovalStatuses } from '@/hooks/statusCRUD'
import router from '@/router/router'

// TODO intro "Back" to the page user was on

const props = defineProps(['requisition'])
const { requisition } = toRefs(props)
const user = inject('User')
const editRequisitionStates = inject('editRequisitionStates')

//#region Handing Deletion

function deleteRecord() {
	deleteRequisition(requisition.value)
	router.push({ name: 'requisitions' })
}

//#endregion
</script>