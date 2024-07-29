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

				<div v-for="motivation in motivations" :key="motivation">
					{{ motivation }}
				</div>

				<!-- <
					Output all the motivations here, and upload motivations on edit page
					 -->
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
import Buttonhandler from '@/components/Requisition/ButtonHandler.vue'
import { addMotivation, getMotivations } from '@/hooks/motivationCRUD'
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
</script>