<template>
	<v-container fluid grid-list-xl class="mainView">
		<v-row justify="center" class="rowMargin">
			<v-col cols="12">
				<v-data-table
					:headers="headers"
					:items="institutes"
					
					id="institutestable"
					class="whiteBackground"
				>
				<template v-slot:item="{ item }" click="showDialog">
					<tr>
					<td>{{ item.name }}</td>
					</tr>
				</template>
				</v-data-table>
			</v-col>
		</v-row>
	</v-container>
</template>

<script>

import {instituteService} from '@src/services/instituteService'

export default {
	name: 'institutesView',
    data() {
      return {
		institutes: [],
		headers: [
            { 
              text: 'Institute', 
              value: 'name', 
              class: 'blue--text text--darken-4 display-1', 
              align: 'left', 
              width: '100%', 
              sortable: false
            }
		]
      }
	},
	created() {
		this.getData()
	},
	methods: {
		getData: function() {
			instituteService.getAll()
			.then(response => {
				this.institutes = response.data
			})
		}
	}
  }

</script>


<style lang="scss" scoped>
.mainView {
	width: calc(100% - 370px);
	margin-left: 350px;
	margin-right: 10px;
	margin-top: 0px;
	margin-bottom: 140px;
	background-color: #ffffff;
}

#institutestable td {
	font-size: 24px;
	font-weight: bold;
}
</style>
