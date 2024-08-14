<template>
	<h2>Petty Cash Requisition form</h2>

	<form @submit.prevent="handleSubmit">
		<div>
			<label>Amount Requested: </label>
			<input type="text" v-model="requisition.amountRequested" />
		</div>
		<!-- <div v-if="requisition.amountRequested >= 2000">
			<label>Motivation </label>
			<input type="text" v-model="requisition.file" required />
		</div> -->
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
					{{ glAccount.name }}
				</option>
			</select>
		</div>
		<div class="submit">
			<button>Add</button>
			<router-link :to="{ name: 'requisitions' }"> Cancel </router-link>
		</div>
	</form>
</template>

<script setup>
import { getGLAccounts } from '@/hooks/glAccountCRUD'
import { inject, ref } from 'vue'
import { addRequisition } from '@/hooks/requisitionCRUD'
import router from '@/router/router'

const reloadPage = () => location.reload()
const typeOfGLGet = inject('typeOfGLGet')
const requisition = ref({
	glaccountId: '',
	applicantId: '',
	amountRequested: 0,
	description: '',
	stage: ''
})
const { glAccounts } = getGLAccounts(typeOfGLGet.Division)

function handleSubmit() {
	addRequisition(requisition.value)
	router.push('/requisitions')
}
</script>