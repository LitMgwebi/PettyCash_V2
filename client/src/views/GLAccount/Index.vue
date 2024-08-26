<template>
	<v-container>
		<v-row>
			<v-col>
				<h2>GL Accounts</h2>
			</v-col>
			<v-col>
				<section>
					<label>Filter:</label>
					<select :disabled="divisions.length == 0" v-model="filterDivision">
						<option value="">All</option>
						<option v-for="division in divisions" :value="division" :key="division">
							{{ division.description }}
						</option>
					</select>
				</section>
			</v-col>
		</v-row>
		<v-row>
			<v-data-table-server
				v-model:expanded="expanded"
				:headers="headers"
				:items="glAccounts"
				item-value="glaccountId"
				show-expand
			>
				<template v-slot:top>
					<v-btn @click="dialog = true">Add GL Account</v-btn>
					<v-dialog v-model="dialog" max-width="500px">
						<AddDialog @closeDialog="closeDialog" />
					</v-dialog>
				</template>
				<template v-slot:expanded-row="{ columns, item }">
					<tr>
						<td :colspan="columns.length">
							<DetailsExpanded :glaccountId="item.glaccountId" />
						</td>
					</tr>
				</template>
			</v-data-table-server>
		</v-row>
	</v-container>
</template>

<script setup>
import { getGLAccounts } from '@/hooks/glAccountCRUD'
import { getDivisions } from '@/hooks/divisionCRUD'
import AddDialog from '@/components/GLAccount/AddDialog.vue'
import DetailsExpanded from '@/components/GLAccount/DetailsExpanded.vue'
import { ref, inject, onMounted, watch } from 'vue'

const dialog = ref(false)
const expanded = ref([])
const typeOfGLGet = inject('typeOfGLGet')
const filterDivision = ref({
	divisionId: 0,
	name: '',
	description: '',
	departmentId: 0
})
const headers = [
	{ title: 'Id', key: 'glaccountId' },
	{ title: 'Name', key: 'name' },
	{ title: 'Description', key: 'description' },
	{ title: '', key: 'data-table-expand' }
]

const { divisions, getter: divisionGetter } = getDivisions()
const { glAccounts, getter: glAccountGetter } = getGLAccounts(typeOfGLGet.All)

watch(
	glAccounts,
	async () => await glAccountGetter(typeOfGLGet.All, filterDivision.value.divisionId),
	{ immediate: true }
)

onMounted(async () => await divisionGetter())

const closeExansion = () => (expanded.value = [])
const closeDialog = () => (dialog.value = false)
</script>