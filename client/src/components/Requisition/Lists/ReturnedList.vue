<template>
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
			<v-dialog v-model="dialog" width="auto">
				<CloseDialog
					:requisition="selectedRecord"
					:dialog="dialog"
					@closeDialog="closeDialog"
				/>
			</v-dialog>
		</template>
		<template v-slot:[`item.change`]="{ item }">
			<td>{{ formatAmount(item.change) }}</td>
		</template>
		<template v-slot:[`item.actions`]="{ item }">
			<v-btn v-on:click="addClosing(item)">Action</v-btn>
		</template>
		<template v-slot:expanded-row="{ columns, item }">
			<tr>
				<td :colspan="columns.length">
					<DetailsExpanded :requisitionId="item.requisitionId" />
				</td>
			</tr>
		</template>
	</v-data-table-server>
</template>

<script setup>
import { getRequisitions, editRequisition } from '@/hooks/requisitionCRUD'
import CloseDialog from '@/components/Requisition/Dialogs/CloseDialog.vue'
import { ref, inject, watch } from 'vue'
import DetailsExpanded from '@/components/Requisition/CRUDDialogs/DetailsExpanded.vue'

const user = inject('User')

//#region GET call

const getRequisitionStates = inject('getRequisitionStates')
const { requisitions, getter } = getRequisitions()
watch(
	requisitions,
	async (oldRequisitions, newRequisitions) => {
		await getter(getRequisitionStates.Returned)
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
	{ title: 'Full Name', key: 'applicant.fullName' },
	{ title: 'Change', key: 'change' },
	{ title: 'GL Account', key: 'glaccount.name' },
	{ title: 'Description', key: 'description' },
	{ title: '', key: 'actions' },
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

//#region Add closing

const selectedRecord = ref({})
function addClosing(item) {
	selectedRecord.value = item
	dialog.value = true
}

//#endregion

//#region Format info on datatable

function formatAmount(num) {
	return new Intl.NumberFormat('en-ZA', {
		style: 'currency',
		currency: 'ZAR'
	}).format(num)
}

//#endregion

//#region Dialog and Expansion config

const dialog = ref(false)
const expanded = ref([])
const closeDialog = () => (dialog.value = false)

//#endregion
</script>