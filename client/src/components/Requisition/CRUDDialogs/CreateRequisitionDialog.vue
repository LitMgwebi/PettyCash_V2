<template>
	<form @submit.prevent="handleSubmit">
		<v-card>
			<v-card-title>
				<span class="text-h5">Petty Cash Requisition Form</span>
			</v-card-title>

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
			</v-container>
			<template v-slot:actions>
				<button type="submit">Create</button>
				<v-btn class="ms-auto" text="Cancel" @click="closeDialog"></v-btn>
			</template>
		</v-card>
	</form>
</template>
<script setup>
import { defineEmits, inject, watch, ref } from 'vue'
import { addRequisition } from '@/hooks/requisitionCRUD'
import { getGLAccounts } from '@/hooks/glAccountCRUD'

const emit = defineEmits(['closeDialog'])
const typeOfGLGet = inject('typeOfGLGet')
const requisition = ref({
	glaccountId: '',
	applicantId: '',
	amountRequested: 0,
	description: '',
	stage: ''
})
const { glAccounts, getter } = getGLAccounts()

watch(
	typeOfGLGet,
	async () => {
		await getter(typeOfGLGet.Division)
	},
	{ immediate: true }
)

function handleSubmit() {
	addRequisition(requisition.value)
	closeDialog()
}

function closeDialog() {
	emit('closeDialog', false)
}
</script>