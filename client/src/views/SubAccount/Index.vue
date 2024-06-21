<template>
	<h2>Sub-Accounts</h2>
	<aside>
		<section class="table">
			<div v-for="subAccount in subAccounts" :key="subAccount">
				<span class="module">
					{{ subAccount.name }} - {{ subAccount.accountNumber }}
					<span v-if="subAccount.description != null">
						{{ subAccount.description }}
					</span>
				</span>
				<button @click="populateEdit(subAccount)">Edit</button>
				<button @click="deleteRecord(subAccount)">Delete</button>
			</div>
		</section>
	</aside>
	<aside>
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
	</aside>
</template>

<script setup>
import {
	getSubAccounts,
	editSubAccount,
	deleteSubAccount,
	addSubAccount
} from '@/hooks/subAccountCRUD'
import { ref } from 'vue'

const reloadPage = () => location.reload()
const { subAccounts } = getSubAccounts()

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