<template>
	<v-row>
		<h3>Requisitions</h3>
		<div>
			<label>Filter:</label>
			<select :disabled="statuses.length == 0" v-model="search">
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
import { getRequisitions, editRequisition } from '@/hooks/requisitionCRUD'
import { ref, inject, watch, onMounted } from 'vue'
import { getAllStatuses } from '@/hooks/statusCRUD'
import router from '@/router/router'

const getRequisitionStates = inject('getRequisitionStates')
const { statuses } = getAllStatuses()
const { requisitions, getter } = getRequisitions()
const search = ref({
	statusId: 0,
	description: '',
	option: '',
	isRecommended: false,
	isState: false,
	isApproved: false
})
const headers = [
	{ title: 'Applicant', value: 'applicant.fullName' },
	{ title: 'Amount Requested', value: 'amountRequested' },
	{ title: 'GL Account', value: 'glaccount.name' },
	{ title: 'Description', value: 'description' },
	{ title: '', value: 'details' }
]
onMounted(async () => {
	await getter(getRequisitionStates.All, search.value.statusId)
})
watch(search, async (newSearch, oldSearch) => {
	await getter(getRequisitionStates.All, search.value.statusId)
})

const routeToDetails = (item) => {
	router.push({ name: 'requisition_details', params: { id: item.requisitionId } })
}
</script>