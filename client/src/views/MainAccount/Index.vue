<template>
	<v-container>
		<v-row> <h2>Main Accounts</h2></v-row>
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
import { ref, watch } from 'vue'

//#region GET call

const { mainAccounts, getter } = getMainAccounts()

watch(
	mainAccounts,
	async () => {
		await getter()
		updateTableData()
	},
	{ immediate: true, deep: true }
)

//#endregion

//#region pagination and ordering

const paginatedItems = ref([]) // Data to show in the table
const totalItems = ref(0)
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

const updateTableData = () => {
	let sortedItems = [...mainAccounts.value]
	totalItems.value = mainAccounts.value.length
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

const newMainAccount = ref({
	name: '',
	accountNumber: '',
	description: ''
})
const addSubmit = () => {
	addMainAccount(newMainAccount.value)
	newMainAccount.value.name = ''
	newMainAccount.value.accountNumber = ''
	newMainAccount.value.description = ''
}

//#endregion

//#region Edit Config

const updatedMainAccount = ref({
	name: '',
	accountNumber: '',
	description: ''
})
const populateEdit = (mainAccount) => (updatedMainAccount.value = mainAccount)
const editSubmit = () => {
	editMainAccount(updatedMainAccount.value)
	updatedMainAccount.value.name = ''
	updatedMainAccount.value.accountNumber = ''
	updatedMainAccount.value.description = ''
}

//#endregion

//#region Delete Config

const deleteRecord = (mainAccount) => deleteMainAccount(mainAccount)

//#endregion
</script>