<template>
	<div v-if="user">
		<h3>Welcome {{ user.fullName }}</h3>
		<v-container>
			<router-link :to="{ name: 'requisitions' }">
				<v-card title="Petty Cash Dashboard"> </v-card>
			</router-link>

			<span v-if="user.role == 'Finance_Admin'">
				<router-link to="/transactions">
					<v-card title="Transactions"> </v-card>
				</router-link>
				<router-link :to="{ name: 'requisitions_statuses' }">
					<v-card title="Requisitions"> </v-card>
				</router-link>
			</span>
			<span v-if="user.role == 'ICT_Admin'">
				<router-link to="/purposes">
					<v-card title="Purposes"> </v-card>
				</router-link>
				<router-link to="/divisions">
					<v-card title="Divisions"> </v-card>
				</router-link>
				<router-link to="/sub_accounts">
					<v-card title="Sub-Accounts"> </v-card>
				</router-link>
				<router-link to="/main_accounts">
					<v-card title="Main Accounts"> </v-card>
				</router-link>
				<router-link to="/gl_accounts">
					<v-card title="GL Accounts"> </v-card>
				</router-link>
				<router-link to="/offices">
					<v-card title="Offices"> </v-card>
				</router-link>
			</span>
		</v-container>
	</div>
</template>

<script setup>
import { inject, ref } from 'vue'
const user = inject('User')
</script>