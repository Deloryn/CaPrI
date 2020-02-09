<template>
	<v-container fluid grid-list-xl class="mainView">
		<v-row>
			<v-col cols="3">
				<v-card class="buttonCard">
					<v-btn class="importButton"
						color="primary"
						@click.stop="importPromoters()">
						{{ $i18n.t('commons.importPromoters') }}
					</v-btn>
				</v-card>
			</v-col>
			<v-col cols="3">
				<v-card class="buttonCard">
					<v-btn class="importButton"
						color="primary"
						@click.stop="exportPromoters()">
						{{ $i18n.t('commons.exportPromoters') }}
					</v-btn>
				</v-card>
			</v-col>
			<v-col cols="2" offset="4">
				<v-select
					v-model="itemsPerPage"
					:items="itemsPerPageOptions"
					:label="$i18n.t('commons.itemsPerPage')"
				/>
			</v-col>
		</v-row>
		<v-row justify="center" class="rowMargin">
			<updatePromoterPopUp :params="updatePromoterPopUpParams" />
			<importPromotersPopUp :params="importPromotersPopUpParams" />
			<v-col cols="12">
				<v-data-table
					:headers="headers"
					:items="promoters"
					:items-per-page="itemsPerPage"
					:page.sync="page"
					hide-default-footer
					id="promoterstable"
					class="whiteBackground"
				>
				<template slot="no-data">
					{{ $i18n.t('commons.dataLoading') }}
				</template>
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
		<v-row>
			<v-col>
					<v-pagination
						v-model="page"
						:length="howManyPagesInTotal"
						:total-visible="totalVisible"
						next-icon="navigate_next"
						prev-icon="navigate_before"
					/>
			</v-col>
		</v-row>
	</v-container>
</template>

<script>

import {promoterService} from '@src/services/promoterService'
import {instituteService} from '@src/services/instituteService'
import {proposalService} from '@src/services/proposalService'
import updatePromoterPopUp from '@src/components/popups/updatePromoterPopUp.vue'
import importPromotersPopUp from '@src/components/popups/importPromotersPopUp.vue'
import { bus } from '@src/services/eventBus'

export default {
	name: 'promotersView',
	components: {
		updatePromoterPopUp,
		importPromotersPopUp
	},
	watch: {
		page: function(newpage) {
			this.getFilteredPromoters();
		},
		itemsPerPage: function(newItemsPerPage) {
			this.getFilteredPromoters();
		}
	},
    data() {
      return {
		institute: null,
		page: 1,
		howManyPagesInTotal: 10,
		itemsPerPage: 10,
		itemsPerPageOptions: [
			5,
			10,
			15
		],
		totalVisible: 8,
		promoters: [],
		headers: [
			{ 
				text: this.$i18n.t('promoter.promoter'), 
				value: 'name', 
				class: 'blue--text text--darken-4 display-1', 
				align: 'left', 
				width: '60%',
				sortable: false 
			},
			{ 
				text: this.$i18n.t('level.bachelorShort'), 
				value: 'expectedNumberOfBachelorProposals', 
				class: 'blue--text text--darken-4 display-1', 
				align: 'left', 
				width: '20%', 
				sortable: false 
			},
			{ 
				text: this.$i18n.t('level.masterShort'),
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
        },
        importPromotersPopUpParams: {
			show: false,
			maxWidth: 800,
		}
      }
	},
	created() {
		bus.$on('promotersFiltersWereChosen', this.onInstituteChange);
		bus.$on('promoterWasUpdated', this.getFilteredPromoters);
		this.getFilteredPromoters();
	},
	methods: {
		chooseFile: function() {
			document.getElementById("promotersFileInput").click()
		},
		onInstituteChange: function(institute) {
			this.page = 1;
			this.institute = institute;
			this.getFilteredPromoters();
		},
		getFilteredPromoters: function() {
            this.promoters = [];
            var sorts = "lastname";
            var page = this.page;
            var pageSize = this.itemsPerPage;
            var filters = "";
            if(this.institute && this.institute.id) {
                filters += "instituteid==" + this.institute.id + ",";
			}

			promoterService.count(sorts, filters)
				.then(response => {
					if(response.status == 200) {
						var total = response.data;
						this.howManyPagesInTotal = Math.ceil(total/this.itemsPerPage);
						promoterService.getFiltered(sorts, filters, page, pageSize)
							.then(response => {
								if(response.status == 200) {
									this.promoters = [];
									var promoters = response.data;
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
							}
						});
					}
				})
        },
		showUpdatePromoterPopUp: function(promoter) {
			bus.$emit('showPromoterToUpdate', promoter);
			this.updatePromoterPopUpParams.show = true;
        },
        importPromoters: function() {
			this.importPromotersPopUpParams.show = true;
		},
		exportPromoters: function() {
			promoterService.exportPromoters()
				.then(response => {
					let filename = response.headers['content-disposition'];
                    filename = filename.slice(filename.indexOf('filename=')+9, 
                        filename.indexOf('.json', filename.indexOf('filename='))+5);
                    if (!filename.endsWith('.json')) filename += '.json';

                    const url = window.URL.createObjectURL(new Blob([response.data], 
                        {type: response.headers['content-type']}));
                    const link = document.createElement('a');
                    link.href = url;
                    link.setAttribute('download', filename);
                    document.body.appendChild(link);
                    link.click();
				})
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
