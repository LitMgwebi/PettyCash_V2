<template>
	<h3>Requests for you to approve</h3>
	<v-data-table-server :headers="headers" :items="requisitions">
		<template v-slot:item.details="{ item }">
			<v-btn v-on:click="routeToDetails(item)"> Details</v-btn>
		</template>
	</v-data-table-server>
</template>

<script setup>
import { getRequisitions, editRequisition } from '@/hooks/requisitionCRUD'
import { ref, inject } from 'vue'
import router from '@/router/router'

const headers = [
	{ title: 'Full Name', value: 'applicant.fullName' },
	{ title: 'Amount Requested', value: 'amountRequested' },
	{ title: 'GL Account', value: 'glaccount.name' },
	{ title: 'Description', value: 'description' },
	{ title: '', value: 'details' }
]
const user = inject('User')
const getRequisitionStates = inject('getRequisitionStates')
const { requisitions } = getRequisitions(getRequisitionStates.Approval)
const routeToDetails = (item) => {
	router.push({ name: 'requisition_details', params: { id: item.requisitionId } })
}
</script>
