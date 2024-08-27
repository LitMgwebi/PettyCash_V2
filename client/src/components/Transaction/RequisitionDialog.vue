<template>
	<v-card>
		<v-card-title>
			<span class="text-h5">Requisition Details</span>
		</v-card-title>

		<v-container>
			<v-row
				style="background"
				v-if="
					requisition.applicant != null &&
					requisition != null &&
					requisition.glaccount != null
				"
			>
				<v-col>
					<h4>Applicant: {{ requisition.applicant.fullName }}</h4>
					<p>Amount Requested: {{ requisition.amountRequested }}</p>
					<p v-if="requisition.cashIssued">Cash Issued: {{ requisition.cashIssued }}</p>
					<p>Description: {{ requisition.description }}</p>
					<p>Date Requested: {{ formatDate(requisition.startDate) }}</p>

					<p v-if="requisition.closeDate">Date Closed: {{ requisition.closeDate }}</p>
					<p>
						GL Account: {{ requisition.glaccount.name }} -
						{{ requisition.glaccount.description }}
					</p>
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
									@closeDialog="closeMotivationDialog"
								/>
							</v-dialog>
						</span>

						<!-- Checking if logged in user is the author of this requisition, also checks if the requisition's money has been issued and checks if no change has been calculated, so that total expenses can be entered -->
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
						<p v-if="requisition.managerComment">
							Comment: {{ requisition.managerComment }}
						</p>
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
			</v-row>
		</v-container>
		<template v-slot:actions>
			<v-btn class="ms-auto" text="Close" @click="closeDialog"></v-btn>
		</template>
	</v-card>
</template>

<script setup>
import { defineEmits, inject, watch, ref } from 'vue'
import { getRequisition } from '@/hooks/requisitionCRUD'
import MotivationDialog from '@/components/Requisition/Dialogs/MotivationDialog.vue'
import ReceiptDialog from '@/components/Requisition/Dialogs/ReceiptDialog.vue'
import moment from 'moment'

const openMotivationDialog = ref(false)
const closeMotivationDialog = () => (openMotivationDialog.value = false)

const openReceiptDialog = ref(false)
const closeReceiptDialog = () => (openReceiptDialog.value = false)

const emit = defineEmits(['closeDialog'])
const props = defineProps(['requisitionId'])
const id = props.requisitionId

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

function closeDialog() {
	emit('closeDialog', false)
}
</script>
