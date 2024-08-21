<template>
	<!-- <h3>Requisitions requiring issuing</h3> -->
	<v-data-table-server :headers="headers" :items="requisitions">
		<template v-slot:top>
			<v-dialog v-model="dialog" width="auto">
				<IssuingDialog
					:requisition="selectedRecord"
					:dialog="dialog"
					@closeDialog="closeDialog"
				/>
			</v-dialog>
		</template>
		<template v-slot:[`item.actions`]="{ item }">
			<v-btn v-on:click="routeToDetails(item)"> Details</v-btn>
			<v-btn @click="addIssuing(item)">Action</v-btn>
		</template>
	</v-data-table-server>
</template>

<script setup>
import { getRequisitions, editRequisition } from '@/hooks/requisitionCRUD'
import router from '@/router/router'
import IssuingDialog from '@/components/Requisition/Dialogs/IssuingDialog.vue'
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
	async (oldRequisitions, newRequisitions) => await getter(getRequisitionStates.Issuing),
	{ immediate: true }
)

const addIssuing = (item) => {
	selectedRecord.value = item
	dialog.value = true
}

const routeToDetails = (item) => {
	router.push({ name: 'requisition_details', params: { id: item.requisitionId } })
}
const closeDialog = () => (dialog.value = false)
</script>