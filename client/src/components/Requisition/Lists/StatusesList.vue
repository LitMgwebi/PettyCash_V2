<template>
	<v-row>
		<v-col>
			<h3>Requisitions</h3>
		</v-col>
		<v-col>
			<div>
				<label>Filter:</label>
				<select :disabled="statuses.length == 0" v-model="search">
					<option value="" disabled>Choose</option>
					<option v-for="status in statuses" :value="status" :key="status">
						{{ status.description }}
					</option>
				</select>
			</div>
		</v-col>
	</v-row>
	<v-row>
		<v-data-table-server
			v-model:expanded="expanded"
			:headers="headers"
			:items="requisitions"
			item-value="requisitionId"
			show-expand
		>
			<template v-slot:expanded-row="{ columns, item }">
				<tr>
					<td :colspan="columns.length">
						<DetailsExpanded :requisitionId="item.requisitionId" />
					</td>
				</tr>
			</template>
			<template v-slot:[`item.amountRequested`]="{ item }">
				<td>{{ formatAmount(item.amountRequested) }}</td>
			</template>
		</v-data-table-server>
	</v-row>
</template>

<script setup>
import { getRequisitions } from '@/hooks/requisitionCRUD'
import DetailsExpanded from '@/components/Requisition/CRUDDialogs/DetailsExpanded.vue'
import { ref, inject, watch } from 'vue'
import { getAllStatuses } from '@/hooks/statusCRUD'

const expanded = ref([])
const getRequisitionStates = inject('getRequisitionStates')
const { statuses, getter: statusGetter } = getAllStatuses()
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
	{ title: 'Id', key: 'requisitionId' },
	{ title: 'Applicant', key: 'applicant.fullName' },
	{ title: 'Amount Requested', key: 'amountRequested' },
	{ title: 'GL Account', key: 'glaccount.name' },
	{ title: 'Description', key: 'description' },
	{ title: '', key: 'data-table-expand' }
]

watch(
	search,
	async (newSearch, oldSearch) => {
		await getter(getRequisitionStates.All, search.value.statusId)
		await statusGetter()
	},
	{ immediate: true }
)

function formatAmount(num) {
	return new Intl.NumberFormat('en-ZA', {
		style: 'currency',
		currency: 'ZAR'
	}).format(num)
}
</script>