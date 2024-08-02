<template>
	<h2>Transactions</h2>
	<aside>
		<section class="table">
			<div v-for="transaction in transactions" :key="transaction">
				<span>
					{{ transaction.transactionId }}
					- {{ transaction.amount }} - {{ transaction.transactionType }} -
					{{ transaction.transactionDate }}
					<span v-if="transaction.requisition">
						{{ transaction.requisition.applicant.fullName }}
					</span>
				</span>
			</div>
		</section>
	</aside>
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
</template>

<script setup>
import { getTransactions, addTransaction } from '@/hooks/transactionCRUD'
import { getVault } from '@/hooks/vaultCRUD'
import { ref, inject } from 'vue'

const reloadPage = () => location.reload()
const { transactions } = getTransactions()
const { vault } = getVault()
const typeOfTransaction = inject('typeOfTransaction')

//#region Add Transaction

const newTransaction = ref({
	amount: 0,
	transactionType: typeOfTransaction.Deposit,
	vaultId: vault.vaultId
})
const addSubmit = () => addTransaction(newTransaction.value)

//#endregion
</script>
