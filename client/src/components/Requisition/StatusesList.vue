<template>
	<h3>Requisitions</h3>
	<div>
		<select :disabled="statuses.length == 0" v-model="statusSearch.statusId">
			<option value="" disabled>Choose option</option>
			<option v-for="status in statuses" :value="status.statusId" :key="status.statusId">
				{{ status.description }}
			</option>
		</select>
	</div>
	<div v-if="requisitions">
		<div v-for="requisition in requisitions" :key="requisition.requisitionId">
			<span>
				{{ requisition.applicant.fullName }} - R{{ requisition.amountRequested }} ({{
					requisition.glaccount.name
				}}) - {{ requisition.description }}</span
			>
			<div>
				<router-link
					:to="{
						name: 'requisition_details',
						params: {
							id: requisition.requisitionId
						}
					}"
				>
					<button>Details</button>
				</router-link>
			</div>
		</div>
	</div>
	<div v-else>
		<h4>Please choose an option</h4>
	</div>
</template>

<script setup>
import { getRequisitions, editRequisition } from '@/hooks/requisitionCRUD'
import { ref, inject, watch } from 'vue'
import { getAllStatuses } from '@/hooks/statusCRUD'

const getRequisitionStates = inject('getRequisitionStates')
const { statuses } = getAllStatuses()
const statusSearch = ref({
	statusId: 0,
	description: 'All'
})

watch(statusSearch, async (newStatusSearch, oldStatusSearch) => {
	const { requisitions } = await getRequisitions(
		getRequisitionStates.All,
		statusSearch.value.statusId
	)
})
</script>