<template>
	<v-card max-width="400" prepend-icon="mdi-update">
		<div>
			<div class="dropdown">
				<label>Choose</label>
				<select :disabled="statuses.length == 0" v-model="requisition.financeApprovalID">
					<option value="" disabled>What is you're verdict</option>
					<option
						v-for="status in statuses"
						:value="status.statusId"
						:key="status.statusId"
					>
						{{ status.option }}
					</option>
				</select>
			</div>
			<div>
				<!-- <span v-if="requisition.financeApprovalID == 2"> -->
				<label>Comment?: </label>
				<textarea
					v-model="requisition.financeComment"
					placeholder="Please enter a comment"
				/>
				<!-- </span> -->
			</div>
		</div>
		<template v-slot:actions>
			<button @click="handleApproval(requisition)">Submit</button>
			<v-btn class="ms-auto" text="Cancel" @click="closeDialog"></v-btn>
		</template>
	</v-card>
</template>

<script setup>
import { defineProps, defineEmits, inject, watch, ref } from 'vue'
import { getApprovalStatuses } from '@/hooks/statusCRUD'
import { editRequisition } from '@/hooks/requisitionCRUD'

const editRequisitionStates = inject('editRequisitionStates')
const props = defineProps(['requisition'])
const emit = defineEmits(['closeDialog'])
const requisition = props.requisition

const { statuses, getter } = getApprovalStatuses()
watch(
	statuses,
	async (newStatus, oldStatus) => {
		await getter()
	},
	{ immediate: true }
)

const handleApproval = (requisition) => {
	editRequisition(requisition, editRequisitionStates.Approval)
	closeDialog()
}

function closeDialog() {
	emit('closeDialog', false)
}
</script>