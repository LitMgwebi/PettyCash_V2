<template>
	<v-row>
		<v-data-table-server
			v-model:expanded="expanded"
			v-model:items-per-page="options.itemsPerPage"
			v-model:page="options.page"
			:headers="headers"
			:items="paginatedItems"
			:items-length="totalItems"
			item-value="requisitionId"
			show-expand
		>
			<template v-slot:top>
				<v-row>
					<v-col>
						<v-btn @click="dialog = true">Add Item</v-btn>
						<v-dialog v-model="dialog" max-width="500px">
							<CreateRequisitionDialog @closeDialog="closeDialog" />
						</v-dialog>
					</v-col>
					<v-col>
						<label>Filter:</label>
						<select :disabled="statuses.length == 0" v-model="status">
							<option value="" selected disabled>Choose</option>
							<option v-for="status in statuses" :value="status" :key="status">
								{{ status.description }}
							</option>
						</select>
					</v-col>
				</v-row>
			</template>
			<template v-slot:[`item.amountRequested`]="{ item }">
				<td>{{ formatAmount(item.amountRequested) }}</td>
			</template>
			<template v-slot:expanded-row="{ columns, item }">
				<tr>
					<td :colspan="columns.length">
						<DetailsExpanded
							:requisitionId="item.requisitionId"
							@closeExpansion="closeExpansion"
						/>
					</td>
				</tr>
			</template>
		</v-data-table-server>
	</v-row>
</template>

<script setup>
import { getRequisitions } from '@/hooks/requisitionCRUD'
import CreateRequisitionDialog from '@/components/Requisition/CRUDDialogs/CreateRequisitionDialog.vue'
import DetailsExpanded from '@/components/Requisition/CRUDDialogs/DetailsExpanded.vue'
import { getStatesStatuses } from '@/hooks/statusCRUD'
import { inject, ref, watch } from 'vue'

//#region GET calls to API

const getRequisitionStates = inject('getRequisitionStates')
const { statuses, getter: statusGetter } = getStatesStatuses()
const { requisitions, getter } = getRequisitions()

const status = ref({
	statusId: 5,
	description: 'In Process',
	option: 'Process',
	isRecommended: false,
	isState: true,
	isApproved: false
})

watch(
	requisitions,
	async () => {
		await getter(getRequisitionStates.ForOne, status.value.statusId)
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
	{ title: 'Amount (R)', key: 'amountRequested' },
	{ title: 'Description', key: 'description' },
	{ title: 'Stage', key: 'stage' },
	{ title: 'Actions', key: 'data-table-expand' }
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

//#region Format table

function formatAmount(num) {
	return new Intl.NumberFormat('en-ZA', {
		style: 'currency',
		currency: 'ZAR'
	}).format(num)
}

//#endregion

//#region Dialog and Expansion

const dialog = ref(false)
const expanded = ref([])

const closeExpansion = () => (expanded.value = [])
const closeDialog = () => (dialog.value = false)

//#endregion
</script>
