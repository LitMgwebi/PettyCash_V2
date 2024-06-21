<template>
	<h2>Main Accounts</h2>
	<aside>
		<section class="table">
			<div v-for="mainAccount in mainAccounts" :key="mainAccount">
				<span class="module">
					{{ mainAccount.name }} - {{ mainAccount.accountNumber }}
					<span v-if="mainAccount.description != null">
						{{ mainAccount.description }}
					</span>
				</span>
				<button @click="populateEdit(mainAccount)">Edit</button>
				<button @click="deleteRecord(mainAccount)">Delete</button>
			</div>
		</section>
	</aside>
	<aside>
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
	</aside>
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