<template>
	<v-container fluid grid-list-xl class="mainView">
		<v-row justify="center" class="rowMargin">
			<detailsPopUp v-bind:params="popUpParams">
				<template v-slot:after>
					<v-col cols="12" class="text-center">
						<v-btn
							color="#12628d"
							class="promoterCloseButton"
							@click="popUpParams.show = false"
							>Close</v-btn
						>
					</v-col>
				</template>
			</detailsPopUp>
			<v-col cols="12">
				<v-data-table
					:headers="headers"
					:items="promoters"
					id="promoterstable"
					class="whiteBackground"
				>
				<template v-slot:item="{ item }">
					<tr @click="showDetails(item)">
					<td>{{ item.lastName }} {{ item.firstName }}</td>
					<td>{{ item.expectedNumberOfBachelorProposals }}</td>
					<td>{{ item.expectedNumberOfMasterProposals }}</td>
					</tr>
				</template>
				</v-data-table>
			</v-col>
		</v-row>
	</v-container>
</template>

<script>

import {promoterService} from '@src/services/promoterService'
import {instituteService} from '@src/services/instituteService'
import {proposalService} from '@src/services/proposalService'
import detailsPopUp from '@src/components/popups/detailsPopUp.vue'

export default {
	name: 'promotersView',
	components: {
        detailsPopUp,
    },
    data() {
      return {
		promoters: [],
		headers: [
			{ 
				text: 'Promoter', 
				value: 'name', 
				class: 'blue--text text--darken-4 display-1', 
				align: 'left', 
				width: '30%', 
				sortable: false 
			},
			{ 
				text: 'Expected bachelor proposals', 
				value: 'expectedNumberOfBachelorProposals', 
				class: 'blue--text text--darken-4 display-1', 
				align: 'left', 
				width: '35%', 
				sortable: false 
			},
			{ 
				text: 'Expected master proposals', 
				value: 'expectedNumberOfMasterProposals', 
				class: 'blue--text text--darken-4 display-1', 
				align: 'left', 
				width: '35%', 
				sortable: false 
			},
		],
		popUpParams: {
			show: false,
			maxWidth: 1000,
			data: {
				fullName: { 
					text: '', 
					label: 'Promoter', 
					type: 'textField', 
					columns: 12 },
				institute: { 
					text: '', 
					label: 'Institute', 
					type: 'textField', 
					columns: 12 },
				expectedNumberOfBachelorProposals: {
					text: '',
					label: 'Expected bachelor proposals',
					type: 'textField',
					columns: 12,
				},
				numberOfSubmittedBachelorProposals: {
					text: '',
					label: 'Submitted bachelor proposals',
					type: 'textField',
					columns: 12,
				},
				expectedNumberOfMasterProposals: {
					text: '',
					label: 'Expected master proposals',
					type: 'textField',
					columns: 12,
				},
				numberOfSubmittedMasterProposals: {
					text: '',
					label: 'Submitted master proposals',
					type: 'textField',
					columns: 12,
				},
			},
		}
      }
	},
	created() {
		this.getData()
	},
	methods: {
		getData: function() {
			promoterService.getAll()
			.then(response => {
				this.promoters = response.data
			})
		},
		showDetails: function(promoter) {
			var expectedBachelors = promoter.expectedNumberOfBachelorProposals;
			var expectedMasters = promoter.expectedNumberOfMasterProposals;

			var fullName = promoter.titlePrefix + " " +
                           promoter.firstName + " " +
                           promoter.lastName;
			if(promoter.titlePostfix)
			{
				fullName += ", "
				fullName += promoter.titlePostfix
			}
			
			this.popUpParams.data.fullName.text = fullName;
			this.popUpParams.data.expectedNumberOfBachelorProposals.text = expectedBachelors;
			this.popUpParams.data.expectedNumberOfMasterProposals.text = expectedMasters;

			instituteService.get(promoter.instituteId)
				.then(response => {
					var institute = "";
					if(response.status == 200) {
						institute = response.data.name;
					}
					this.popUpParams.data.institute.text = institute;
				});

			proposalService.calculateSubmittedBachelorProposals(promoter.id)
				.then(response => {
					var submitted = 0;
					if(response.status == 200) {
						submitted = response.data;
					}
					this.popUpParams.data.numberOfSubmittedBachelorProposals.text = submitted;
				});
			proposalService.calculateSubmittedMasterProposals(promoter.id)
				.then(response => {
					var submitted = 0;
					if(response.status == 200) {
						submitted = response.data;
					}
					this.popUpParams.data.numberOfSubmittedMasterProposals.text = submitted;
				});

			this.popUpParams.show = true;
    	}
	},
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

#promoterstable td {
	font-size: 24px;
	font-weight: bold;
}

.promoterCloseButton {
	width: 33%;
	color: #ffffff;
	font-size: 24px;
}
</style>
