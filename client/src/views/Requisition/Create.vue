<template>
	<h2>Petty Cash Requisition form</h2>

	<form @submit.prevent="handleSubmit">
		<div>
			<label>Amount Requested: </label>
			<input type="text" v-model="requisition.amountRequested" />
		</div>
		<div v-if="requisition.amountRequested >= 2000 || glAccount.NeedsMotivation == true">
			<label>Motivation </label>
			<input type="text" v-model="requisition.file" required />
		</div>
		<div>
			<label>Description: </label>
			<textarea type="text" v-model="requisition.description" />
		</div>
		<div class="dropdown">
			<label>GL Accounts: </label>
			<select :disabled="glAccounts.length == 0" v-model="requisition.glaccountId">
				<option value="" disabled>Select a GL account</option>
				<option
					v-for="glAccount in glAccounts"
					:value="glAccount.glaccountId"
					:key="glAccount.glaccountId"
				>
					{{ glAccount.description }}
				</option>
			</select>
		</div>
		<div class="submit">
			<button>Add</button>
			<button @click="reloadPage">Cancel</button>
		</div>
	</form>
</template>

<script setup>
import { getGLAccountsByDepartment } from '@/hooks/glAccountCRUD'
import { inject, ref } from 'vue'
import { addRequisition } from '@/hooks/requisitionCRUD'
import router from '@/router/router'

const reloadPage = () => location.reload()
const requisition = ref({
	glaccountId: '',
	applicantId: '',
	amountRequested: 0,
	description: '',
	file: ''
})
const { glAccounts } = getGLAccountsByDepartment()

function handleSubmit() {
	addRequisition(requisition.value)
	router.push('/requisitions')
}
</script>