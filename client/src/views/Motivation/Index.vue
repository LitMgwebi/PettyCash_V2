<template>
	<h2>Motivation for #{{ id }}</h2>
	// TODO Figure out where motivation index will be outputted
	<aside>
		<section class="table">
			<div v-if="motivations">
				<div v-if="motivations.length > 0">
					<div v-for="motivation in motivations" :key="motivation">
						<span> {{ motivation.fileName }} {{ motivation.dateUploaded }} </span>
						<button @click="deleteRecord(motivation)">Delete</button>
					</div>
				</div>
				<div v-else>
					There are no motivations uploaded. Please upload a motivation for your
					requisition to be sent for recommendation
				</div>
			</div>
		</section>
	</aside>
	<aside>
		<section class="create">
			<h3>Upload Motivation</h3>
			<form @submit.prevent="saveImage" enctype="multipart/form-data">
				<input type="file" ref="file" @change="(e) => (file = e.target.files[0])" />
				<button type="submit">Upload</button>
			</form>
		</section>
	</aside>
</template>

<script setup>
import { defineProps, toRefs, ref } from 'vue'
import { addMotivation, getMotivations, deleteMotivation } from '@/hooks/motivationCRUD'

const props = defineProps(['id'])
const { id } = toRefs(props)
const { motivations } = getMotivations(id.value)
const file = ref(null)
let formData = new FormData()

function saveImage() {
	formData.append = ('file', file.value)
	addMotivation(formData, id.value)
}

function deleteRecord(motivation) {
	deleteMotivation(motivation)
}
</script>