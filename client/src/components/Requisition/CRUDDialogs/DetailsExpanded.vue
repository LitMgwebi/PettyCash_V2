<template>
	<v-row
		style="background"
		v-if="requisition.applicant != null && requisition != null && requisition.glaccount != null"
	>
		<v-col>
			<h4>General Details</h4>
			<div>
				<h4 v-if="user.id != requisition.applicant.id">
					Applicant: {{ requisition.applicant.fullName }}
				</h4>
				<p>Amount Requested: {{ requisition.amountRequested }}</p>
				<p v-if="requisition.cashIssued">Cash Issued: {{ requisition.cashIssued }}</p>
				<p>Description: {{ requisition.description }}</p>
				<p>Date Requested: {{ formatDate(requisition.startDate) }}</p>
				<p>
					GL Account: {{ requisition.glaccount.name }} -
					{{ requisition.glaccount.description }}
				</p>
				<div v-if="user.id == requisition.applicant.id">
					<p v-if="requisition.applicantCode > 0">
						Code: {{ requisition.applicantCode }}
					</p>
				</div>
				<div v-if="requisition.totalExpenses != null">
					<p>Total Expenses: {{ requisition.totalExpenses }}</p>
					<p>Change: {{ requisition.change }}</p>
				</div>

				<div>
					<span v-if="requisition.needsMotivation == true">
						<v-btn @click="openMotivationDialog = true">View Motivations</v-btn>
						<v-dialog v-model="openMotivationDialog" width="auto">
							<MotivationDialog
								:requisition="requisition"
								:dialog="openMotivationDialog"
								@closeDialog="closeMotivationDialog"
							/>
						</v-dialog>
					</span>

					<!-- Checking if logged in user is the author of this requisition, also checks if the requisition's money has been issued and checks if no change has been calculated, so that total expenses can be entered -->
					<span
						v-if="
							requisition.issuerId != null &&
							user.id == requisition.applicant.id &&
							requisition.change == null
						"
					>
						<v-btn @click="openExpensesDialog = true">Add Expenses</v-btn>
						<v-dialog v-model="openExpensesDialog" width="auto">
							<ExpensesDialog
								:requisition="requisition"
								:dialog="openExpensesDialog"
								@closeDialog="closeExpensesDialog"
							/>
						</v-dialog>
					</span>
					<span v-if="requisition.change != null">
						<v-btn @click="openReceiptDialog = true">View Receipts</v-btn>
						<v-dialog v-model="openReceiptDialog" width="auto">
							<ReceiptDialog
								:requisition="requisition"
								@closeDialog="closeReceiptDialog"
							/>
						</v-dialog>
					</span>
				</div>
			</div>
		</v-col>
		<v-col>
			<h4>Authorization:</h4>
			<p>{{ requisition.stage }}</p>
			<div v-if="requisition.manager != null">
				<p>
					{{ requisition.managerRecommendation.description }} By:
					{{ requisition.manager.fullName }}
				</p>
				<p>Status: {{ requisition.managerRecommendation.description }}</p>
				<p v-if="requisition.managerComment">Comment: {{ requisition.managerComment }}</p>
				<p>
					Date {{ requisition.managerRecommendation.description }}:
					{{ formatDate(requisition.managerRecommendationDate) }}
				</p>
			</div>
			<div v-if="requisition.financeOfficer != null">
				<p>
					{{ requisition.financeApproval.description }} By:
					{{ requisition.financeOfficer.fullName }}
				</p>
				<span
					><p>Status: {{ requisition.financeApproval.description }}</p>
					<p v-if="requisition.financeComment">
						Comment: {{ requisition.financeComment }}
					</p></span
				>
				<p>
					Date {{ requisition.financeApproval.description }}:
					{{ formatDate(requisition.financeApprovalDate) }}
				</p>
			</div>
			<div v-if="requisition.issuer != null">
				<p>Issued By: {{ requisition.issuer.fullName }}</p>
				<p>Issued On: {{ formatDate(requisition.issueDate) }}</p>
			</div>
		</v-col>
		<v-col v-if="user.id == requisition.applicant.id">
			<div>
				<span v-if="requisition.managerRecommendationId == null">
					<v-btn @click="() => (openEditDialog = true)"> Edit </v-btn>
					<v-dialog v-model="openEditDialog" width="auto">
						<EditRequisitionDialog
							:requisitionId="requisition.requisitionId"
							@closeDialog="closeEditDialog"
							@closeExansion="closeExansion"
						/>
					</v-dialog>
				</span>
				<span v-if="requisition.issuerId == null && requisition.closeDate == null">
					<v-btn @click="() => (openDeleteDialog = true)"> Delete</v-btn>
					<v-dialog v-model="openDeleteDialog" width="auto">
						<DeleteRequisitionDialog
							:requisitionId="requisition.requisitionId"
							@closeDialog="closeDeleteDialog"
							@closeExansion="closeExansion"
						/>
					</v-dialog>
				</span>
			</div>
		</v-col>
	</v-row>
	<v-row v-else>Cannot find requisition details</v-row>
</template>

<script setup>
import { inject, ref, watch, defineEmits, defineProps } from 'vue'
import { getRequisition } from '@/hooks/requisitionCRUD'
import MotivationDialog from '@/components/Requisition/Dialogs/MotivationDialog.vue'
import ReceiptDialog from '@/components/Requisition/Dialogs/ReceiptDialog.vue'
import ExpensesDialog from '@/components/Requisition/Dialogs/ExpensesDialog.vue'
import EditRequisitionDialog from '@/components/Requisition/CRUDDialogs/EditRequisitionDialog.vue'
import DeleteRequisitionDialog from '@/components/Requisition/CRUDDialogs/DeleteRequisitionDialog.vue'
import moment from 'moment'

const props = defineProps(['requisitionId'])
const emit = defineEmits(['closeExansion'])
const id = props.requisitionId
const user = inject('User')

const openMotivationDialog = ref(false)
const closeMotivationDialog = () => (openMotivationDialog.value = false)

const openReceiptDialog = ref(false)
const closeReceiptDialog = () => (openReceiptDialog.value = false)

const openExpensesDialog = ref(false)
const closeExpensesDialog = () => (openExpensesDialog.value = false)

const openEditDialog = ref(false)
const closeEditDialog = () => (openEditDialog.value = false)

const openDeleteDialog = ref(false)
const closeDeleteDialog = () => (openDeleteDialog.value = false)

const closeExansion = () => emit('closeExansion')

const { requisition, getter } = getRequisition()

watch(
	requisition,
	async (oldId, newId) => {
		await getter(id)
	},
	{ immediate: true }
)
function formatDate(date) {
	if (date) return moment(String(date)).format('DD-MM-YYYY')
}
</script>
