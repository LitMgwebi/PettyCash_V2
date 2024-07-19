<template>
	<h3>Requests for you to approve</h3>
	<div v-for="requisition in requisitions" :key="requisition.requisitionId">
		<span>
			{{ requisition.applicant.fullName }} - R{{ requisition.amountRequested }} ({{
				requisition.glaccount.name
			}})- {{ requisition.description }}</span
		>
		<div>
			<router-link
				:to="{
					name: 'requisition_details',
					params: {
						id: requisition.requisitionId
					}
				}"
			>
				<button>Details</button>
			</router-link>
		</div>
	</div>
</template>

<script setup>
import { getRequisitions, editRequisition } from '@/hooks/requisitionCRUD'
import { ref } from 'vue'
import { inject } from 'vue'

const user = inject('User')

const { requisitions } = getRequisitions('approval')
</script>
