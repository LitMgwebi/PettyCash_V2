<template>
	<v-container>
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
							<label>Filter</label>
							<select :disabled="arrayOfStates.length == 0" v-model="dateFilter">
								<option v-for="state in arrayOfStates" :value="state" :key="state">
									{{ state.type }}
								</option>
							</select>
						</v-col>
					</v-row>
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
	</v-container>
</template>

<script setup>
import { getRequisitions, editRequisition } from '@/hooks/requisitionCRUD'
import OpenedDialog from '@/components/Requisition/Dialogs/OpenedDialog.vue'
import DetailsExpanded from '@/components/Requisition/CRUDDialogs/DetailsExpanded.vue'
import { ref, inject, watch } from 'vue'

const user = inject('User')

//#region GET call

const getRequisitionStates = inject('getRequisitionStates')
const issuedRequisitionState = inject('issuedRequisitionState')
const { requisitions, getter } = getRequisitions()

const dateFilter = ref({
	type: issuedRequisitionState.Green
})

const arrayOfStates = ref([
	{ type: issuedRequisitionState.Green },
	{ type: issuedRequisitionState.Red }
])
watch(
	dateFilter,
	async (oldRequisitions, newRequisitions) => {
		await getter(getRequisitionStates.Issued, 0, dateFilter.value.type)
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
	{ title: 'Name', key: 'applicant.fullName' },
	{ title: 'Amount(R)', key: 'amountRequested' },
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

//#region Formatting info in datatable

function formatAmount(num) {
	return new Intl.NumberFormat('en-ZA', {
		style: 'currency',
		currency: 'ZAR'
	}).format(num)
}

//#endregion

//#region Add Issuing

const selectedRecord = ref({})
const addIssuing = (item) => {
	selectedRecord.value = item
	dialog.value = true
}

//#endregion

//#region Dialog and Expansion Config

const dialog = ref(false)
const expanded = ref([])
const closeDialog = () => (dialog.value = false)

//#endregion
</script>