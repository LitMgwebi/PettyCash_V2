<template>
	<h2>Divisions</h2>
	<aside>
		<section class="table">
			<div v-for="division in divisions" :key="division">
				<span class="module">
					{{ division.name }}
					<span v-if="division.description != null">
						{{ division.description }}
					</span>
				</span>
				<button @click="populateEdit(division)">Edit</button>
				<button @click="deleteRecord(division)">Delete</button>
			</div>
		</section>
	</aside>
	<aside>
		<section class="create">
			<h3>Add Division</h3>
			<form @submit.prevent="addSubmit">
				<div>
					<label>Name: </label>
					<input type="text" v-model="newDivision.name" />
				</div>
				<div>
					<label>Description: </label>
					<input type="text" v-model="newDivision.description" />
				</div>
				<div class="dropdown">
					<label>Departments: </label>
					<select :disabled="departments.length == 0" v-model="newDivision.departmentId">
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
				<div class="submit">
					<button>Add</button>
					<button @click="reloadPage">Cancel</button>
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
					<label>Name: </label>
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
				<div class="submit">
					<button>Edit</button>
					<button @click="reloadPage">Cancel</button>
				</div>
			</form>
		</section>
	</aside>
</template>

<script setup>
import { getDivisions, editDivision, addDivision, deleteDivision } from '@/hooks/divisionCRUD'
import { getDepartments } from '@/hooks/departmentCRUD'
import { ref } from 'vue'

const reloadPage = () => location.reload()
const { divisions } = getDivisions()
const { departments } = getDepartments()

//#region Add Config

const newDivision = ref({
	name: '',
	description: '',
	departmentId: ''
})
const addSubmit = () => addDivision(newDivision.value)

//#endregion

//#region Edit Config

const updatedDivision = ref({
	name: '',
	description: '',
	departmentId: ''
})
const populateEdit = (division) => (updatedDivision.value = division)
const editSubmit = () => editDivision(updatedDivision.value)

//#endregion

//#region Delete Config

const deleteRecord = (division) => deleteDivision(division)

//#endregion
</script>