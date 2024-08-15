<template>
	<h3>Open requistions</h3>
	<v-data-table-server :headers="headers" :items="requisitions">
		<template v-slot:item.details="{ item }">
			<v-btn v-on:click="routeToDetails(item)"> Details</v-btn>
		</template>
	</v-data-table-server>
</template>

<script setup>
import { getRequisitions } from '@/hooks/requisitionCRUD'
import router from '@/router/router'
import { inject } from 'vue'

const getRequisitionStates = inject('getRequisitionStates')
const headers = [
	{ title: 'Requisition Id', value: 'requisitionId' },
	{ title: 'Amount Requested (R)', value: 'amountRequested' },
	{ title: 'Stage', value: 'stage' },
	{ title: '', value: 'details' }
]
const { requisitions } = getRequisitions(getRequisitionStates.ForOne)
const routeToDetails = (item) => {
	router.push({ name: 'requisition_details', params: { id: item.requisitionId } })
}
</script>
