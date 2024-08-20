<template>
	<div>
		<v-dialog v-model="dialog" width="auto">
			<v-card max-width="400" prepend-icon="mdi-update">
				<div>
					<div class="dropdown">
						<label>Choose:</label>
						<select
							:disabled="statuses.length == 0"
							v-model="requisition.managerRecommendationId"
						>
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
						<!-- <span v-if="requisition.managerRecommendationId == 4"> -->
						<label>Comment: </label>
						<textarea v-model="requisition.managerComment" />
						<!-- </span> -->
					</div>
				</div>
				<template v-slot:actions>
					<button @click="handleRecommendation(requisition)">Submit</button>
					<v-btn class="ms-auto" text="Cancel" @click="closeDialog"></v-btn>
				</template>
			</v-card>
		</v-dialog>
	</div>
</template>

<script setup>
import { defineProps, defineEmits, inject, watch, ref } from 'vue'
import { getRecommendationStatuses } from '@/hooks/statusCRUD'
import { editRequisition } from '@/hooks/requisitionCRUD'

const editRequisitionStates = inject('editRequisitionStates')
const props = defineProps(['dialog', 'requisition'])
const emit = defineEmits(['closeDialog'])
const dialog = props.dialog
const requisition = props.requisition

const { statuses, getter } = getRecommendationStatuses()

watch(
	statuses,
	async (newStatus, oldStatus) => {
		await getter()
	},
	{ immediate: true }
)

const handleRecommendation = (requisition) => {
	editRequisition(requisition, editRequisitionStates.Recommendation)
	closeDialog()
}
function closeDialog() {
	emit('closeDialog', false)
}
</script>