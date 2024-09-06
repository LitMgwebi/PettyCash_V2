<template>
	<v-container>
		<v-row>
			<v-col>
				<h2>GL Accounts</h2>
			</v-col>
		</v-row>
		<v-row>
			<v-data-table-server
				v-model:items-per-page="options.itemsPerPage"
				v-model:page="options.page"
				v-model:expanded="expanded"
				:headers="headers"
				:items="paginatedItems"
				:items-length="totalItems"
				item-value="glaccountId"
				:search="filterDivision"
				show-expand
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

//#region GET call

const typeOfGLGet = inject('typeOfGLGet')
const filterDivision = ref({
	divisionId: 0,
	name: 'All',
	description: '',
	departmentId: 0
})

const { divisions, getter: divisionGetter } = getDivisions()
const { glAccounts, getter: glAccountGetter } = getGLAccounts()
onMounted(async () => await divisionGetter())

watch(
	glAccounts,
	async () => {
		await glAccountGetter(typeOfGLGet.All, filterDivision.value.divisionId)
		updateTableData()
	},
	{ deep: true, immediate: true }
)

//#endregion

//#region Pagination and sorting datatble

const paginatedItems = ref([]) // Data to show in the table
const totalItems = ref(0)
const options = ref({
	page: 1,
	itemsPerPage: 5,
	sortBy: [],
	sortDesc: []
})
const headers = [
	{ title: 'Id', key: 'glaccountId' },
	{ title: 'Name', key: 'name' },
	{ title: 'Description', key: 'description' },
	{ title: '', key: 'data-table-expand' }
]

const updateTableData = () => {
	let sortedItems = [...glAccounts.value]
	totalItems.value = glAccounts.value.length
	// Handle sorting
	if (options.value.sortBy.length > 0) {
		const sortKey = options.value.sortBy[0]
		const sortDesc = options.value.sortDesc[0]

		sortedItems.sort((a, b) => {
			if (a[sortKey] < b[sortKey]) return sortDesc ? 1 : -1
			if (a[sortKey] > b[sortKey]) return sortDesc ? -1 : 1
			return 0
		})
	}

	// Handle pagination
	const start = (options.value.page - 1) * options.value.itemsPerPage
	const end = start + options.value.itemsPerPage
	paginatedItems.value = sortedItems.slice(start, end)
}

//#endregion

//#region Dialog and Expansion config

const dialog = ref(false)
const expanded = ref([])
const closeExansion = () => (expanded.value = [])
const closeDialog = () => (dialog.value = false)

//#endregion
</script>