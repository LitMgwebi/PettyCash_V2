<template>
	<v-data-table-server
		v-model:expanded="expanded"
		:headers="headers"
		:items="requisitions"
		item-value="requisitionId"
		show-expand
	>
		<template v-slot:top>
			<v-dialog v-model="dialog" width="auto">
				<ApprovalDialog
					:requisition="selectedRecord"
					:dialog="dialog"
					@closeDialog="closeDialog"
				/>
			</v-dialog>
		</template>
		<template v-slot:[`item.actions`]="{ item }">
			<v-btn
				v-if="
					(user.role == 'Senior_Employee' ||
						user.role == 'Manager' ||
						user.role == 'Executive') &&
					user.divisionId == 6
				"
				@click="addApproval(item)"
			>
				Action
			</v-btn>
		</template>
		<template v-slot:expanded-row="{ columns, item }">
			<tr>
				<td :colspan="columns.length">
					<DetailsExpanded :requisitionId="item.requisitionId" />
				</td>
			</tr>
		</template>
	</v-data-table-server>
</template>

<script setup>
import { getRequisitions } from '@/hooks/requisitionCRUD'
import ApprovalDialog from '@/components/Requisition/Dialogs/ApprovalDialog.vue'
import DetailsExpanded from '@/components/Requisition/CRUDDialogs/DetailsExpanded.vue'
import { ref, inject, watch } from 'vue'

const getRequisitionStates = inject('getRequisitionStates')
const selectedRecord = ref({})
const user = inject('User')
const dialog = ref(false)
const expanded = ref([])
const headers = [
	{ title: 'Full Name', key: 'applicant.fullName' },
	{ title: 'Amount Requested', key: 'amountRequested' },
	{ title: 'GL Account', key: 'glaccount.name' },
	{ title: 'Description', key: 'description' },
	{ title: '', key: 'actions' },
	{ title: '', key: 'data-table-expand' }
]
const { requisitions, getter } = getRequisitions()
watch(
	requisitions,
	async (oldRequisitions, newRequisitions) => await getter(getRequisitionStates.Approval),
	{ immediate: true }
)

const addApproval = (item) => {
	selectedRecord.value = item
	dialog.value = true
}
const closeDialog = () => (dialog.value = false)
</script>
