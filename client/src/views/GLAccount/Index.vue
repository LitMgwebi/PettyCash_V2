<template>
	<v-container>
		<v-row>
			<v-col>
				<h2>GL Accounts</h2>
			</v-col>
		</v-row>
		<v-row>
			<v-data-table-server
				v-model:items-per-page="itemsPerPage"
				v-model:expanded="expanded"
				:headers="headers"
				:items="glAccounts"
				:items-length="totalItems"
				:loading="loading"
				item-value="glaccountId"
				:search="filterDivision"
				show-expand
				@update:options="loadItems"
			>
				<template v-slot:top>
					<v-row>
						<v-col v-if="user.role == 'ICT_Admin'">
							<v-btn @click="dialog = true">Add GL Account</v-btn>
							<v-dialog v-model="dialog" max-width="500px">
								<AddDialog @closeDialog="closeDialog" />
							</v-dialog>
						</v-col>
						<v-col>
							<label>Filter:</label>
							<select :disabled="divisions.length == 0" v-model="filterDivision">
								<option value="">All</option>
								<option
									v-for="division in divisions"
									:value="division"
									:key="division"
								>
									{{ division.description }}
								</option>
							</select>
						</v-col>
					</v-row>
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

const user = inject('User')
const dialog = ref(false)
const glAccounts = ref([])
const totalItems = ref([])
const loading = ref(true)
const itemsPerPage = ref(5)
const expanded = ref([])
const typeOfGLGet = inject('typeOfGLGet')
const filterDivision = ref({
	divisionId: 0,
	name: 'All',
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
onMounted(async () => await divisionGetter())

// watch(glAccounts, async () => {}, { immediate: true })
async function loadItems({ page, itemsPerPage, sortBy }) {
	loading.value = true
	const { items, total } = await TableConfig({
		page,
		itemsPerPage,
		sortBy,
		search: filterDivision
	})
	glAccounts.value = items
	totalItems.value = total
	loading.value = false
}
const TableConfig = async ({ page, itemsPerPage, sortBy, search }) => {
	const { glAccounts, getter: glAccountGetter } = getGLAccounts(typeOfGLGet.All)
	await glAccountGetter(typeOfGLGet.All, search.value.divisionId)
	const start = (page - 1) * itemsPerPage
	const end = start + itemsPerPage
	const items = glAccounts.value.slice()

	if (sortBy.length) {
		const sortKey = sortBy[0].key
		const sortOrder = sortBy[0].order
		items.sort((a, b) => {
			const aValue = a[sortKey]
			const bValue = b[sortKey]
			return sortOrder === 'desc' ? bValue - aValue : aValue - bValue
		})
	}

	const paginated = items.slice(start, end)

	return { items: paginated, total: items.length }
}
const closeExansion = () => (expanded.value = [])
const closeDialog = () => (dialog.value = false)
</script>