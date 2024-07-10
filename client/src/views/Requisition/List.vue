<template>
	<h2>Petty Cash Requests</h2>

	<router-link :to="{ name: 'requistion_create' }" custom v-slot="{ navigate }">
		<button @click="navigate" role="link">Create</button>
	</router-link>
	<div>
		<ApplicantList />
	</div>

	<div v-if="user.role == 'Manager'">
		<ManagerApprovalList />
	</div>

	<div v-if="user.divisionId == 6">
		<FinanceApprovalList />
	</div>
</template>

<script setup>
import ApplicantList from '@/components/Requisition/ApplicantList.vue'
import ManagerApprovalList from '@/components/Requisition/ManagerApprovalList.vue'
import FinanceApprovalList from '@/components/Requisition/FinanceApprovalList.vue'
import { inject } from 'vue'

const user = inject('User')
</script>