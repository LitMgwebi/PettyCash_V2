<template>
	<v-card max-width="400" prepend-icon="mdi-update">
		<div>
			<label>Total expenses: </label>
			<input type="text" v-model="requisition.totalExpenses" required />
		</div>
		<template v-slot:actions>
			<button @click="addExpenses(requisition)">Save</button>
			<v-btn class="ms-auto" text="Close" @click="closeDialog"></v-btn>
		</template>
	</v-card>
</template>

<script setup>
import { defineEmits, defineProps, inject } from 'vue'
import { editRequisition } from '@/hooks/requisitionCRUD'
// TODO change the dialog box and list to resemble the one on recommendation to fix bug
const editRequisitionStates = inject('editRequisitionStates')
const props = defineProps(['dialog', 'requisition'])
const emit = defineEmits(['closeDialog'])
const dialog = props.dialog
const requisition = props.requisition

function addExpenses(requisition) {
	editRequisition(requisition, editRequisitionStates.Expenses)
	closeDialog()
}

function closeDialog() {
	emit('closeDialog', false)
}
</script>
