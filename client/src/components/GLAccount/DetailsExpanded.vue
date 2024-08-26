<template>
	<v-row v-if="glAccount != null">
		<v-col>
			<h4>GL Account Details:</h4>
			<p>Name: {{ glAccount.name }}</p>
			<p>Description: {{ glAccount.description }}</p>
			<p>Main Account: {{ glAccount.mainAccount.name }}</p>
			<p>Sub Account: {{ glAccount.subAccount.name }}</p>
			<p>Division: {{ glAccount.division.description }}</p>
			<p>Requires Motivation: {{ glAccount.needsMotivation }}</p>
		</v-col>
		<v-col v-if="user.role == 'ICT_Admin'">
			<span>
				<v-btn @click="() => (openEditDialog = true)"> Edit </v-btn>
				<v-dialog v-model="openEditDialog" width="auto">
					<EditDialog
						:glaccountId="glAccount.glaccountId"
						@closeDialog="closeEditDialog"
						@closeExansion="closeExansion"
					/>
				</v-dialog>
			</span>
			<span>
				<v-btn @click="() => (openDeleteDialog = true)"> Delete</v-btn>
				<v-dialog v-model="openDeleteDialog" width="auto">
					<DeletDialog
						:glaccount="glAccount"
						@closeDialog="closeDeleteDialog"
						@closeExansion="closeExansion"
					/>
				</v-dialog>
			</span>
		</v-col>
	</v-row>
	<v-row v-else>Cannot retrieve Gl Account details from backend</v-row>
</template>

<script setup>
import { inject, watch, ref, defineEmits, defineProps } from 'vue'
import { getGLAccount } from '@/hooks/glAccountCRUD.js'
import EditDialog from '@/components/GLAccount/EditDialog.vue'
import DeletDialog from '@/components/GLAccount/DeleteDialog.vue'

const props = defineProps(['glaccountId'])
const emit = defineEmits(['closeExansion'])
const id = props.glaccountId
const user = inject('User')

const openEditDialog = ref(false)
const closeEditDialog = () => (openEditDialog.value = false)

const openDeleteDialog = ref(false)
const closeDeleteDialog = () => (openDeleteDialog.value = false)

const { glAccount, getter } = getGLAccount()

watch(glAccount, async (oldId, newId) => await getter(id), { immediate: true })

const closeExansion = () => emit('closeExansion')
const deleteRecord = (glAccount) => deleteGLAccount(glAccount)
</script>