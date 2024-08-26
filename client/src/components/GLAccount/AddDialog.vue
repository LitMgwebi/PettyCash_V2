<template>
	<form @submit.prevent="addSubmit">
		<v-card>
			<h3>Add GL Account</h3>
			<v-container>
				<div class="dropdown">
					<label>Main Accounts: </label>
					<select :disabled="mainAccounts.length == 0" v-model="glAccount.mainAccountId">
						<option value="" disabled>Select an account</option>
						<option
							v-for="mainAccount in mainAccounts"
							:value="mainAccount.mainAccountId"
							:key="mainAccount.mainAccountId"
						>
							{{ mainAccount.name }}
						</option>
					</select>
				</div>
				<div class="dropdown">
					<label>Sub Accounts: </label>
					<select :disabled="subAccounts.length == 0" v-model="glAccount.subAccountId">
						<option value="" disabled>Select a sub account</option>
						<option
							v-for="subAccount in subAccounts"
							:value="subAccount.subAccountId"
							:key="subAccount.subAccountId"
						>
							{{ subAccount.name }}
						</option>
					</select>
				</div>
				<div class="dropdown">
					<label>Divisions: </label>
					<select :disabled="divisions.length == 0" v-model="glAccount.divisionId">
						<option value="" disabled>Select a division</option>
						<option
							v-for="division in divisions"
							:value="division.divisionId"
							:key="division.divisionId"
						>
							{{ division.description }}
						</option>
					</select>
				</div>
				<div class="dropdown">
					<label>Purposes: </label>
					<select :disabled="purposes.length == 0" v-model="glAccount.purposeId">
						<option value="" disabled>Select an office</option>
						<option
							v-for="purpose in purposes"
							:value="purpose.purposeId"
							:key="purpose.purposeId"
						>
							{{ purpose.description }}
						</option>
					</select>
				</div>
				<div class="dropdown">
					<label>Offices: </label>
					<select :disabled="offices.length == 0" v-model="glAccount.officeId">
						<option value="" disabled>Select an office</option>
						<option
							v-for="office in offices"
							:value="office.officeId"
							:key="office.officeId"
						>
							{{ office.description }}
						</option>
					</select>
				</div>
				<div class="dropdown">
					<label>Does this account need Motivation?: </label>
					<select
						:disabled="glAccount.length != null"
						v-model="glAccount.needsMotivation"
					>
						<option value="" disabled>Please select</option>
						<option :value="true">Yes</option>
						<option :value="false">No</option>
					</select>
				</div>
			</v-container>
			<template v-slot:actions>
				<button type="submit">Add</button>
				<v-btn class="ms-auto" text="Cancel" @click="closeDialog"></v-btn>
			</template>
		</v-card>
	</form>
</template>

<script setup>
import { defineEmits, ref, onMounted } from 'vue'
import { addGLAccount } from '@/hooks/glAccountCRUD'
import { getOffices } from '@/hooks/officeCRUD'
import { getSubAccounts } from '@/hooks/subAccountCRUD'
import { getMainAccounts } from '@/hooks/mainAccountCRUD'
import { getPurposes } from '@/hooks/purposeCRUD'
import { getDivisions } from '@/hooks/divisionCRUD'

const emit = defineEmits(['closeDialog'])
const glAccount = ref({
	name: '',
	mainAccountId: '',
	subAccountId: '',
	divisionId: '',
	purposeId: '',
	officeId: '',
	needsMotivation: false
})

const { offices, getter: officeGetter } = getOffices()
const { subAccounts, getter: subAccountGetter } = getSubAccounts()
const { mainAccounts, getter: mainAccountGetter } = getMainAccounts()
const { purposes, getter: purposeGetter } = getPurposes()
const { divisions, getter: divisionGetter } = getDivisions()

onMounted(async () => {
	await divisionGetter()
	await purposeGetter()
	await mainAccountGetter()
	await subAccountGetter()
	await officeGetter()
})

const addSubmit = () => {
	addGLAccount(glAccount.value)
	closeDialog()
}

function closeDialog() {
	emit('closeDialog', false)
}
</script>
