<template>
	<section
		v-if="requisition.applicant != null && requisition != null && requisition.glaccount != null"
	>
		<aside>
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
				<div v-if="requisition.needsMotivation == true">
					<v-btn @click="openMotivationDialog = true">View Motivations</v-btn>
					<v-dialog v-model="openMotivationDialog" width="auto">
						<MotivationDialog
							:requisition="requisition"
							:dialog="openMotivationDialog"
							@closeDialog="closeMotivationDialog"
						/>
					</v-dialog>
				</div>

				<!-- Checking if logged in user is the author of this requisition, also checks if the requisition's money has been issued and checks if no change has been calculated, so that total expenses can be entered -->
				<div
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
				</div>
				<div v-if="requisition.change != null">
					<v-btn @click="openReceiptDialog = true">View Receipts</v-btn>
					<v-dialog v-model="openReceiptDialog" width="auto">
						<ReceiptDialog
							:requisition="requisition"
							:dialog="openReceiptDialog"
							@closeDialog="closeReceiptDialog"
						/>
					</v-dialog>
				</div>
			</div>
		</aside>
		<aside>
			<h4>Authorization:</h4>
			<p>{{ requisition.stage }}</p>
			<div v-if="requisition.managerRecommendation != null">
				<p>
					{{ requisition.managerRecommendation.description }} By:
					{{ requisition.manager.fullName }}
				</p>
				<p>Status: {{ requisition.managerRecommendation.description }}</p>
				<p v-if="requisition.managerComment">Note: {{ requisition.managerComment }}</p>
				<p>
					Date {{ requisition.managerRecommendation.description }}:
					{{ formatDate(requisition.managerRecommendationDate) }}
				</p>
			</div>
			<div v-if="requisition.financeApproval != null">
				<p>
					{{ requisition.financeApproval.description }} By:
					{{ requisition.financeOfficer.fullName }}
				</p>
				<span
					><p>Status: {{ requisition.financeApproval.description }}</p>
					<p v-if="requisition.financeComment">
						- {{ requisition.financeComment }}
					</p></span
				>
				<p>
					Date {{ requisition.financeApproval.description }}:
					{{ formatDate(requisition.financeApprovalDate) }}
				</p>
			</div>
		</aside>
		<Buttonhandler :requisition="requisition" />
	</section>
	<div v-else>Cannot find requisition details</div>
</template>

<script setup>
import { inject, ref, watch } from 'vue'
import { getRequisition } from '@/hooks/requisitionCRUD'
import MotivationDialog from '@/components/Requisition/Dialogs/MotivationDialog.vue'
import ReceiptDialog from '@/components/Requisition/Dialogs/ReceiptDialog.vue'
import ExpensesDialog from '@/components/Requisition/Dialogs/ExpensesDialog.vue'
import Buttonhandler from '@/components/Requisition/ButtonHandler.vue'
import moment from 'moment'
import { useRoute } from 'vue-router'

const openMotivationDialog = ref(false)
const closeMotivationDialog = () => (openMotivationDialog.value = false)

const openReceiptDialog = ref(false)
const closeReceiptDialog = () => (openReceiptDialog.value = false)

const openExpensesDialog = ref(false)
const closeExpensesDialog = () => (openExpensesDialog.value = false)

const route = useRoute()
const id = route.params.id

const user = inject('User')

const { requisition, getter: requisitionGetter } = getRequisition()

watch(
	requisition,
	async (oldId, newId) => {
		await requisitionGetter(id)
	},
	{ immediate: true }
)
function formatDate(date) {
	if (date) return moment(String(date)).format('DD-MM-YYYY')
}
</script>