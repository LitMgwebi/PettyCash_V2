<template>
	<div>
		<v-card max-width="400" prepend-icon="mdi-update">
			<div>
				<v-data-table-server
					v-model:items-per-page="options.itemsPerPage"
					v-model:page="options.page"
					:headers="headers"
					:items="paginatedItems"
					:items-length="totalItems"
				>
					<template
						v-slot:[`item.delete`]="{ item }"
						v-if="
							user.id == requisition.applicant.id &&
							requisition.managerRecommendation == null
						"
					>
						<v-btn v-on:click="deleteMotivation(item)">Delete</v-btn>
					</template>
				</v-data-table-server>
			</div>
			<div
				v-if="
					user.id == requisition.applicant.id && requisition.managerRecommendation == null
				"
			>
				<section class="create">
					<h3>Upload Motivation</h3>
					<form @submit.prevent="saveMotivation" enctype="multipart/form-data">
						<input
							type="file"
							accept="application/pdf"
							ref="file"
							@change="(e) => (file = e.target.files[0])"
							required
						/>
						<button type="submit">Upload</button>
					</form>
				</section>
			</div>
			<template v-slot:actions>
				<v-btn class="ms-auto" text="Close" @click="closeDialog"></v-btn>
			</template>
		</v-card>
	</div>
</template>

<script setup>
import { defineProps, defineEmits, inject, watch, ref } from 'vue'
import { addDocument, getDocuments, deleteDocument } from '@/hooks/documentCRUD'
import router from '@/router/router'

const user = inject('User')

//#region pagination and ordering

const paginatedItems = ref([]) // Data to show in the table
const totalItems = ref(0)

const headers = [
	{ title: 'Full Name', value: 'fileName' },
	{ title: 'Date Uploaded', value: 'dateUploaded' },
	{ title: '', value: 'delete' }
]

const options = ref({
	page: 1,
	itemsPerPage: 5,
	sortBy: [],
	sortDesc: []
})

const updateTableData = () => {
	let sortedItems = [...motivations.value]
	totalItems.value = motivations.value.length
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

//#region GET from API

const typeOfFile = inject('typeOfFile')
const props = defineProps(['requisition'])
const requisition = props.requisition
const { documents: motivations, getter } = getDocuments()
watch(
	() => {
		props.requisition
	},
	async (oldRequisition, newRequisition) => {
		await getter(typeOfFile.Motivation, requisition.requisitionId)
		updateTableData()
	},
	{ immediate: true, deep: true }
)

//#endregion

//#region Dialog Config

const emit = defineEmits(['closeDialog'])

function closeDialog() {
	emit('closeDialog', false)
}

//#endregion

//#region Delete motivation

function deleteMotivation(motivation) {
	deleteDocument(motivation, typeOfFile.Motivation)
	closeDialog()
}

//#endregion

//#region Save motivation

const formData = new FormData()
const file = ref(null)
function saveMotivation() {
	formData.append = ('file', file.value)
	addDocument(formData, requisition.requisitionId, typeOfFile.Motivation)
	closeDialog()
}

//#endregion
</script>