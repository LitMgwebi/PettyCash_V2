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
			<router-link
				:to="{ name: 'requisition_details', params: { id: requisition.requisitionId } }"
			>
				Cancel</router-link
			>
		</div>
	</form>
	<div v-else>Cannot load information, Please contact ICT</div>
</template>

<script setup>
import { getGLAccounts } from '@/hooks/glAccountCRUD'
import { defineProps, ref, toRefs, inject, onMounted, watch } from 'vue'
import { editRequisition, getRequisition } from '@/hooks/requisitionCRUD'
import router from '@/router/router'
import { useRoute } from 'vue-router'

const reloadPage = () => location.reload()

const route = useRoute()
const id = route.params.id
const editRequisitionStates = inject('editRequisitionStates')

const { requisition, getter: requisitionGetter } = getRequisition()
const { glAccounts, getter: glGetter } = getGLAccounts()
watch(
	() => route.params.id,
	async (oldId, newId) => {
		await requisitionGetter(id)
		await glGetter('division')
	},
	{ immediate: true }
)
function handleSubmit() {
	editRequisition(requisition.value, editRequisitionStates.Edit)
	router.push({ name: 'requisition_details', params: { id: requisition.requisitionId } })
}
</script>