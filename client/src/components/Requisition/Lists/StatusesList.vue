<template>
	<v-row>
		<v-col>
			<h3>Requisitions</h3>
		</v-col>
	</v-row>
	<v-row>
		<v-data-table-server
			v-model:items-per-page="options.itemsPerPage"
			v-model:page="options.page"
			:headers="headers"
			:items="paginatedItems"
			:items-length="totalItems"
			v-model:expanded="expanded"
			item-value="requisitionId"
			show-expand
		>
			<template v-slot:top>
				<v-col>
					<label>Filter:</label>
					<select :disabled="statuses.length == 0" v-model="search">
						<option value="" disabled>Choose</option>
						<option v-for="status in statuses" :value="status" :key="status">
							{{ status.description }}
						</option>
					</select>
				</v-col>
			</template>
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

//#region GET call

const getRequisitionStates = inject('getRequisitionStates')

const { statuses, getter: statusGetter } = getAllStatuses()
const { requisitions, getter } = getRequisitions()
const search = ref({
	statusId: 0,
	description: 'All',
	option: 'All',
	isRecommended: false,
	isState: false,
	isApproved: false
})

watch(
	search,
	async (newSearch, oldSearch) => {
		await getter(getRequisitionStates.All, search.value.statusId)
		await statusGetter()
		updateTableData()
	},
	{ immediate: true, deep: true }
)

//#endregion

//#region pagination and ordering

const paginatedItems = ref([]) // Data to show in the table
const totalItems = ref(0)
const headers = [
	{ title: 'Id', key: 'requisitionId' },
	{ title: 'Applicant', key: 'applicant.fullName' },
	{ title: 'Amount Requested', key: 'amountRequested' },
	{ title: 'GL Account', key: 'glaccount.name' },
	{ title: 'Description', key: 'description' },
	{ title: '', key: 'data-table-expand' }
]

const options = ref({
	page: 1,
	itemsPerPage: 5,
	sortBy: [],
	sortDesc: []
})

const updateTableData = () => {
	let sortedItems = [...requisitions.value]
	totalItems.value = requisitions.value.length
	// Handle sorting
	if (options.value.sortBy.length > 0) {
		const sortKey = options.value.sortBy[0]
		const sortDesc = options.value.sortDesc[0]

		sortedItems.sort((a, b) => {
			if (a[sortKey] < b[sortKey]) return sortDesc ? 1 : -1
			if (a[sortKey] > b[sortKey]) return sortDesc ? -1 : 1
			return 0
		})
	}

	// Handle pagination
	const start = (options.value.page - 1) * options.value.itemsPerPage
	const end = start + options.value.itemsPerPage
	paginatedItems.value = sortedItems.slice(start, end)
}

//#endregion

//#region Formatting datatable information

function formatAmount(num) {
	return new Intl.NumberFormat('en-ZA', {
		style: 'currency',
		currency: 'ZAR'
	}).format(num)
}

//#endregion
</script>