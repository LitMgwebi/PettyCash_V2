<template>
	<h2>Departments</h2>
	<aside>
		<section class="table">
			<div v-for="department in departments" :key="department">
				<span class="module">
					{{ department.name }}
					<span v-if="department.description != null">
						{{ department.description }}
					</span>
				</span>
				<button @click="populateEdit(department)">Edit</button>
				<button @click="deleteRecord(department)">Delete</button>
			</div>
		</section>
	</aside>
	<aside>
		<section class="create">
			<h3>Add Department</h3>
			<form @submit.prevent="addSubmit">
				<div>
					<label>Name: </label>
					<input type="text" v-model="newDepartment.name" />
				</div>
				<div>
					<label>Description: </label>
					<input type="text" v-model="newDepartment.description" />
				</div>
				<div class="submit">
					<button>Add</button>
					<button @click="reloadPage">Cancel</button>
				</div>
			</form>
		</section>

		<section class="edit">
			<span v-if="updatedDepartment.name.length > 0">
				<h3>Edit {{ updatedDepartment.name }}</h3>
			</span>
			<span v-else><h3>Select Department to edit</h3></span>
			<form @submit.prevent="editSubmit">
				<div>
					<label>Name: </label>
					<input type="text" v-model="updatedDepartment.name" />
				</div>
				<div>
					<label>Description: </label>
					<input type="text" v-model="updatedDepartment.description" />
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
import {
	getDepartments,
	editDepartment,
	addDepartment,
	deleteDepartment
} from '@/hooks/departmentCRUD'
import { ref } from 'vue'

const reloadPage = () => location.reload()
const { departments } = getDepartments()

//#region Add Config

const newDepartment = ref({
	name: '',
	description: ''
})
const addSubmit = () => addDepartment(newDepartment.value)

//#endregion

//#region Edit Config

const updatedDepartment = ref({
	name: '',
	description: ''
})
const populateEdit = (department) => (updatedDepartment.value = department)
const editSubmit = () => editDepartment(updatedDepartment.value)

//#endregion

//#region Delete Config

const deleteRecord = (department) => deleteDepartment(department)

//#endregion
</script>