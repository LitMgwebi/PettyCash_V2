<template>
	<v-container>
		<v-row> <h2>Offices</h2> </v-row>
		<v-row>
			<v-col>
				<v-data-table-server :headers="headers" :items="offices">
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
						<div class="submit">
							<button>Add</button>
							<button @click="reloadPage">Cancel</button>
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
import { getOffices, addOffice, editOffice, deleteOffice } from '@/hooks/officeCRUD'
import { ref } from 'vue'

const reloadPage = () => location.reload()
const { offices } = getOffices()

const headers = [
	{ title: 'Name', value: 'name' },
	{ title: 'Description', value: 'description' },
	{ title: '', value: 'edit' },
	{ title: '', value: 'delete' }
]

//#region Add Config

const newOffice = ref({
	name: '',
	description: ''
})
const addSubmit = () => addOffice(newOffice.value)

//#endregion

//#region Edit Config

const updatedOffice = ref({
	name: '',
	description: ''
})
const populateEdit = (office) => (updatedOffice.value = office)
const editSubmit = () => editOffice(updatedOffice.value)

//#endregion

//#region Delete Config

const deleteRecord = (office) => deleteOffice(office)

//#endregion
</script>
