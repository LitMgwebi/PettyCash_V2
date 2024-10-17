<template>
	<v-card max-width="400" prepend-icon="mdi-update">
		<div>
			<label>Total expenses: </label>
			<input type="text" v-model="requisition.totalExpenses" />
		</div>
		<template v-slot:actions>
			<button v-if="requisition.stateId == 7" @click="editExpenses(requisition)">Save</button>
			<v-btn class="ms-auto" text="Close" @click="closeDialog"></v-btn>
		</template>
	</v-card>
</template>

<script setup>
import { defineEmits, defineProps, inject } from 'vue'
import { editRequisition } from '@/hooks/requisitionCRUD'

const editRequisitionStates = inject('editRequisitionStates')
const props = defineProps(['dialog', 'requisition'])
const emit = defineEmits(['closeDialog'])
const dialog = props.dialog
const requisition = props.requisition

function editExpenses(requisition) {
	editRequisition(requisition, editRequisitionStates.Expenses)
	closeDialog()
}

function closeDialog() {
	emit('closeDialog', false)
}
</script>
