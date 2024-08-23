<template>
	<v-card max-width="400" prepend-icon="mdi-update">
		<div>Has {{ requisition.applicant.fullName }} brought back the change?</div>
		<select v-model="requisition.confirmChangeReceived">
			<option value="" disabled>Please Choose</option>
			<option value="true">Yes</option>
			<option value="false">No</option>
		</select>
		<template v-slot:actions>
			<button @click="confirmChange(requisition)">Confirm</button>
			<v-btn class="ms-auto" text="Cancel" @click="closeDialog"></v-btn>
		</template>
	</v-card>
</template>

<script setup>
import { defineProps, defineEmits, inject, watch, ref } from 'vue'
import { editRequisition } from '@/hooks/requisitionCRUD'

//TODO change the drop down list to yes and cancel buttons || or a radio button with cancel and confirm buttons

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