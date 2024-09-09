<template>
	<v-container>
		<v-row>
			<v-col>
				<h2>Divisions</h2>
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
					<h3>Add Division</h3>
					<form @submit.prevent="addSubmit">
						<div>
							<label>Title: </label>
							<input type="text" v-model="newDivision.name" />
						</div>
						<div>
							<label>Description: </label>
							<input type="text" v-model="newDivision.description" />
						</div>
						<div class="dropdown">
							<label>Departments: </label>
							<select
								:disabled="departments.length == 0"
								v-model="newDivision.departmentId"
							>
								<option value="" disabled>Select a department</option>
								<option
									v-for="department in departments"
									:value="department.departmentId"
									:key="department.departmentId"
								>
									{{ department.name }}
								</option>
							</select>
						</div>
						<div>
							<v-btn type="submit">Add</v-btn>
							<v-btn @click="emptyAddInputs()">Cancel</v-btn>
						</div>
					</form>
				</section>

				<section class="edit">
					<span v-if="updatedDivision.name.length > 0">
						<h3>Edit {{ updatedDivision.name }}</h3>
					</span>
					<span v-else><h3>Select Division to edit</h3></span>
					<form @submit.prevent="editSubmit">
						<div>
							<label>Title: </label>
							<input type="text" v-model="updatedDivision.name" />
						</div>
						<div>
							<label>Description: </label>
							<input type="text" v-model="updatedDivision.description" />
						</div>
						<div class="dropdown">
							<label>Department: </label>
							<select
								:disabled="departments.length == 0"
								v-model="updatedDivision.departmentId"
							>
								<option value="" disabled>Select an account</option>
								<option
									v-for="department in departments"
									:value="department.departmentId"
									:key="department.departmentId"
								>
									{{ department.name }}
								</option>
							</select>
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
import { getDivisions, editDivision, addDivision, deleteDivision } from '@/hooks/divisionCRUD'
import { getDepartments } from '@/hooks/departmentCRUD'
import { ref, onMounted, watch } from 'vue'

//#region Get call

const { divisions, getter: divisionGetter } = getDivisions()
const { departments, getter: departmentGetter } = getDepartments()

onMounted(async () => {
	await departmentGetter()
})
watch(
	divisions,
	async () => {
		await divisionGetter()
		updateTableData()
	},
	{ immediate: true, deep: true }
)

//#endregion

//#region pagination and ordering

const paginatedItems = ref([]) // Data to show in the table
const totalItems = ref(0)

const headers = [
	{ title: 'Title', value: 'name' },
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
	let sortedItems = [...divisions.value]
	totalItems.value = divisions.value.length
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

const newDivision = ref({
	name: '',
	description: '',
	departmentId: ''
})
const emptyAddInputs = () => {
	newDivision.value.name = ''
	newDivision.value.description = ''
}
const addSubmit = () => {
	addDivision(newDivision.value)
	emptyAddInputs()
}

//#endregion

//#region Edit Config

const updatedDivision = ref({
	name: '',
	description: '',
	departmentId: ''
})
const emptyEditInputs = () => {
	updatedDivision.value.name = ''
	updatedDivision.value.description = ''
}
const populateEdit = (division) => (updatedDivision.value = division)
const editSubmit = () => {
	editDivision(updatedDivision.value)
	emptyEditInputs()
}

//#endregion

//#region Delete Config

const deleteRecord = (division) => deleteDivision(division)

//#endregion
</script>