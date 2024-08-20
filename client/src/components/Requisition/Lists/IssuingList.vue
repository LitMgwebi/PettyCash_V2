<template>
	<h3>Requisitions requiring issuing</h3>
	<v-data-table-server :headers="headers" :items="requisitions">
		<template v-slot:[`item.details`]="{ item }">
			<v-btn v-on:click="routeToDetails(item)"> Details</v-btn>
		</template>
		<template v-slot:[`item.actions`]="{ item }">
			<v-btn @click="dialog = true">Action</v-btn>
			<v-dialog v-model="dialog" width="auto">
				<IssuingDialog :requisition="item" :dialog="dialog" @closeDialog="closeDialog" />
			</v-dialog>
		</template>
	</v-data-table-server>
</template>

<script setup>
import { getRequisitions, editRequisition } from '@/hooks/requisitionCRUD'
import router from '@/router/router'
import IssuingDialog from '@/components/Requisition/Dialogs/IssuingDialog.vue'
import { ref, inject, watch } from 'vue'

//TODO all requisitions are being outputted when I click on "actions" fix it
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
	async (oldRequisitions, newRequisitions) => await getter(getRequisitionStates.Issuing),
	{ immediate: true }
)

const routeToDetails = (item) => {
	router.push({ name: 'requisition_details', params: { id: item.requisitionId } })
}
const closeDialog = () => (dialog.value = false)
</script>