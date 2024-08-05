<template>
	<section v-if="requisition">
		<aside>
			<h4>General Details</h4>
			<div>
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

				<div v-if="requisition.needsMotivation == true">
					<section class="table">
						<div v-if="motivations != null">
							<div v-if="motivations.length > 0">
								<div v-for="motivation in motivations" :key="motivation">
									<span>
										{{ motivation.fileName }} {{ motivation.dateUploaded }}
									</span>
									<div
										v-if="
											user.id == requisition.applicant.id &&
											requisition.issueId != null
										"
									>
										<button @click="deleteRecord(motivation)">Delete</button>
									</div>
								</div>
							</div>
							<div v-else>
								<div v-if="user.id == requisition.applicant.id">
									Please upload a motivation for your requisition to be sent for
									recommendation
									<section class="create">
										<h3>Upload Motivation</h3>
										<form
											@submit.prevent="saveImage"
											enctype="multipart/form-data"
										>
											<input
												type="file"
												ref="file"
												@change="(e) => (file = e.target.files[0])"
											/>
											<button type="submit">Upload</button>
										</form>
									</section>
								</div>
								<div v-else>Motivation is yet to be uploaded</div>
							</div>
						</div>
					</section>
				</div>

				<!-- Add code to check if the applicant used the money or did not -->
				<div v-if="requisition.applicantCode > 0">
					<form
						@submit.prevent="addExpenses"
						v-if="user.id == requisition.applicant.id && requisition.change == null"
					>
						<div>
							<label>What were your total expenses: </label>
							<input type="text" v-model="requisition.totalExpenses" required />
						</div>
						<div>
							<button type="submit">Save</button>
							<button @click="reloadPage">Cancel</button>
						</div>
					</form>
					<div v-else-if="requisition.totalExpenses != null">
						<p>Total Expenses: {{ requisition.totalExpenses }}</p>
						<p>Change: {{ requisition.change }}</p>
					</div>
				</div>

				<div v-if="requisition.change != null">
					hi
					<section class="table">
						<div v-if="receipts">
							<div v-if="receipts.length > 0">
								<div v-for="receipt in receipts" :key="receipt">
									<span> {{ receipt.fileName }} {{ receipt.dateUploaded }} </span>
									<div
										v-if="
											user.id == requisition.applicant.id &&
											requisition.confirmChangeReceived == false
										"
									>
										<button @click="deleteRecord(receipt)">Delete</button>
									</div>
								</div>
							</div>
							<div v-else>
								<div
									v-if="
										user.id == requisition.applicant.id &&
										requisition.receiptReceived == false
									"
								>
									Please upload all the receipts.
									<section class="create">
										<h3>Upload Receipt</h3>
										<form
											@submit.prevent="saveReceipt"
											enctype="multipart/form-data"
										>
											<input
												type="file"
												ref="file"
												@change="(e) => (file = e.target.files[0])"
												multiple
											/>
											<button type="submit">Upload</button>
										</form>
									</section>
								</div>
								<div v-else>No Receipt has been uploaded yet</div>
							</div>
						</div>
					</section>
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
		<aside>
			<div v-if="user.jobTitleId == 16 && requisition.financeApproval != null">
				<div v-if="requisition.issuerId == null">
					<h2>Issue</h2>
					<form @submit.prevent="issueMoney">
						<div>
							<label>Cash to be issued: </label>
							<input type="text" v-model="requisition.cashIssued" required />
						</div>
						<div>
							<label>Applicant Code: </label>
							<input type="text" v-model="attemptCode" required />
						</div>

						<!-- Grey out the button until the code and cash issued or both inputted -->
						<div class="submit">
							<button>Issue</button>
						</div>
					</form>
				</div>
				<div v-if="requisition.change != null && requisition.closeDate == null">
					<form @submit.prevent="confirmChange">
						<div>Has {{ requisition.applicant.fullName }} brought back the change?</div>
						<select v-model="requisition.confirmChangeReceived">
							<option value="" disabled>Please Choose an option</option>
							<option value="true">Yes</option>
							<option value="false">No</option>
						</select>
						<div class="submit">
							<button>Confirm</button>
						</div>
					</form>
				</div>
			</div>
		</aside>
		<Buttonhandler :requisition="requisition" />
	</section>
	<div v-else>Cannot find requisition details</div>
</template>

<script setup>
import { defineProps, toRefs, inject, ref } from 'vue'
import { getRequisition, editRequisition } from '@/hooks/requisitionCRUD'
import { addDocument, getDocuments, deleteDocument } from '@/hooks/documentCRUD'
import Buttonhandler from '@/components/Requisition/ButtonHandler.vue'
import moment from 'moment'
import router from '@/router/router'

//#region Variable Declarations

const reloadPage = () => location.reload()
const props = defineProps(['id'])
const { id } = toRefs(props)
const user = inject('User')
const editRequisitionStates = inject('editRequisitionStates')
const typeOfFile = inject('typeOfFile')
const file = ref(null)
const attemptCode = ref(0)
let formData = new FormData()
const { requisition } = getRequisition(id.value)
const { documents: motivations } = getDocuments(typeOfFile.Motivation, id.value)
const { documents: receipts } = getDocuments(typeOfFile.Receipt, id.value)
//#endregion

//#region Functions

function saveImage() {
	formData.append = ('file', file.value)
	addDocument(formData, id.value, typeOfFile.Motivation)
}

function saveReceipt() {
	formData.append = ('file', file.value)
	addDocument(formData, id.value, typeOfFile.Receipt)
	location.reload()
}

function deleteRecord(motivation) {
	deleteDocument(motivation)
}

function formatDate(date) {
	if (date) return moment(String(date)).format('DD-MM-YYYY')
}

function issueMoney() {
	editRequisition(requisition.value, editRequisitionStates.Issuing, attemptCode.value)
	router.push({ name: 'requisitions' })
}

function confirmChange() {
	editRequisition(requisition.value, editRequisitionStates.Close)
}

function addExpenses() {
	editRequisition(requisition.value, editRequisitionStates.Expenses)
	router.push({ name: 'requisitions' })
}

//#endregion
</script>