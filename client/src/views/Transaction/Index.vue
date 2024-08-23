<template>
	<v-container>
		<v-row>
			<v-col>
				<h2>Transactions</h2>
			</v-col>
			<v-col>
				<section>
					<label>Filter</label>
					<select :disabled="arrayOfTypes.length == 0" v-model="transactionFilter">
						<option v-for="type in arrayOfTypes" :value="type" :key="type">
							{{ type.type }}
						</option>
					</select>
				</section>
			</v-col>
		</v-row>
		<v-row>
			<v-col>
				<v-data-table-server :headers="headers" :items="transactions">
				</v-data-table-server>
			</v-col>
			<v-col>
				<aside v-if="vault">
					<h3>Vault</h3>
					<div>Current Amount: {{ vault.currentAmount }}</div>
				</aside>
				<aside>
					<section class="create">
						<h3>Deposit Money</h3>
						<form @submit.prevent="addSubmit">
							<div>
								<label>Amount: </label>
								<input type="text" v-model="newTransaction.amount" />
							</div>
							<div class="submit">
								<button>Deposit</button>
								<button @click="reloadPage">Cancel</button>
							</div>
						</form>
					</section>
				</aside>
			</v-col>
		</v-row>
	</v-container>
</template>

<script setup>
import { getTransactions, addTransaction } from '@/hooks/transactionCRUD'
import { getVault } from '@/hooks/vaultCRUD'
import { ref, inject, onMounted, watch } from 'vue'
import router from '@/router/router'

const reloadPage = () => location.reload()
const typeOfTransaction = inject('typeOfTransaction')
const { transactions, getter: transactionGetter } = getTransactions()
const { vault, getter: vaultGetter } = getVault()

const transactionFilter = ref({
	type: 'All'
})
const arrayOfTypes = ref([
	{ type: typeOfTransaction.All },
	{ type: typeOfTransaction.Deposit },
	{ type: typeOfTransaction.Change },
	{ type: typeOfTransaction.Withdrawal }
])

onMounted(async () => {
	await transactionGetter(transactionFilter.value.type)
	await vaultGetter()
})

watch(async () => {
	await transactionGetter(transactionFilter.value.type)
	await vaultGetter()
})

const headers = [
	{ title: 'ID', value: 'transactionId' },
	{ title: 'Amount', value: 'amount' },
	{ title: 'Transaction Type', value: 'transactionType' },
	// TODO Find a way to output the user who initiated transaction
	// { title: 'User', value: 'requisition.applicant.fullName' },
	{ title: '', value: 'edit' },
	{ title: '', value: 'delete' }
]

//#region Add Transaction

const newTransaction = ref({
	amount: 0,
	transactionType: typeOfTransaction.Deposit,
	vaultId: vault.vaultId
})
const addSubmit = () => {
	addTransaction(newTransaction.value)
	router.push({ name: 'transactions' })
}

//#endregion
</script>
