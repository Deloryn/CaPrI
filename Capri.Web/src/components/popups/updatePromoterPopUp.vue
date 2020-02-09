<template>
    <v-dialog
		@click:outside="clearInputs"
		v-model="params.show"
		:max-width="params.maxWidth"
	>
		<v-form class="whiteBackground" ref="updatePromoterForm" v-model="isFormValid">
			<v-container class="table">
				<v-row>
					<v-col>
						<v-text-field readonly v-model="fullName" />
					</v-col>
				</v-row>
				<v-row>
					<v-col cols="6">
						<v-text-field
							type="number"
							:label="$i18n.t('promoter.expectedNumberOfBachelorProposals')"
							v-model="expectedBachelors"
							:rules="expectedBachelorsRules"
						/>
					</v-col>
					<v-col cols="6">
						<v-text-field
							type="number"
							:label="$i18n.t('promoter.expectedNumberOfMasterProposals')"
							v-model="expectedMasters"
							:rules="expectedMastersRules"
						/>
					</v-col>
				</v-row>
				<v-row>
					<v-col>
						<v-btn 
							color="#12628d" 
							class="cancelButton" 
							@click="cancelPopUp"
						>
							{{ $i18n.t('commons.cancel') }}
						</v-btn>
					</v-col>
					<v-col>
						<v-btn class="submitButton green" @click="submit">{{ $i18n.t('commons.update') }}</v-btn>
					</v-col>
				</v-row>
			</v-container>
		</v-form>
	</v-dialog>
</template>


<script>
import { Vue } from 'vue-property-decorator';
import { promoterService } from '@src/services/promoterService'
import { bus } from '@src/services/eventBus'

export default Vue.component('updateProposalPopUp',{
	props: {
		params: Object,
	},
	methods: {
		cancelPopUp: function() {
			this.params.show = false;
			this.clearInputs();
		},
		clearInputs: function() {
			this.$refs.updatePromoterForm.resetValidation();
			this.fullName = "";
			this.expectedBachelors = "";
			this.expectedMasters = "";
		},
		fillInputs: function(promoter) {
			this.promoter = promoter;
			this.fullName = this.promoter.fullName;
			this.expectedBachelors = this.promoter.expectedNumberOfBachelorProposals;
			this.expectedMasters = this.promoter.expectedNumberOfMasterProposals;
		},
		submit: function() {
			if(this.$refs.updatePromoterForm.validate()) {
				var promoterRegistration = {
					expectedNumberOfBachelorProposals: this.expectedBachelors,
					expectedNumberOfMasterProposals: this.expectedMasters
				}
				promoterService.update(this.promoter.id, promoterRegistration)
					.then(response => {
						if(response.status == 200) {
							bus.$emit('promoterWasUpdated');
							this.params.show = false;
							this.clearInputs();
						}
					});
			}
		},
	},
	data() {
		return {
			isFormValid: false,
			fullName: "",
			expectedBachelors: "",
			expectedMasters: "",
			
			expectedBachelorsRules: [
				v => !!v || this.$i18n.t('rules.expectedBachelors.required'),
				v => v >= 0 || this.$i18n.t('rules.expectedBachelors.nonNegative'),
				v => v <= 10 || this.$i18n.t('rules.expectedBachelors.atMost10')
			],
			expectedMastersRules: [
				v => !!v || this.$i18n.t('rules.expectedMasters.required'),
				v => v >= 0 || this.$i18n.t('rules.expectedMasters.nonNegative'),
				v => v <= 10 || this.$i18n.t('rules.expectedMasters.atMost10')
			]
		}
	},
	created() {
		bus.$on('showPromoterToUpdate', this.fillInputs);
	}
})
</script>


<style lang="scss" scoped>
.table {
	background-color: #ffffff;
}
.submitButton {
    font-size: 18px !important;
	color: rgb(255, 255, 255) !important;
	width: 180px !important;
	height: 70px !important;
	margin-left: 50px;
	float: left;
}

.cancelButton {
	font-size: 18px !important;
	color: rgb(255, 255, 255) !important;
	width: 180px !important;
	height: 70px !important;
	margin-right: 50px;
	float: right;
}
</style>
