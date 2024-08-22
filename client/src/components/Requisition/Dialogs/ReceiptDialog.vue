<template>
	<v-card max-width="400" prepend-icon="mdi-update">
		<div>
			<v-data-table-server :headers="headers" :items="receipts">
				<template
					v-slot:[`item.delete`]="{ item }"
					v-if="
						user.id == requisition.applicant.id &&
						requisition.confirmChangeReceived == false
					"
				>
					<v-btn v-on:click="deleteReceipt(item)">Delete</v-btn>
				</template>
			</v-data-table-server>
		</div>
		<!-- // TODO figure out a way to stop the uploading of documents once the requisition is closed. Both client and server sides -->
		<div v-if="user.id == requisition.applicant.id && requisition.CloseDate == null">
			<section class="create">
				<h3>Upload Receipt</h3>
				<form @submit.prevent="saveReceipt" enctype="multipart/form-data">
					<input
						type="file"
						ref="file"
						@change="(e) => (file = e.target.files[0])"
						accept="application/pdf"
					/>
					<button type="submit">Upload</button>
				</form>
			</section>
		</div>
		<template v-slot:actions>
			<v-btn class="ms-auto" text="Close" @click="closeDialog"></v-btn>
		</template>
	</v-card>
</template>

<script setup>
import { defineProps, defineEmits, inject, watch, ref } from 'vue'
import { addDocument, getDocuments, deleteDocument } from '@/hooks/documentCRUD'
import router from '@/router/router'

const { documents: receipts, getter } = getDocuments()

const typeOfFile = inject('typeOfFile')
const user = inject('User')
const formData = new FormData()
const file = ref(null)
const props = defineProps(['requisition'])
const requisition = props.requisition
const headers = [
	{ title: 'Full Name', value: 'fileName' },
	{ title: 'Date Uploaded', value: 'dateUploaded' },
	{ title: '', value: 'delete' }
]

watch(
	() => {
		props.requisition
	},
	async (oldRequisition, newRequisition) => {
		await getter(typeOfFile.Receipt, requisition.requisitionId)
	},
	{ immediate: true }
)
const emit = defineEmits(['closeDialog'])

function closeDialog() {
	emit('closeDialog', false)
}

function deleteReceipt(receipt) {
	deleteDocument(receipt)
	closeDialog()
}

function saveReceipt() {
	formData.append = ('file', file.value)
	addDocument(formData, requisition.requisitionId, typeOfFile.Receipt)
	closeDialog()
}
</script>