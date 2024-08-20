<template>
	<h3>Requests for you to approve</h3>
	<v-data-table-server :headers="headers" :items="requisitions">
		<template v-slot:[`item.details`]="{ item }">
			<v-btn v-on:click="routeToDetails(item)">Details</v-btn>
		</template>
		<template
			v-slot:[`item.actions`]="{ item }"
			v-if="
				(user.role == 'Senior_Employee' ||
					user.role == 'Manager' ||
					user.role == 'Executive') &&
				user.divisionId == 6
			"
		>
			<v-btn @click="dialog = true">Action</v-btn>
			<v-dialog v-model="dialog" width="auto">
				<ApprovalDialog :requisition="item" :dialog="dialog" @closeDialog="closeDialog" />
			</v-dialog>
		</template>
	</v-data-table-server>
</template>

<script setup>
import { getRequisitions } from '@/hooks/requisitionCRUD'
import ApprovalDialog from '@/components/Requisition/Dialogs/ApprovalDialog.vue'
import { ref, inject, watch } from 'vue'
import router from '@/router/router'

const getRequisitionStates = inject('getRequisitionStates')
const user = inject('User')
const dialog = ref(false)
const headers = [
	{ title: 'Full Name', value: 'applicant.fullName' },
	{ title: 'Amount Requested', value: 'amountRequested' },
	{ title: 'GL Account', value: 'glaccount.name' },
	{ title: 'Description', value: 'description' },
	{ title: '', value: 'details' },
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
const closeDialog = () => (dialog.value = false)
</script>
