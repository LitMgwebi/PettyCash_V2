<template>
	<v-row>
		<h3>Open requistions</h3>
		<div>
			<label>Filter:</label>
			<select :disabled="statuses.length == 0" v-model="status">
				<option value="" disabled>Choose</option>
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
import MotivationDialog from '@/components/Requisition/Dialogs/MotivationDialog.vue'
import { getStatesStatuses } from '@/hooks/statusCRUD'
import { inject, onMounted, ref, watch } from 'vue'

const dialog = ref(false)
const closeDialog = () => (dialog.value = false)
const { statuses, getter: statusGetter } = getStatesStatuses()
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
	{ title: 'Actions', value: 'details' },
	{ title: '', value: 'expenses' }
]

watch(
	status,
	async (oldStatus, newStatus) => {
		await getter(getRequisitionStates.ForOne, status.value.statusId)
		await statusGetter()
	},
	{ immediate: true }
)

const routeToDetails = (item) => {
	router.push({ name: 'requisition_details', params: { id: item.requisitionId } })
}
</script>
