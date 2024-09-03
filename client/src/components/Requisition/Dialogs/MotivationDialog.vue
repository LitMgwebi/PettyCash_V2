<template>
	<div>
		<v-card max-width="400" prepend-icon="mdi-update">
			<div>
				<v-data-table-server :headers="headers" :items="motivations">
					<template
						v-slot:[`item.delete`]="{ item }"
						v-if="
							user.id == requisition.applicant.id &&
							requisition.managerRecommendation == null
						"
					>
						<v-btn v-on:click="deleteMotivation(item)">Delete</v-btn>
					</template>
				</v-data-table-server>
			</div>
			<div
				v-if="
					user.id == requisition.applicant.id && requisition.managerRecommendation == null
				"
			>
				<section class="create">
					<h3>Upload Motivation</h3>
					<form @submit.prevent="saveMotivation" enctype="multipart/form-data">
						<input
							type="file"
							accept="application/pdf"
							ref="file"
							@change="(e) => (file = e.target.files[0])"
							required
						/>
						<button type="submit">Upload</button>
					</form>
				</section>
			</div>
			<template v-slot:actions>
				<v-btn class="ms-auto" text="Close" @click="closeDialog"></v-btn>
			</template>
		</v-card>
	</div>
</template>

<script setup>
import { defineProps, defineEmits, inject, watch, ref } from 'vue'
import { addDocument, getDocuments, deleteDocument } from '@/hooks/documentCRUD'
import router from '@/router/router'

const { documents: motivations, getter } = getDocuments()
const headers = [
	{ title: 'Full Name', value: 'fileName' },
	{ title: 'Date Uploaded', value: 'dateUploaded' },
	{ title: '', value: 'delete' }
]

const typeOfFile = inject('typeOfFile')
const user = inject('User')
const formData = new FormData()
const file = ref(null)
const props = defineProps(['requisition'])
const requisition = props.requisition

watch(
	() => {
		props.requisition
	},
	async (oldRequisition, newRequisition) => {
		await getter(typeOfFile.Motivation, requisition.requisitionId)
	},
	{ immediate: true }
)
const emit = defineEmits(['closeDialog'])

function closeDialog() {
	emit('closeDialog', false)
}

function deleteMotivation(motivation) {
	deleteDocument(motivation, typeOfFile.Motivation)
	closeDialog()
}

function saveMotivation() {
	formData.append = ('file', file.value)
	addDocument(formData, requisition.requisitionId, typeOfFile.Motivation)
	closeDialog()
}
</script>