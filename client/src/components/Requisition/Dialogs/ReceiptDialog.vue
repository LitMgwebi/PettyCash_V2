<template>
	<v-card max-width="400" prepend-icon="mdi-update">
		<v-row>
			<v-data-table-server
				v-model:items-per-page="options.itemsPerPage"
				v-model:page="options.page"
				:headers="headers"
				:items="paginatedItems"
				:items-length="totalItems"
			>
				<template
					v-slot:[`item.delete`]="{ item }"
					v-if="user.id == requisition.applicant.id && requisition.stateId == 7"
				>
					<v-btn v-on:click="deleteReceipt(item)">Delete</v-btn>
				</template>
			</v-data-table-server>
		</v-row>
		<v-row v-if="user.id == requisition.applicant.id && requisition.stateId == 7">
			<section class="create">
				<h3>Upload Receipt</h3>
				<form @submit.prevent="saveReceipt" enctype="multipart/form-data">
					<input
						type="file"
						ref="file"
						@change="(e) => (file = e.target.files[0])"
						accept="application/pdf"
						required
					/>
					<button type="submit">Upload</button>
				</form>
			</section>
		</v-row>
		<template v-slot:actions>
			<v-btn class="ms-auto" text="Close" @click="closeDialog"></v-btn>
		</template>
	</v-card>
</template>

<script setup>
import { defineProps, defineEmits, inject, watch, ref } from 'vue'
import { addDocument, getDocuments, deleteDocument } from '@/hooks/documentCRUD'
import router from '@/router/router'

const user = inject('User')

//#region GET call

const typeOfFile = inject('typeOfFile')
const props = defineProps(['requisition'])
const requisition = props.requisition

const { documents: receipts, getter } = getDocuments()
watch(
	() => props.requisition,
	async (oldRequisition, newRequisition) => {
		await getter(typeOfFile.Receipt, requisition.requisitionId)
		updateTableData()
	},
	{ immediate: true, deep: true }
)

//#endregion

//#region Handling pagination of datatable

const paginatedItems = ref([]) // Data to show in the table
const totalItems = ref(0)
const options = ref({
	page: 1,
	itemsPerPage: 5,
	sortBy: [],
	sortDesc: []
})

const headers = [
	{ title: 'Full Name', value: 'fileName' },
	{ title: 'Date Uploaded', value: 'dateUploaded' },
	{ title: '', value: 'delete' }
]

const updateTableData = () => {
	let sortedItems = [...receipts.value]
	totalItems.value = receipts.value.length
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

//#region Dialog config

const emit = defineEmits(['closeDialog'])

const closeDialog = () => emit('closeDialog', false)

//#endregion

//#region Delete receipt

const deleteReceipt = (receipt) => deleteDocument(receipt, typeOfFile.Receipt)

//#endregion

//#region Save Receipt

const formData = new FormData()
const file = ref(null)

function saveReceipt() {
	formData.append = ('file', file.value)
	addDocument(formData, requisition.requisitionId, typeOfFile.Receipt)
	closeDialog()
}

//#endregion
</script>