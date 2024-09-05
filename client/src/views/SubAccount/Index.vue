<template>
	<v-container>
		<v-row> <h2>Sub-Accounts</h2></v-row>
		<v-row>
			<v-col>
				<v-data-table-server
					v-model:items-per-page="options.itemsPerPage"
					v-model:page="options.page"
					:headers="headers"
					:items="paginatedItems"
					:items-length="totalItems"
				>
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
import { ref, watch } from 'vue'

const paginatedItems = ref([]) // Data to show in the table
const totalItems = ref(0)
const { subAccounts, getter } = getSubAccounts()

watch(
	subAccounts,
	async () => {
		await getter()
		updateTableData()
	},
	{ immediate: true, deep: true }
)

const headers = [
	{ title: 'Name', value: 'name' },
	{ title: 'Account Number', value: 'accountNumber' },
	{ title: '', value: 'edit' },
	{ title: '', value: 'delete' }
]
const options = ref({
	page: 1,
	itemsPerPage: 5,
	sortBy: [],
	sortDesc: []
})

//#region pagination and ordering

const updateTableData = () => {
	let sortedItems = [...subAccounts.value]
	totalItems.value = subAccounts.value.length
	// Handle sorting
	if (options.value.sortBy.length > 0) {
		const sortKey = options.value.sortBy[0]
		const sortDesc = options.value.sortDesc[0]

		sortedItems.sort((a, b) => {
			if (a[sortKey] < b[sortKey]) return sortDesc ? 1 : -1
			if (a[sortKey] > b[sortKey]) return sortDesc ? -1 : 1
			return 0
		})
	}

	// Handle pagination
	const start = (options.value.page - 1) * options.value.itemsPerPage
	const end = start + options.value.itemsPerPage
	paginatedItems.value = sortedItems.slice(start, end)
}

//#endregion

//#region Add Config

const newSubAccount = ref({
	name: '',
	accountNumber: '',
	description: ''
})
const addSubmit = () => {
	addSubAccount(newSubAccount.value)
	newSubAccount.value.name = ''
	newSubAccount.value.accountNumber = ''
	newSubAccount.value.description = ''
}

//#endregion

//#region Edit Config

const updatedSubAccount = ref({
	name: '',
	accountNumber: '',
	description: ''
})
const populateEdit = (subAccount) => (updatedSubAccount.value = subAccount)
const editSubmit = () => {
	editSubAccount(updatedSubAccount.value)
	updatedSubAccount.value.name = ''
	updatedSubAccount.value.accountNumber = ''
	updatedSubAccount.value.description = ''
}

//#endregion

//#region Delete Config

const deleteRecord = (subAccount) => deleteSubAccount(subAccount)

//#endregion
</script>