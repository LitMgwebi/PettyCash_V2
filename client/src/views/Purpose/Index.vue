<template>
	<h2>Purposes</h2>
	<aside>
		<section class="table">
			<div v-for="purpose in purposes" :key="purpose">
				<span class="module">
					{{ purpose.name }}
					<span v-if="purpose.description != null">
						{{ purpose.description }}
					</span>
				</span>
				<button @click="populateEdit(purpose)">Edit</button>
				<button @click="deleteRecord(purpose)">Delete</button>
			</div>
		</section>
	</aside>

	<aside>
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
	</aside>
</template>

<script setup>
import { getPurposes, addPurpose, editPurpose, deletePurpose } from '@/hooks/purposeCRUD'
import { ref } from 'vue'

const reloadPage = () => window.location.reload()
const { purposes } = getPurposes()

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
