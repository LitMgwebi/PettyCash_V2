<template>
	<h2>Offices</h2>
	<aside>
		<section class="table">
			<div v-for="office in offices" :key="office">
				<span class="module">
					{{ office.name }}
					<span v-if="office.description != null">
						{{ office.description }}
					</span>
				</span>
				<button @click="populateEdit(office)">Edit</button>
				<button @click="deleteRecord(office)">Delete</button>
			</div>
		</section>
	</aside>
	<aside>
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
	</aside>
</template>

<script setup>
import { getOffices, addOffice, editOffice, deleteOffice } from '@/hooks/officeCRUD'
import { ref } from 'vue'

const reloadPage = () => location.reload()
const { offices } = getOffices()

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
