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

				<div v-if="requisition.glaccount.needsMotivation == true">
					<!-- <router-link
						:to="{
							name: 'motivations',
							params: {
								id: requisition.requisitionId
							}
						}"
					>
						<p>Motivations</p>
					</router-link> -->
					<section class="table">
						<div v-if="motivations">
							<div v-if="motivations.length > 0">
								<div v-for="motivation in motivations" :key="motivation">
									<span>
										{{ motivation.fileName }} {{ motivation.dateUploaded }}
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
		<aside v-if="user.id == requisition.applicant.id">
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
import { getRequisition } from '@/hooks/requisitionCRUD'
import { addMotivation, getMotivations, deleteMotivation } from '@/hooks/motivationCRUD'
import Buttonhandler from '@/components/Requisition/ButtonHandler.vue'
import moment from 'moment'

const props = defineProps(['id'])
const { id } = toRefs(props)
const user = inject('User')
const file = ref(null)
let formData = new FormData()

function formatDate(date) {
	if (date) return moment(String(date)).format('DD-MM-YYYY')
}
const { requisition } = getRequisition(id.value)
const { motivations } = getMotivations(id.value)

function saveImage() {
	formData.append = ('file', file.value)
	addMotivation(formData, id.value)
}

function deleteRecord(motivation) {
	deleteMotivation(motivation)
}
</script>