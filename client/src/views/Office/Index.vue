<template>
	<v-container>
		<v-row>
			<v-col>
				<h2>Offices</h2>
			</v-col>
		</v-row>
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
					<h3>Add Office</h3>
					<form @submit.prevent="addSubmit">
						<div>
							<label>Name: </label>
							<input type="text" v-model="newOffice.name" />
						</div>
						<div>
							<label>Description: </label>
							<input type="text" v-model="newOffice.description" />
						</div>
						<div>
							<v-btn type="submit">Add</v-btn>
							<v-btn @click="emptyAddInputs()">Cancel</v-btn>
						</div>
					</form>
				</section>

				<section class="edit">
					<span v-if="updatedOffice.name.length > 0">
						<h3>Edit {{ updatedOffice.name }}</h3>
					</span>
					<span v-else><h3>Select Office to edit</h3></span>
					<form @submit.prevent="editSubmit">
						<div>
							<label>Name: </label>
							<input type="text" v-model="updatedOffice.name" />
						</div>
						<div>
							<label>Description: </label>
							<input type="text" v-model="updatedOffice.description" />
						</div>
						<div>
							<v-btn type="submit">Edit</v-btn>
							<v-btn @click="emptyEditInputs()">Cancel</v-btn>
						</div>
					</form>
				</section>
			</v-col>
		</v-row>
	</v-container>
</template>

<script setup>
import { getOffices, addOffice, editOffice, deleteOffice } from '@/hooks/officeCRUD'
import { ref, watch } from 'vue'

//#region Get call

const { offices, getter } = getOffices()

watch(
	offices,
	async () => {
		await getter()
		updateTableData()
	},
	{ immediate: true, deep: true }
)

//#endregion

//#region pagination and ordering

const paginatedItems = ref([]) // Data to show in the table
const totalItems = ref(0)

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
const updateTableData = () => {
	let sortedItems = [...offices.value]
	totalItems.value = offices.value.length
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

const newOffice = ref({
	name: '',
	description: ''
})
function emptyAddInputs() {
	newOffice.value.name = ''
	newOffice.value.description = ''
}
const addSubmit = () => {
	addOffice(newOffice.value)
	emptyAddInputs()
}

//#endregion

//#region Edit Config

const updatedOffice = ref({
	name: '',
	description: ''
})
function emptyEditInputs() {
	updatedOffice.value.name = ''
	updatedOffice.value.description = ''
}
const populateEdit = (office) => (updatedOffice.value = office)
const editSubmit = () => {
	editOffice(updatedOffice.value)
	emptyEditInputs()
}

//#endregion

//#region Delete Config

const deleteRecord = (office) => deleteOffice(office)

//#endregion
</script>
