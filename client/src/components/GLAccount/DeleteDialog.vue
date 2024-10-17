<template>
	<v-card v-if="glaccount != null">
		<v-card-title class="text-h5">
			Are you sure you want to delete this {{ glAccount.name }}?
		</v-card-title>
		<v-card-actions>
			<v-spacer></v-spacer>
			<v-btn color="blue-darken-1" variant="text" @click="closeDialog()">Cancel</v-btn>
			<v-btn color="blue-darken-1" variant="text" @click="deleteRecord()">Yes</v-btn>
			<v-spacer></v-spacer>
		</v-card-actions>
	</v-card>
</template>

<script setup>
import { defineProps, defineEmits } from 'vue'
import { deleteGLAccount } from '@/hooks/glAccountCRUD'

const props = defineProps(['glaccount'])
const emit = defineEmits(['closeDialog'])
const glAccount = props.glaccount
function deleteRecord() {
	deleteGLAccount(glAccount)
	closeDialog()
}

// TODO figure out a way to close the datatable from Delete Dialog that doesnt go through expansion
function closeDialog() {
	emit('closeDialog', false)
	emit('closeExansion')
}
</script>
