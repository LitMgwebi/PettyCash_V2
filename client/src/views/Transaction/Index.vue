<template>
	<v-container>
		<v-row> <h2>Transactions</h2></v-row>
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
const { transactions, getter } = getTransactions()

onMounted(async () => await getter())

// TODO Filter for Withdrawal and Deposit type
watch(async () => await getter())

const { vault } = getVault()
const headers = [
	{ title: 'ID', value: 'transactionId' },
	{ title: 'Amount', value: 'amount' },
	{ title: 'Transaction Type', value: 'transactionType' },
	// TODO Find a way to output the user who initiated transaction
	// { title: 'User', value: 'requisition.applicant.fullName' },
	{ title: '', value: 'edit' },
	{ title: '', value: 'delete' }
]
const typeOfTransaction = inject('typeOfTransaction')

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
