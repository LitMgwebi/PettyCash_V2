<template>
	<v-container>
		<v-row><h2>Purposes</h2></v-row>
		<v-row>
			<v-col>
				<v-data-table-server
					v-model:items-per-page="options.itemsPerPage"
					v-model:page="options.page"
					:headers="headers"
					:items="paginatedItems"
					:items-length="totalItems"
				>
					<template v-slot:[`item.edit`]="{ item }">
						<v-btn @click="populateEdit(item)">Edit</v-btn>
						<v-btn @click="deleteRecord(item)">Delete</v-btn>
					</template>
				</v-data-table-server>
			</v-col>

			<v-col>
				<section class="create">
					<h3>Add Purpose</h3>
					<form @submit.prevent="addSubmit">
						<div>
							<label>Name: </label>
							<input type="text" v-model="newPurpose.name" />
						</div>
						<div>
							<label>Description: </label>
							<input type="text" v-model="newPurpose.description" />
						</div>
						<div class="submit">
							<button>Add</button>
							<button @click="reloadPage">Cancel</button>
						</div>
					</form>
				</section>

				<section class="edit">
					<span v-if="updatedPurpose.name.length > 0">
						<h3>Edit {{ updatedPurpose.name }}</h3>
					</span>
					<span v-else><h3>Select Purpose to edit</h3></span>
					<form @submit.prevent="editSubmit">
						<div>
							<label>Name: </label>
							<input type="text" v-model="updatedPurpose.name" />
						</div>
						<div>
							<label>Description: </label>
							<input type="text" v-model="updatedPurpose.description" />
						</div>
						<div class="submit">
							<button>Edit</button>
							<button @click="reloadPage">Cancel</button>
						</div>
					</form>
				</section>
			</v-col>
		</v-row>
	</v-container>
</template>

<script setup>
import { getPurposes, addPurpose, editPurpose, deletePurpose } from '@/hooks/purposeCRUD'
import { ref, watch } from 'vue'

const paginatedItems = ref([]) // Data to show in the table
const totalItems = ref(0)
const reloadPage = () => location.reload()
const { purposes, getter } = getPurposes()

watch(
	purposes,
	async () => {
		await getter()
		updateTableData()
	},
	{ immediate: true, deep: true }
)

const headers = [
	{ title: 'Name', value: 'name' },
	{ title: 'Description', value: 'description' },
	{ title: '', value: 'edit' },
	{ title: '', value: 'delete' }
]
const options = ref({
	page: 1,
	itemsPerPage: 5,
	sortBy: [],
	sortDesc: []
})

//#region pagination and ordering

const updateTableData = () => {
	let sortedItems = [...purposes.value]
	totalItems.value = purposes.value.length
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

//#region Add Config

const newPurpose = ref({
	name: '',
	description: ''
})
const addSubmit = () => {
	addPurpose(newPurpose.value)
	newPurpose.value.name = ''
	newPurpose.value.description = ''
}

//#endregion

//#region Edit Config

const updatedPurpose = ref({
	name: '',
	description: ''
})
const populateEdit = (purpose) => (updatedPurpose.value = purpose)
const editSubmit = () => {
	editPurpose(updatedPurpose.value)
	updatedPurpose.value.name = ''
	updatedPurpose.value.description = ''
}

//#endregion

//#region Delete Config

const deleteRecord = (purpose) => deletePurpose(purpose)

//#endregion
</script>
