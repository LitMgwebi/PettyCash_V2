<template>
	<v-container>
		<v-row> <h2>Sub-Accounts</h2></v-row>
		<v-row>
			<v-col>
				<v-data-table-server :headers="headers" :items="subAccounts">
					<template v-slot:[`item.edit`]="{ item }">
						<v-btn @click="populateEdit(item)">Edit</v-btn>
						<v-btn @click="deleteRecord(item)">Delete</v-btn>
					</template>
				</v-data-table-server>
			</v-col>
			<v-col>
				<section class="create">
					<h3>Add Sub-Account</h3>
					<form @submit.prevent="addSubmit">
						<div>
							<label>Name: </label>
							<input type="text" v-model="newSubAccount.name" />
						</div>
						<div>
							<label>Account Number: </label>
							<input type="text" v-model="newSubAccount.accountNumber" />
						</div>
						<div>
							<label>Description: </label>
							<input type="text" v-model="newSubAccount.description" />
						</div>
						<div class="submit">
							<button>Add</button>
							<button @click="reloadPage">Cancel</button>
						</div>
					</form>
				</section>

				<section class="edit">
					<span v-if="updatedSubAccount.name.length > 0">
						<h3>Edit {{ updatedSubAccount.name }}</h3>
					</span>
					<span v-else><h3>Select Sub-Account to edit</h3></span>
					<form @submit.prevent="editSubmit">
						<div>
							<label>Name: </label>
							<input type="text" v-model="updatedSubAccount.name" />
						</div>
						<div>
							<label>Account Number: </label>
							<input type="text" v-model="updatedSubAccount.accountNumber" />
						</div>
						<div>
							<label>Description: </label>
							<input type="text" v-model="updatedSubAccount.description" />
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
import {
	getSubAccounts,
	editSubAccount,
	deleteSubAccount,
	addSubAccount
} from '@/hooks/subAccountCRUD'
import { ref, onMounted, watch } from 'vue'

const reloadPage = () => location.reload()

const { subAccounts, getter } = getSubAccounts()
onMounted(async () => await getter())

watch(async () => await getter())

const headers = [
	{ title: 'Name', value: 'name' },
	{ title: 'Account Number', value: 'accountNumber' },
	{ title: '', value: 'edit' },
	{ title: '', value: 'delete' }
]

//#region Add Config

const newSubAccount = ref({
	name: '',
	accountNumber: '',
	description: ''
})
const addSubmit = () => addSubAccount(newSubAccount.value)

//#endregion

//#region Edit Config

const updatedSubAccount = ref({
	name: '',
	accountNumber: '',
	description: ''
})
const populateEdit = (subAccount) => (updatedSubAccount.value = subAccount)
const editSubmit = () => editSubAccount(updatedSubAccount.value)

//#endregion

//#region Delete Config

const deleteRecord = (subAccount) => deleteSubAccount(subAccount)

//#endregion
</script>