<template>
	<!-- <h3>Requisitions requiring recommendation</h3> -->
	<v-data-table-server :headers="headers" :items="requisitions">
		<template v-slot:top>
			<v-dialog v-model="dialog" width="auto">
				<RecommendationDialog
					:requisition="selectedRecord"
					:dialog="dialog"
					@closeDialog="closeDialog"
				/>
			</v-dialog>
		</template>
		<template v-slot:[`item.actions`]="{ item }">
			<v-btn v-on:click="routeToDetails(item)"> Details</v-btn>
			<v-btn
				v-if="
					(user.role == 'Manager' && user.divisionId != 6) ||
					user.role == 'GM_Manager' ||
					user.role == 'Senior_Employee'
				"
				@click="addRecommendation(item)"
			>
				Action
			</v-btn>
		</template>
	</v-data-table-server>
</template>

<script setup>
import { getRequisitions } from '@/hooks/requisitionCRUD'
import RecommendationDialog from '@/components/Requisition/Dialogs/RecommendationDialog.vue'
import { ref, inject, watch } from 'vue'
import router from '@/router/router'

const getRequisitionStates = inject('getRequisitionStates')
const selectedRecord = ref({})
const user = inject('User')
const dialog = ref(false)
const headers = [
	{ title: 'Full Name', value: 'applicant.fullName' },
	{ title: 'Amount Requested', value: 'amountRequested' },
	{ title: 'GL Account', value: 'glaccount.name' },
	{ title: 'Description', value: 'description' },
	{ title: '', value: 'actions' }
]
const { requisitions, getter } = getRequisitions()

watch(
	requisitions,
	async (oldRequisitions, newRequisitions) => {
		await getter(getRequisitionStates.Recommendation)
	},
	{ immediate: true }
)

const addRecommendation = (item) => {
	selectedRecord.value = item
	dialog.value = true
}

const routeToDetails = (item) => {
	router.push({ name: 'requisition_details', params: { id: item.requisitionId } })
}
const closeDialog = () => (dialog.value = false)
</script>
