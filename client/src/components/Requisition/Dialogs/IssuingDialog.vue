<template>
	<v-dialog v-model="dialog" width="auto">
		<v-card max-width="600" prepend-icon="mdi-update">
			{{ requisition }}
			<div>
				<label>Cash to be issued: </label>
				<input type="text" v-model="requisition.cashIssued" required />
			</div>
			<div>
				<label>Applicant Code: </label>
				<input type="text" v-model="attemptCode" required />
			</div>
			<div>
				<label>Comment:</label>
				<textarea
					placeholder="Please add a comment if you issue an amount lower than the amount requested."
					v-model="requisition.issueComment"
				>
				</textarea>
			</div>
			<template v-slot:actions>
				<button :disabled="attemptCode.length < 5" @click="issueMoney(requisition)">
					Issue
				</button>
				<v-btn class="ms-auto" text="Cancel" @click="closeDialog"></v-btn>
			</template>
		</v-card>
	</v-dialog>
</template>

<script setup>
import { defineProps, defineEmits, inject, watch, ref } from 'vue'
import { editRequisition } from '@/hooks/requisitionCRUD'

//TODO Find out why the wrong requisition outputs when clicking on dialog box
const editRequisitionStates = inject('editRequisitionStates')
const props = defineProps(['dialog', 'requisition'])
const emit = defineEmits(['closeDialog'])
const dialog = props.dialog
const requisition = props.requisition
const attemptCode = ref(0)

const issueMoney = (requisition) => {
	editRequisition(requisition, editRequisitionStates.Issuing, attemptCode.value)
	closeDialog()
}

function closeDialog() {
	emit('closeDialog', false)
}
</script>