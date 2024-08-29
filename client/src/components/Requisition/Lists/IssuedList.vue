<template>
	<!-- TODO Date filter -->
	<v-container>
		<v-row>
			<v-col>
				<section>
					<label>Filter</label>
					<select :disabled="arrayOfStates.length == 0" v-model="dateFilter">
						<option v-for="state in arrayOfStates" :value="state" :key="state">
							{{ state.type }}
						</option>
					</select>
				</section>
			</v-col>
		</v-row>
		<v-row>
			<v-data-table-server
				v-model:expanded="expanded"
				:headers="headers"
				:items="requisitions"
				item-value="requisitionId"
				show-expand
			>
				<template v-slot:expanded-row="{ columns, item }">
					<tr>
						<td :colspan="columns.length">
							<DetailsExpanded :requisitionId="item.requisitionId" />
						</td>
					</tr>
				</template>
			</v-data-table-server>
		</v-row>
	</v-container>
</template>

<script setup>
import { getRequisitions, editRequisition } from '@/hooks/requisitionCRUD'
import OpenedDialog from '@/components/Requisition/Dialogs/OpenedDialog.vue'
import DetailsExpanded from '@/components/Requisition/CRUDDialogs/DetailsExpanded.vue'
import { ref, inject, watch } from 'vue'

const getRequisitionStates = inject('getRequisitionStates')
const issuedRequisitionState = inject('issuedRequisitionState')
const selectedRecord = ref({})
const user = inject('User')
const dialog = ref(false)
const expanded = ref([])
const headers = [
	{ title: 'Id', key: 'requisitionId' },
	{ title: 'Name', key: 'applicant.fullName' },
	{ title: 'Amount(R)', key: 'amountRequested' },
	{ title: 'Description', key: 'description' },
	{ title: '', key: 'data-table-expand' }
]
const { requisitions, getter } = getRequisitions()

const dateFilter = ref({
	type: issuedRequisitionState.Green
})

const arrayOfStates = ref([
	{ type: issuedRequisitionState.Green },
	{ type: issuedRequisitionState.Red }
])
watch(
	requisitions,
	async (oldRequisitions, newRequisitions) =>
		await getter(getRequisitionStates.Issued, 0, dateFilter.value.type),
	{ immediate: true }
)

const addIssuing = (item) => {
	selectedRecord.value = item
	dialog.value = true
}

const closeDialog = () => (dialog.value = false)
</script>