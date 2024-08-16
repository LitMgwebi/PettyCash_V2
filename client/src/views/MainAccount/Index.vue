<template>
	<v-container>
		<v-row> <h2>Main Accounts</h2></v-row>
		<v-row>
			<v-col>
				<v-data-table-server :headers="headers" :items="mainAccounts">
					<template v-slot:[`item.edit`]="{ item }">
						<v-btn @click="populateEdit(item)">Edit</v-btn>
						<v-btn @click="deleteRecord(item)">Delete</v-btn>
					</template>
				</v-data-table-server>
			</v-col>
			<v-col>
				<section class="create">
					<h3>Add Main Account</h3>
					<form @submit.prevent="addSubmit">
						<div>
							<label>Name: </label>
							<input type="text" v-model="newMainAccount.name" />
						</div>
						<div>
							<label>Account Number: </label>
							<input type="text" v-model="newMainAccount.accountNumber" />
						</div>
						<div>
							<label>Description: </label>
							<input type="text" v-model="newMainAccount.description" />
						</div>
						<div class="submit">
							<button>Add</button>
							<button @click="reloadPage">Cancel</button>
						</div>
					</form>
				</section>

				<section class="edit">
					<span v-if="updatedMainAccount.name.length > 0">
						<h3>Edit {{ updatedMainAccount.name }}</h3>
					</span>
					<span v-else><h3>Select Main Account to edit</h3></span>
					<form @submit.prevent="editSubmit">
						<div>
							<label>Name: </label>
							<input type="text" v-model="updatedMainAccount.name" />
						</div>
						<div>
							<label>Account Number: </label>
							<input type="text" v-model="updatedMainAccount.accountNumber" />
						</div>
						<div>
							<label>Description: </label>
							<input type="text" v-model="updatedMainAccount.description" />
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
	getMainAccounts,
	editMainAccount,
	deleteMainAccount,
	addMainAccount
} from '@/hooks/mainAccountCRUD'
import { ref } from 'vue'

const reloadPage = () => location.reload()
const { mainAccounts } = getMainAccounts()
const headers = [
	{ title: 'Name', value: 'name' },
	{ title: 'Account Number', value: 'accountNumber' },
	{ title: '', value: 'edit' },
	{ title: '', value: 'delete' }
]

//#region Add Config

const newMainAccount = ref({
	name: '',
	accountNumber: '',
	description: ''
})
const addSubmit = () => addMainAccount(newMainAccount.value)

//#endregion

//#region Edit Config

const updatedMainAccount = ref({
	name: '',
	accountNumber: '',
	description: ''
})
const populateEdit = (mainAccount) => (updatedMainAccount.value = mainAccount)
const editSubmit = () => editMainAccount(updatedMainAccount.value)

//#endregion

//#region Delete Config

const deleteRecord = (mainAccount) => deleteMainAccount(mainAccount)

//#endregion
</script>