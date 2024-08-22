<template>
	<v-data-table-server :headers="headers" :items="requisitions">
		<template v-slot:top>
			<v-dialog v-model="dialog" width="auto">
				<ApprovalDialog
					:requisition="selectedRecord"
					:dialog="dialog"
					@closeDialog="closeDialog"
				/>
			</v-dialog>
		</template>
		<template v-slot:[`item.actions`]="{ item }">
			<v-btn v-on:click="routeToDetails(item)">Details</v-btn>
			<v-btn
				v-if="
					(user.role == 'Senior_Employee' ||
						user.role == 'Manager' ||
						user.role == 'Executive') &&
					user.divisionId == 6
				"
				@click="addApproval(item)"
			>
				Action
			</v-btn>
		</template>
	</v-data-table-server>
</template>

<script setup>
import { getRequisitions } from '@/hooks/requisitionCRUD'
import ApprovalDialog from '@/components/Requisition/Dialogs/ApprovalDialog.vue'
import { ref, inject, watch } from 'vue'
import router from '@/router/router'

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
	async (oldRequisitions, newRequisitions) => await getter(getRequisitionStates.Approval),
	{ immediate: true }
)
const routeToDetails = (item) => {
	router.push({ name: 'requisition_details', params: { id: item.requisitionId } })
}

const addApproval = (item) => {
	selectedRecord.value = item
	dialog.value = true
}
const closeDialog = () => (dialog.value = false)
</script>
