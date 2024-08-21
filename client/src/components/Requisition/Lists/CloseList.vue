<template>
	<!-- <h3>Requisitions requiring Closing</h3> -->
	<v-data-table-server :headers="headers" :items="requisitions">
		<template v-slot:top>
			<v-dialog v-model="dialog" width="auto">
				<CloseDialog
					:requisition="selectedRecord"
					:dialog="dialog"
					@closeDialog="closeDialog"
				/>
			</v-dialog>
		</template>
		<template v-slot:[`item.actions`]="{ item }">
			<v-btn v-on:click="routeToDetails(item)"> Details</v-btn>
			<v-btn v-on:click="addClosing(item)">Action</v-btn>
		</template>
	</v-data-table-server>
</template>

<script setup>
import { getRequisitions, editRequisition } from '@/hooks/requisitionCRUD'
import CloseDialog from '@/components/Requisition/Dialogs/CloseDialog.vue'
import router from '@/router/router'
import { ref, inject, watch } from 'vue'

const getRequisitionStates = inject('getRequisitionStates')
const selectedRecord = ref({})
const user = inject('User')
const dialog = ref(false)
const headers = [
	{ title: 'Full Name', value: 'applicant.fullName' },
	{ title: 'Amount Requested', value: 'amountRequested' },
	{ title: 'GL Account', value: 'glaccount.name' },
	{ title: 'Description', value: 'description' },
	{ title: '', value: 'actions' }
]
const { requisitions, getter } = getRequisitions()
watch(
	requisitions,
	async (oldRequisitions, newRequisitions) => await getter(getRequisitionStates.Closing),
	{ immediate: true }
)

function addClosing(item) {
	selectedRecord.value = item
	dialog.value = true
}

const routeToDetails = (item) => {
	router.push({ name: 'requisition_details', params: { id: item.requisitionId } })
}
const closeDialog = () => (dialog.value = false)
</script>