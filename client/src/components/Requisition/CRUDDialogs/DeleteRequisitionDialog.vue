<template>
	<v-card>
		<v-card-title class="text-h5">Are you sure you want to delete this item?</v-card-title>
		<!-- <v-card-body>{{ requisition.requisitionId }}</v-card-body> -->
		<v-card-actions>
			<v-spacer></v-spacer>
			<v-btn color="blue-darken-1" variant="text" @click="closeDialog()">Cancel</v-btn>
			<v-btn color="blue-darken-1" variant="text" @click="deleteRecord()">Yes</v-btn>
			<v-spacer></v-spacer>
		</v-card-actions>
	</v-card>
</template>

<script setup>
import { defineProps, defineEmits } from 'vue'
import { deleteRequisition } from '@/hooks/requisitionCRUD'

const props = defineProps(['requisitionId'])
const emit = defineEmits(['closeDialog'])
const id = props.requisitionId

// TODO figure out why delete is not able to send data to api
function deleteRecord() {
	deleteRequisition(id)
	closeDialog()
}

function closeDialog() {
	emit('closeDialog', false)
	emit('closeExansion')
}
</script>
