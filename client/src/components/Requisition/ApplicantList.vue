<template>
	<v-row>
		<h3>Open requistions</h3>
		<div>
			<label>Filter:</label>
			<select :disabled="statuses.length == 0" v-model="status">
				<option v-for="status in statuses" :value="status" :key="status">
					{{ status.description }}
				</option>
			</select>
		</div>
	</v-row>
	<v-row>
		<v-data-table-server :headers="headers" :items="requisitions">
			<template v-slot:[`item.details`]="{ item }">
				<v-btn v-on:click="routeToDetails(item)"> Details</v-btn>
			</template>
		</v-data-table-server>
	</v-row>
</template>

<script setup>
import { getRequisitions } from '@/hooks/requisitionCRUD'
import router from '@/router/router'
import { getStatesStatuses } from '@/hooks/statusCRUD'
import { inject, onMounted, ref, watch } from 'vue'

const { statuses } = getStatesStatuses()
const status = ref({
	statusId: 5,
	description: 'In Process',
	option: 'Process',
	isRecommended: false,
	isState: true,
	isApproved: false
})
const getRequisitionStates = inject('getRequisitionStates')
const { requisitions, getter } = getRequisitions()
const headers = [
	{ title: 'Requisition Id', value: 'requisitionId' },
	{ title: 'Amount Requested (R)', value: 'amountRequested' },
	{ title: 'Stage', value: 'stage' },
	{ title: '', value: 'details' }
]

onMounted(async () => {
	await getter(getRequisitionStates.ForOne, status.value.statusId)
})

watch(status, async (oldStatus, newStatus) => {
	await getter(getRequisitionStates.ForOne, status.value.statusId)
})

const routeToDetails = (item) => {
	router.push({ name: 'requisition_details', params: { id: item.requisitionId } })
}
</script>
