<template>
	<h2>Petty Cash Requisition form</h2>

	<form @submit.prevent="handleSubmit">
		<div>
			<label>Amount Requested: </label>
			<input type="text" v-model="requisition.amountRequested" />
		</div>
		<div>
			<label>Description: </label>
			<textarea type="text" v-model="requisition.description" />
		</div>
		<div class="dropdown">
			<label>GL Accounts: </label>
			<select :disabled="glAccounts.length == 0" v-model="requisition.glAccount">
				<option value="" disabled>Select a GL account</option>
				<option
					v-for="glAccount in glAccounts"
					:value="glAccount.glAccountId"
					:key="glAccount.glAccountId"
				>
					{{ glAccount.name }} - {{ glAccount.description }}
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

const user = inject('User')
const reloadPage = () => location.reload()
const requisition = ref({
	glAccount: null,
	applicantId: user.id,
	amountRequested: null,
	description: ''
})

const { glAccounts } = getGLAccountsByDepartment(user.departmentId)

function handleSubmit() {
	addRequisition(requisition.value)
	router.push('/requisitions')
}
</script>