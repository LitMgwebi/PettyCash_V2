<template>
	<form @submit.prevent="handleSubmit">
		<div><h2>Register</h2></div>

		<section class="input-field">
			<label>First Name: </label>
			<input type="text" v-model="userDetails.firstName" required />
		</section>

		<section class="input-field">
			<label>Last Name: </label>
			<input type="text" v-model="userDetails.lastName" required />
		</section>

		<section class="input-field">
			<label>Username: </label>
			<input type="text" v-model="userDetails.username" required />
		</section>

		<section class="input-field">
			<label>Phone Number: </label>
			<input type="tel" v-model="userDetails.phoneNumber" required />
		</section>

		<section class="input-field">
			<label>Email: </label>
			<input type="email" v-model="userDetails.email" required />
		</section>

		<section class="input-field">
			<label>ID Number: </label>
			<input type="text" v-model="userDetails.idNumber" required />
		</section>

		<section class="input-field">
			<label>Password: </label>
			<input type="password" v-model="userDetails.passwordHash" required />
		</section>
		<div class="dropdown">
			<label>Offices: </label>
			<select :disabled="offices.length == 0" v-model="userDetails.officeId">
				<option value="" disabled>Select an office</option>
				<option v-for="office in offices" :value="office.officeId" :key="office.officeId">
					{{ office.name }}
				</option>
			</select>
		</div>
		<div class="dropdown">
			<label>Divisions: </label>
			<select :disabled="divisions.length == 0" v-model="userDetails.divisionId">
				<option value="" disabled>Select a division</option>
				<option
					v-for="division in divisions"
					:value="division.divisionId"
					:key="division.divisionId"
				>
					{{ division.description }}
				</option>
			</select>
		</div>
		<div class="dropdown">
			<label>Job Titles: </label>
			<select :disabled="jobTitles.length == 0" v-model="userDetails.jobTitleId">
				<option value="" disabled>Select a job titles</option>
				<option
					v-for="jobTitle in jobTitles"
					:value="jobTitle.jobTitleId"
					:key="jobTitle.jobTitleId"
				>
					{{ jobTitle.description }}
				</option>
			</select>
		</div>
		<div class="submit">
			<button>Register</button>
		</div>
	</form>
</template>

<script setup>
import { register } from '@/hooks/userCRUD'
import { getOffices } from '@/hooks/officeCRUD'
import { getDivisions } from '@/hooks/divisionCRUD'
import { getJobTitles } from '@/hooks/jobTotleCRUD'
import { ref, watch, onMounted } from 'vue'

const userDetails = ref({
	firstName: '',
	lastName: '',
	idNumber: '',
	email: '',
	username: '',
	phoneNumber: '',
	idNumber: '',
	passwordHash: '',
	officeId: '',
	divisionId: '',
	jobTitleId: ''
})

const { offices, getter: officeGetter } = getOffices()
const { divisions, getter: divisionGetter } = getDivisions()
const { jobTitles, getter: jobTitleGetter } = getJobTitles()

onMounted(async () => {
	await officeGetter()
	await divisionGetter()
	await jobTitleGetter()
})

watch(async () => {
	await officeGetter()
	await divisionGetter()
	await jobTitleGetter()
})

function handleSubmit() {
	register(userDetails.value)
}
</script>