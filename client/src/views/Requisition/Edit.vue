<template>
	<h2>Edit form</h2>

	<form v-if="requisition" @submit.prevent="handleSubmit">
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
			<select :disabled="glAccounts.length == 0" v-model="requisition.glaccountId">
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
			<button>Edit</button>
			<button>Cancel</button>
		</div>
	</form>
	<div v-else>Cannot load information, Please contact ICT</div>
</template>

<script setup>
import { getGLAccounts } from '@/hooks/glAccountCRUD'
import { defineProps, ref, toRefs, inject } from 'vue'
import { editRequisition, getRequisition } from '@/hooks/requisitionCRUD'
import router from '@/router/router'

const reloadPage = () => location.reload()

const props = defineProps(['id'])
const { id } = toRefs(props)
const editRequisitionStates = inject('editRequisitionStates')

const { requisition } = getRequisition(id.value)
const { glAccounts } = getGLAccounts('division')
// // same as beforeRouteLeave option but with no access to `this`
// onBeforeRouteLeave((to, from) => {
//   const answer = window.confirm(
//     'Do you really want to leave? you have unsaved changes!'
//   )
//   // cancel the navigation and stay on the same page
//   if (!answer) return false
// })

function handleSubmit() {
	editRequisition(requisition.value, editRequisitionStates.Edit)
	router.push({ name: 'requisition_details', params: { id: requisition.requisitionId } })
}
</script>