<template>
	<v-container fluid grid-list-xl class="mainView">
		<v-row justify="center" class="rowMargin">
			<updatePromoterPopUp :params="updatePromoterPopUpParams" />
			<v-col cols="12">
				<v-data-table
					:headers="headers"
					:items="promoters"
					id="promoterstable"
					class="whiteBackground"
				>
				<template v-slot:item="{ item }">
					<tr @click="showUpdatePromoterPopUp(item)">
					<td>{{ item.lastName }} {{ item.firstName }}</td>
					<td>
						{{ item.submittedBachelors + "/" + item.expectedNumberOfBachelorProposals }}
					</td>
					<td>
						{{ item.submittedMasters + "/" + item.expectedNumberOfMasterProposals }}
					</td>
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
import updatePromoterPopUp from '@src/components/popups/updatePromoterPopUp.vue'
import { bus } from '@src/services/eventBus'

export default {
	name: 'promotersView',
	components: {
        updatePromoterPopUp
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
				width: '60%', 
				sortable: false 
			},
			{ 
				text: 'BSc.', 
				value: 'expectedNumberOfBachelorProposals', 
				class: 'blue--text text--darken-4 display-1', 
				align: 'left', 
				width: '20%', 
				sortable: false 
			},
			{ 
				text: 'MSc.', 
				value: 'expectedNumberOfMasterProposals', 
				class: 'blue--text text--darken-4 display-1', 
				align: 'left', 
				width: '20%', 
				sortable: false 
			},
		],
		updatePromoterPopUpParams: {
			show: false,
			maxWidth: 1000,
		}
      }
	},
	created() {
		this.getData();
	},
	methods: {
		getData: function() {
			promoterService.getAll()
			.then(response => {
				var promoters = response.data
				promoters.forEach(promoter => {
					proposalService.calculateSubmittedBachelorProposals(promoter.id)
						.then(response => {
							var submitted = 0;
							if(response.status == 200) {
								submitted = response.data;
							}
							promoter.submittedBachelors = submitted;

							proposalService.calculateSubmittedMasterProposals(promoter.id)
								.then(response => {
									var submitted = 0;
									if(response.status == 200) {
										submitted = response.data;
									}
									promoter.submittedMasters = submitted;
									var fullName = promoter.titlePrefix + " " +
										promoter.firstName + " " +
										promoter.lastName;
									if(promoter.titlePostfix)
									{
										fullName += ", "
										fullName += promoter.titlePostfix
									}
									promoter.fullName = fullName;
									this.promoters.push(promoter);
								});
						});
				});
			})
		},
		showUpdatePromoterPopUp: function(promoter) {
			bus.$emit('showPromoterToUpdate', promoter);
			this.updatePromoterPopUpParams.show = true;
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
