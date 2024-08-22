<template>
	<v-row>
		<div>
			<label>Filter:</label>
			<select :disabled="statuses.length == 0" v-model="status">
				<option value="" disabled>Choose</option>
				<option v-for="status in statuses" :value="status" :key="status">
					{{ status.description }}
				</option>
			</select>
		</div>
	</v-row>
	<v-row>
		<v-data-table-server
			v-model:expanded="expanded"
			:headers="headers"
			:items="requisitions"
			item-value="requisitionId"
			show-expand
		>
			<template v-slot:top>
				<v-btn @click="dialog = true">Add Item</v-btn>
				<v-dialog v-model="dialog" max-width="500px">
					<CreateRequisitionDialog @closeDialog="closeDialog" />
				</v-dialog>
			</template>
			<template v-slot:expanded-row="{ columns, item }">
				<tr>
					<td :colspan="columns.length">
						<DetailsExpanded
							:requisitionId="item.requisitionId"
							@closeExansion="closeExansion"
						/>
					</td>
				</tr>
			</template>
		</v-data-table-server>
	</v-row>
</template>

<script setup>
import { getRequisitions } from '@/hooks/requisitionCRUD'
import CreateRequisitionDialog from '@/components/Requisition/CRUDDialogs/CreateRequisitionDialog.vue'
import DetailsExpanded from '@/components/Requisition/CRUDDialogs/DetailsExpanded.vue'
import { getStatesStatuses } from '@/hooks/statusCRUD'
import { inject, ref, watch } from 'vue'

const dialog = ref(false)
const expanded = ref([])
const { statuses, getter: statusGetter } = getStatesStatuses()
const status = ref({
	statusId: 5,
	description: 'In Process',
	option: 'Process',
	isRecommended: false,
	isState: true,
	isApproved: false
})
const getRequisitionStates = inject('getRequisitionStates')
const { requisitions, getter } = getRequisitions()
const headers = [
	{ title: 'Id', key: 'requisitionId' },
	{ title: 'Amount (R)', key: 'amountRequested' },
	{ title: 'Description', key: 'description' },
	{ title: 'Stage', key: 'stage' },
	{ title: '', key: 'data-table-expand' }
]

watch(
	requisitions,
	async () => {
		await getter(getRequisitionStates.ForOne, status.value.statusId)
		await statusGetter()
	},
	{ immediate: true }
)

const closeExansion = () => (expanded.value = [])
const closeDialog = () => (dialog.value = false)
</script>
