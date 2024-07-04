<template>
	<h2>GL Accounts</h2>
	<aside>
		<section class="table">
			<div v-for="glAccount in glAccounts" :key="glAccount">
				<span class="module">
					{{ glAccount.name }} -
					<span v-if="glAccount.description != null">
						{{ glAccount.description }}
					</span>
				</span>
				<button @click="populateEdit(glAccount)">Edit</button>
				<button @click="deleteRecord(glAccount)">Delete</button>
			</div>
		</section>
	</aside>

	<aside>
		<section class="create">
			<h3>Add GL Account</h3>
			<form @submit.prevent="addSubmit">
				<!-- <div>
					<label>Name: </label>
					<input type="text" v-model="newGLAccount.name" />
				</div> -->
				<div class="dropdown">
					<label>Main Accounts: </label>
					<select
						:disabled="mainAccounts.length == 0"
						v-model="newGLAccount.mainAccountId"
					>
						<option value="" disabled>Select an account</option>
						<option
							v-for="mainAccount in mainAccounts"
							:value="mainAccount.mainAccountId"
							:key="mainAccount.mainAccountId"
						>
							{{ mainAccount.name }}
						</option>
					</select>
				</div>
				<div class="dropdown">
					<label>Sub Accounts: </label>
					<select :disabled="subAccounts.length == 0" v-model="newGLAccount.subAccountId">
						<option value="" disabled>Select a sub account</option>
						<option
							v-for="subAccount in subAccounts"
							:value="subAccount.subAccountId"
							:key="subAccount.subAccountId"
						>
							{{ subAccount.name }}
						</option>
					</select>
				</div>
				<div class="dropdown">
					<label>Divisions: </label>
					<select :disabled="divisions.length == 0" v-model="newGLAccount.divisionId">
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
					<label>Purposes: </label>
					<select :disabled="purposes.length == 0" v-model="newGLAccount.purposeId">
						<option value="" disabled>Select an office</option>
						<option
							v-for="purpose in purposes"
							:value="purpose.purposeId"
							:key="purpose.purposeId"
						>
							{{ purpose.description }}
						</option>
					</select>
				</div>
				<div class="dropdown">
					<label>Offices: </label>
					<select :disabled="offices.length == 0" v-model="newGLAccount.officeId">
						<option value="" disabled>Select an office</option>
						<option
							v-for="office in offices"
							:value="office.officeId"
							:key="office.officeId"
						>
							{{ office.description }}
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
			<span v-if="updatedGLAccount.name.length > 0">
				<h3>Edit {{ updatedGLAccount.name }}</h3>
			</span>
			<span v-else><h3>Select GL Account to edit</h3></span>
			<form @submit.prevent="editSubmit">
				<!-- <div>
					<label>Name: </label>
					<input type="text" v-model="updatedGLAccount.name" />
				</div> -->
				<div class="dropdown">
					<label>Main Accounts: </label>
					<select
						:disabled="mainAccounts.length == 0"
						v-model="updatedGLAccount.mainAccountId"
					>
						<option value="" disabled>Select an account</option>
						<option
							v-for="mainAccount in mainAccounts"
							:value="mainAccount.mainAccountId"
							:key="mainAccount.mainAccountId"
						>
							{{ mainAccount.name }}
						</option>
					</select>
				</div>
				<div class="dropdown">
					<label>Sub Accounts: </label>
					<select
						:disabled="subAccounts.length == 0"
						v-model="updatedGLAccount.subAccountId"
					>
						<option value="" disabled>Select a sub account</option>
						<option
							v-for="subAccount in subAccounts"
							:value="subAccount.subAccountId"
							:key="subAccount.subAccountId"
						>
							{{ subAccount.name }}
						</option>
					</select>
				</div>
				<div class="dropdown">
					<label>Divisions: </label>
					<select :disabled="divisions.length == 0" v-model="updatedGLAccount.divisionId">
						<option value="" disabled>Select a division</option>
						<option
							v-for="division in divisions"
							:value="division.divisionId"
							:key="division.divisionId"
						>
							{{ division.name }}
						</option>
					</select>
				</div>
				<div class="dropdown">
					<label>Purposes: </label>
					<select :disabled="purposes.length == 0" v-model="updatedGLAccount.purposeId">
						<option value="" disabled>Select an office</option>
						<option
							v-for="purpose in purposes"
							:value="purpose.purposeId"
							:key="purpose.purposeId"
						>
							{{ purpose.description }}
						</option>
					</select>
				</div>
				<div class="dropdown">
					<label>Offices: </label>
					<select :disabled="offices.length == 0" v-model="updatedGLAccount.officeId">
						<option value="" disabled>Select an office</option>
						<option
							v-for="office in offices"
							:value="office.officeId"
							:key="office.officeId"
						>
							{{ office.description }}
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
import { getGLAccounts, editGLAccount, addGLAccount, deleteGLAccount } from '@/hooks/glAccountCRUD'
import { getOffices } from '@/hooks/officeCRUD'
import { getSubAccounts } from '@/hooks/subAccountCRUD'
import { getMainAccounts } from '@/hooks/mainAccountCRUD'
import { getPurposes } from '@/hooks/purposeCRUD'
import { getDivisions } from '@/hooks/divisionCRUD'
import { ref } from 'vue'

const { offices } = getOffices()
const { subAccounts } = getSubAccounts()
const { mainAccounts } = getMainAccounts()
const { purposes } = getPurposes()
const { divisions } = getDivisions()
const reloadPage = () => location.reload()
const { glAccounts } = getGLAccounts()

//#region Add Config

const newGLAccount = ref({
	name: '',
	mainAccountId: '',
	subAccountId: '',
	divisionId: '',
	purposeId: '',
	officeId: ''
})
const addSubmit = () => addGLAccount(newGLAccount.value)

//#endregion

//#region Edit Config

const updatedGLAccount = ref({
	name: '',
	mainAccountId: '',
	subAccountId: '',
	divisionId: '',
	purposeId: '',
	officeId: ''
})
const populateEdit = (glAccount) => (updatedGLAccount.value = glAccount)
const editSubmit = () => editGLAccount(updatedGLAccount.value)

//#endregion

//#region Delete Config

const deleteRecord = (glAccount) => deleteGLAccount(glAccount)

//#endregion
</script>