<template>
	<h2>Petty Cash Requests</h2>

	<router-link :to="{ name: 'requistion_create' }" custom v-slot="{ navigate }">
		<button @click="navigate" role="link">Create</button>
	</router-link>
	<div>
		<ApplicantList />
	</div>

	<div v-if="user.role == 'Manager' || user.role == 'GM_Manager'">
		<RecommendationList />
	</div>

	<div v-if="(user.role == 'Manager' || user.role == 'Executive') && user.divisionId == 6">
		<ApprovalList />
	</div>
</template>

<script setup>
import ApplicantList from '@/components/Requisition/ApplicantList.vue'
import RecommendationList from '@/components/Requisition/RecommendationList.vue'
import ApprovalList from '@/components/Requisition/ApprovalList.vue'
import { inject } from 'vue'

const user = inject('User')
</script>