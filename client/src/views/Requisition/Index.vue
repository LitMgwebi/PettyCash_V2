<template>
	<v-row>
		<h2>Petty Cash Requests</h2>
	</v-row>
	<v-row>
		<v-sheet elevation="8" class="mx-auto">
			<v-slide-group center-active show-arrows>
				<v-slide-group-item
					v-if="
						user.role != 'Executive' &&
						user.role != 'GM_Manager' &&
						!(
							(user.role == 'Manager' || user.role == 'Senior_Employee') &&
							user.divisionId == 6
						)
					"
				>
					<router-link :to="{ name: 'applied_list' }">
						<v-card title="View your requisitions"></v-card>
					</router-link>
				</v-slide-group-item>
				<v-slide-group-item
					v-if="
						(user.role == 'Manager' && user.divisionId != 6) ||
						user.role == 'GM_Manager' ||
						user.role == 'Senior_Employee'
					"
				>
					<router-link :to="{ name: 'recommended_list' }">
						<v-card title="Requisitions requiring recommendation"></v-card>
					</router-link>
				</v-slide-group-item>

				<v-slide-group-item
					v-if="
						(user.role == 'Senior_Employee' ||
							user.role == 'Manager' ||
							user.role == 'Executive') &&
						user.divisionId == 6
					"
				>
					<router-link :to="{ name: 'approval_list' }">
						<v-card title="Requisitions requiring approval"></v-card>
					</router-link>
				</v-slide-group-item>

				<v-slide-group-item v-if="user.jobTitleId == 16">
					<router-link :to="{ name: 'issuing_list' }">
						<v-card title="Requisitions requiring issuing"></v-card>
					</router-link>
				</v-slide-group-item>

				<v-slide-group-item v-if="user.jobTitleId == 16">
					<router-link :to="{ name: 'close_list' }">
						<v-card title="Requisitions requiring closing"></v-card>
					</router-link>
				</v-slide-group-item>
			</v-slide-group>
		</v-sheet>
	</v-row>

	<v-container>
		<router-view></router-view>
	</v-container>
</template>

<script setup>
import { inject } from 'vue'

const user = inject('User')
</script>