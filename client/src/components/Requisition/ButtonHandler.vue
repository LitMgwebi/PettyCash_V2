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
		<div
			v-if="requisition.glaccount.needsMotivation == true && requisition.motivations == null"
		>
			upload
		</div>
		<span v-if="requisition.issuerId == null">
			<button @click="deleteRecord">Delete</button>
		</span>
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

	<!-- used for recommendation -->
	<div
		v-if="
			((user.role == 'Manager' && user.divisionId != 6) ||
				user.role == 'GM_Manager' ||
				user.role == 'Senior_Employee') &&
			requisition.managerRecommendation == null
		"
	>
		<span class="dropdown">
			<select
				:disabled="statusesForRecommendation.length == 0"
				v-model="requisition.managerRecommendationId"
			>
				<option value="" disabled>What is you're verdict</option>
				<option
					v-for="status in statusesForRecommendation"
					:value="status.statusId"
					:key="status.statusId"
				>
					{{ status.option }}
				</option>
			</select>
		</span>
		<span v-if="requisition.managerRecommendationId == 4">
			<label>Would you like to leave a comment?: </label>
			<textarea v-model="requisition.managerComment" />
		</span>
		<button @click="handleRecommendation(requisition)">Submit</button>
	</div>
</template>

<script setup>
import { inject, defineProps, toRefs } from 'vue'
import { deleteRequisition, editRequisition } from '@/hooks/requisitionCRUD'
import { getRecommendationStatuses, getApprovalStatuses } from '@/hooks/statusCRUD'
import router from '@/router/router'

const props = defineProps(['requisition'])
const { requisition } = toRefs(props)
const user = inject('User')

//#region Handling recommedation

const { statuses: statusesForRecommendation } = getRecommendationStatuses()
const handleRecommendation = (requisition) => {
	editRequisition(requisition, 'recommendation')
	router.push({ name: 'requisitions' })
}

//#endregion

//#region Handling approval

const { statuses: statusesForApproval } = getApprovalStatuses()

const handleApproval = (requisition) => {
	editRequisition(requisition, 'approval')
	router.push({ name: 'requisitions' })
}

//#endregion

//#region Handing Deletion

function deleteRecord() {
	deleteRequisition(requisition.value)
	router.push({ name: 'requisitions' })
}

//#endregion
</script>