<template>
	<form v-if="requisition" @submit.prevent="handleSubmit">
		<v-card>
			<v-card-title>Edit form</v-card-title>

			<v-container>
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
			</v-container>
			<template v-slot:actions>
				<v-btn type="submit">Edit</v-btn>
				<v-btn class="ms-auto" text="Cancel" @click="closeDialog"></v-btn>
			</template>
		</v-card>
	</form>
</template>

<script setup>
import { getGLAccounts } from '@/hooks/glAccountCRUD'
import { defineProps, inject, onMounted, defineEmits } from 'vue'
import { editRequisition, getRequisition } from '@/hooks/requisitionCRUD'

const props = defineProps(['requisitionId'])
const emit = defineEmits(['closeDialog'])
const id = props.requisitionId

const editRequisitionStates = inject('editRequisitionStates')

const { requisition, getter: requisitionGetter } = getRequisition()
const { glAccounts, getter: glGetter } = getGLAccounts()

onMounted(async () => {
	await requisitionGetter(id)
	await glGetter('division')
})
function handleSubmit() {
	editRequisition(requisition.value, editRequisitionStates.Edit)
	closeDialog()
}
function closeDialog() {
	emit('closeDialog', false)
	emit('closeExansion')
}
</script>