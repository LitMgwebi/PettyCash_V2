<template>
	<div v-if="user">
		<h3>Welcome {{ user.fullName }}</h3>
	</div>
	<form @submit.prevent="saveImage" enctype="multipart/form-data">
		<input type="file" ref="file" @change="(e) => (file = e.target.files[0])" />
		<button type="submit">Upload</button>
	</form>
</template>

<script setup>
import { inject, ref } from 'vue'
import { addMotivation } from '@/hooks/motivationCRUD'
const user = inject('User')
const file = ref(null)
let formData = new FormData()

// function handleFileUpload() {
// 	const file = ref(null)
// 	this.file = file.value.files
// }

function saveImage() {
	formData.append = ('file', file.value)
	addMotivation(formData)
}
</script>