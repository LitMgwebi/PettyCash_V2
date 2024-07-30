<template>
	<h2>Petty Cash Requests</h2>

	<div
		v-if="
			user.role != 'GM_Manager' &&
			!((user.role == 'Manager' || user.role == 'Senior_Employee') && user.divisionId == 6)
		"
	>
		<router-link :to="{ name: 'requisition_create' }">
			<button>Create</button>
		</router-link>
	</div>
	<div
		v-if="
			user.role != 'Executive' &&
			user.role != 'GM_Manager' &&
			!((user.role == 'Manager' || user.role == 'Senior_Employee') && user.divisionId == 6)
		"
	>
		<ApplicantList />
	</div>

	<div
		v-if="
			(user.role == 'Manager' && user.divisionId != 6) ||
			user.role == 'GM_Manager' ||
			user.role == 'Senior_Employee'
		"
	>
		<RecommendationList />
	</div>

	<div
		v-if="
			(user.role == 'Senior_Employee' ||
				user.role == 'Manager' ||
				user.role == 'Executive') &&
			user.divisionId == 6
		"
	>
		<ApprovalList />
	</div>

	<div v-if="user.jobTitleId == 16">
		<IssuingList />
	</div>
</template>

<script setup>
import ApplicantList from '@/components/Requisition/ApplicantList.vue'
import RecommendationList from '@/components/Requisition/RecommendationList.vue'
import ApprovalList from '@/components/Requisition/ApprovalList.vue'
import IssuingList from '@/components/Requisition/IssuingList.vue'
import { inject } from 'vue'

const user = inject('User')
console.log(user)
</script>