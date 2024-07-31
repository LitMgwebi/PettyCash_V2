<template>
	<section v-if="requisition">
		<aside>
			<h4>General Details</h4>
			<div>
				<p>Amount Requested: {{ requisition.amountRequested }}</p>
				<p>Description: {{ requisition.description }}</p>
				<p>Date Requested: {{ formatDate(requisition.startDate) }}</p>
				<p>
					GL Account: {{ requisition.glaccount.name }} -
					{{ requisition.glaccount.description }}
				</p>

				<div v-if="user.jobTitle == 16">
					<div v-if="user.id == requisition.applicant.id">
						<p v-if="requisition.applicantCode > 0">
							Code: {{ requisition.applicantCode }}
						</p>
					</div>
					<div v-else>
						<form @submit.prevent="issueMoney">
							<div>
								<label>Cash to be issued: </label>
								<input type="text" v-model="requisition.cashIssued" />
							</div>
							<div>
								<label>Applicant Code: </label>
								<input type="text" v-model="attemptCode" />
							</div>

							<!-- Grey out the button until the code and cash issued or both inputted -->
							<div class="submit">
								<button>Edit</button>
							</div>
						</form>
					</div>
				</div>
				<div v-if="requisition.needsMotivation == true">
					<section class="table">
						<div v-if="documents">
							<div v-if="documents.length > 0">
								<div v-for="document in documents" :key="document">
									<span>
										{{ document.fileName }} {{ document.dateUploaded }}
									</span>
									<div v-if="user.id == requisition.applicant.id">
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
import { defineProps, toRefs, inject, ref } from 'vue'
import { getRequisition, editRequisition } from '@/hooks/requisitionCRUD'
import { addDocument, getDocuments, deleteDocument } from '@/hooks/documentCRUD'
import Buttonhandler from '@/components/Requisition/ButtonHandler.vue'
import moment from 'moment'
import router from '@/router/router'

//#region Variable Declarations

const props = defineProps(['id'])
const { id } = toRefs(props)
const user = inject('User')
const file = ref(null)
const attemptCode = ref(0)
let formData = new FormData()
const { requisition } = getRequisition(id.value)
const { documents } = getDocuments('motivations', id.value)

//#endregion

//#region Functions

function saveImage() {
	formData.append = ('file', file.value)
	addDocument(formData, id.value, 'motivation')
}

function deleteRecord(motivation) {
	deleteDocument(motivation)
}

function formatDate(date) {
	if (date) return moment(String(date)).format('DD-MM-YYYY')
}

function issueMoney() {
	editRequisition(requisition.value, 'issuing', attemptCode.value)
	router.push({ name: 'requisitions' })
}

//#endregion
</script>