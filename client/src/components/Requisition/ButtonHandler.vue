<template>
	<div v-if="user.id == requisition.applicant.id">
		<router-link
			v-if="requisition.managerRecommendationId == null"
			:to="{
				name: 'requisition_edit',
				params: {
					id: requisition.requisitionId
				}
			}"
		>
			<button>Edit</button>
		</router-link>
		<span v-if="requisition.issuerId == null">
			<button @click="deleteRecord(requistion)">Delete</button>
		</span>
	</div>
</template>

<script setup>
import { inject, defineProps, toRefs } from 'vue'

const props = defineProps(['requisition'])
const { requisition } = toRefs(props)
const user = inject('User')
</script>