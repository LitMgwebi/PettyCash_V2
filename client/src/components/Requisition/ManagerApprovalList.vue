<template></template>

<script setup>
import { getRequisitionsForManagerApproval } from '@/hooks/requisitionCRUD'

const { requisitions } = getRequisitionsForManagerApproval()
</script>
