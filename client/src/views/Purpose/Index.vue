<template>
	<v-container>
		<v-row><h2>Purposes</h2></v-row>
		<v-row>
			<v-col>
				<v-data-table-server :headers="headers" :items="purposes">
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
import { onMounted, ref, watch } from 'vue'

const reloadPage = () => window.location.reload()
const { purposes, getter } = getPurposes()

onMounted(async () => await getter())
watch(async () => await getter())

const headers = [
	{ title: 'Name', value: 'name' },
	{ title: 'Description', value: 'description' },
	{ title: '', value: 'edit' },
	{ title: '', value: 'delete' }
]

//#region Add Config

const newPurpose = ref({
	name: '',
	description: ''
})
const addSubmit = () => addPurpose(newPurpose.value)

//#endregion

//#region Edit Config

const updatedPurpose = ref({
	name: '',
	description: ''
})
const populateEdit = (purpose) => (updatedPurpose.value = purpose)
const editSubmit = () => editPurpose(updatedPurpose.value)

//#endregion

//#region Delete Config

const deleteRecord = (purpose) => deletePurpose(purpose)

//#endregion
</script>
