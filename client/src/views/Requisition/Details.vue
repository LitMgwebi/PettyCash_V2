<template>
	<div v-if="requisition">
		{{ requisition }}

		<Buttonhandler :requisition="requisition" />
	</div>
	<div v-else>Cannot find requisition details</div>
</template>

<script setup>
import { defineProps, toRefs } from 'vue'
import { getRequisition } from '@/hooks/requisitionCRUD'
import Buttonhandler from '@/components/Requisition/ButtonHandler.vue'

const props = defineProps(['id'])
const { id } = toRefs(props)

const { requisition } = getRequisition(id.value)
</script>