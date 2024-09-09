<template>
	<v-card v-if="requisition != null">
		<v-card-title>
			Has {{ requisition.applicant.fullName }} brought back the change?
		</v-card-title>
		<!-- <select v-model="requisition.confirmChangeReceived">
			<option value="" disabled>Please Choose</option>
			<option value="true">Yes</option>
			<option value="false">No</option>
		</select>
		<template v-slot:actions>
			<button @click="confirmChange(requisition)">Confirm</button>
			<v-btn class="ms-auto" text="Cancel" @click="closeDialog"></v-btn>
		</template> -->
		<v-card-actions>
			<v-spacer></v-spacer>
			<v-btn color="blue-darken-1" variant="text" @click="closeDialog()">Cancel</v-btn>
			<v-btn color="blue-darken-1" variant="text" @click="confirmChange(requisition)">
				Confirm
			</v-btn>
			<v-spacer></v-spacer>
		</v-card-actions>
	</v-card>
</template>

<script setup>
import { defineProps, defineEmits, inject, watch, ref } from 'vue'
import { editRequisition } from '@/hooks/requisitionCRUD'

const editRequisitionStates = inject('editRequisitionStates')
const props = defineProps(['dialog', 'requisition'])
const emit = defineEmits(['closeDialog'])
const dialog = props.dialog
const requisition = props.requisition

function confirmChange(requisition) {
	editRequisition(requisition, editRequisitionStates.Close)
	closeDialog()
}
function closeDialog() {
	emit('closeDialog', false)
}
</script>