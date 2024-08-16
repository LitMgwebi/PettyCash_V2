<template>
	<h3>Requisitions requiring Closing</h3>
	<v-data-table-server :headers="headers" :items="requisitions">
		<template v-slot:[`item.details`]="{ item }">
			<v-btn v-on:click="routeToDetails(item)"> Details</v-btn>
		</template>
	</v-data-table-server>
</template>

<script setup>
import { getRequisitions, editRequisition } from '@/hooks/requisitionCRUD'
import router from '@/router/router'
import { ref, inject } from 'vue'

const getRequisitionStates = inject('getRequisitionStates')
const headers = [
	{ title: 'Full Name', value: 'applicant.fullName' },
	{ title: 'Amount Requested', value: 'amountRequested' },
	{ title: 'GL Account', value: 'glaccount.name' },
	{ title: 'Description', value: 'description' },
	{ title: '', value: 'details' }
]
const { requisitions } = getRequisitions(getRequisitionStates.Closing)
const routeToDetails = (item) => {
	router.push({ name: 'requisition_details', params: { id: item.requisitionId } })
}
</script>