<template>
	<h3>Open requistions</h3>
	<div v-for="requisition in requisitions" :key="requisition.requisitionId">
		<!-- <section v-if="requisition.financeApprovalId == null"> -->
		<div style="padding: 10px">
			{{ requisition.description }} - R{{ requisition.amountRequested }} ({{
				requisition.glaccount.name
			}}) -
			{{ requisition.stage }}
			<div v-if="requisition.managerComment">Note: {{ requisition.managerComment }}</div>
			<div v-if="requisition.financeComment">Note: {{ requisition.financeComment }}</div>
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
		<!-- </section> -->
	</div>
</template>

<script setup>
import { getRequisitions } from '@/hooks/requisitionCRUD'
import { inject } from 'vue'

const { requisitions } = getRequisitions('forOne')
</script>