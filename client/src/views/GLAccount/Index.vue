<template>
	<v-container>
		<v-row><h2>GL Accounts</h2></v-row>
		<v-row>
			<v-col>
				<section class="table">
					<v-data-table-server :headers="headers" :items="glAccounts">
						<template v-slot:[`item.edit`]="{ item }">
							<v-btn @click="populateEdit(item)">Edit</v-btn>
							<v-btn @click="deleteRecord(item)">Delete</v-btn>
						</template>
					</v-data-table-server>
				</section>
			</v-col>

			<v-col>
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
							<select
								:disabled="subAccounts.length == 0"
								v-model="newGLAccount.subAccountId"
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
							<select
								:disabled="divisions.length == 0"
								v-model="newGLAccount.divisionId"
							>
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
							<select
								:disabled="purposes.length == 0"
								v-model="newGLAccount.purposeId"
							>
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
						<div class="dropdown">
							<label>Does this account need Motivation?: </label>
							<select
								:disabled="newGLAccount.length != null"
								v-model="newGLAccount.needsMotivation"
							>
								<option value="" disabled>Please select</option>
								<option :value="true">Yes</option>
								<option :value="false">No</option>
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
							<select
								:disabled="divisions.length == 0"
								v-model="updatedGLAccount.divisionId"
							>
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
							<select
								:disabled="purposes.length == 0"
								v-model="updatedGLAccount.purposeId"
							>
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
							<select
								:disabled="offices.length == 0"
								v-model="updatedGLAccount.officeId"
							>
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
						<div class="dropdown">
							<label>Does this account need Motivation?: </label>
							<select
								:disabled="updatedGLAccount.length != null"
								v-model="updatedGLAccount.needsMotivation"
							>
								<option value="" disabled>Please select</option>
								<option :value="true">Yes</option>
								<option :value="false">No</option>
							</select>
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
import { getGLAccounts, editGLAccount, addGLAccount, deleteGLAccount } from '@/hooks/glAccountCRUD'
import { getOffices } from '@/hooks/officeCRUD'
import { getSubAccounts } from '@/hooks/subAccountCRUD'
import { getMainAccounts } from '@/hooks/mainAccountCRUD'
import { getPurposes } from '@/hooks/purposeCRUD'
import { getDivisions } from '@/hooks/divisionCRUD'
import { ref, inject } from 'vue'

const { offices } = getOffices()
const { subAccounts } = getSubAccounts()
const { mainAccounts } = getMainAccounts()
const { purposes } = getPurposes()
const { divisions } = getDivisions()
const typeOfGLGet = inject('typeOfGLGet')
const reloadPage = () => location.reload()
const { glAccounts } = getGLAccounts(typeOfGLGet.All)
// TODO introduce filter to this page using divisions
const headers = [
	{ title: 'Name', value: 'name' },
	{ title: 'Description', value: 'description' },
	{ title: '', value: 'edit' },
	{ title: '', value: 'delete' }
]

//#region Add Config

const newGLAccount = ref({
	name: '',
	mainAccountId: '',
	subAccountId: '',
	divisionId: '',
	purposeId: '',
	officeId: '',
	needsMotivation: false
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
	officeId: '',
	needsMotivation: ''
})
const populateEdit = (glAccount) => (updatedGLAccount.value = glAccount)
const editSubmit = () => editGLAccount(updatedGLAccount.value)

//#endregion

//#region Delete Config

const deleteRecord = (glAccount) => deleteGLAccount(glAccount)

//#endregion
</script>