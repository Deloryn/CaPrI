<template>
    <v-dialog
		@click:outside="clearInputs"
		v-model="params.show"
		:max-width="params.maxWidth"
	>
		<v-form class="whiteBackground" ref="displayProposalForm">
			<v-container class="table">
				<v-row>
					<v-col>
						<v-text-field 
							v-model="topicPolish"
							:label="$i18n.t('proposal.titlePolish')"
							readonly
						/>
					</v-col>
				</v-row>
				<v-row>
					<v-col>
						<v-text-field 
							v-model="topicEnglish"
							:label="$i18n.t('proposal.titleEnglish')"
							readonly
						/>
					</v-col>
				</v-row>
				<v-row>
					<v-col cols="4">
						<v-text-field 
							v-model="promoter"
							:label="$i18n.t('promoter.promoter')"
							readonly
						/>
					</v-col>
					<v-col cols="4">
						<v-text-field 
							v-model="course"
							:label="$i18n.t('course.course')"
							readonly
						/>
					</v-col>
					<v-col cols="4">
						<v-text-field 
							v-model="faculty"
							:label="$i18n.t('faculty.faculty')"
							readonly
						/>
					</v-col>
				</v-row>
				<v-row>
					<v-col cols="4">
						<v-text-field 
							v-model="level"
							:label="$i18n.t('level.level')"
							readonly
						/>
					</v-col>
					<v-col cols="4">
						<v-text-field 
							v-model="mode"
							:label="$i18n.t('mode.mode')"
							readonly
						/>
					</v-col>
					<v-col cols="4">
						<v-text-field 
							v-model="profile"
							:label="$i18n.t('profile.profile')"
							readonly
						/>
					</v-col>
				</v-row>
				<v-row>
					<v-col cols="6">
						<v-text-field 
							v-model="status"
							:label="$i18n.t('status.status')"
							readonly
						/>
					</v-col>
					<v-col cols="6">
						<v-text-field 
							v-model="freeSlots"
							:label="$i18n.t('proposal.freeSlots')"
							readonly
						/>
					</v-col>
				</v-row>
				<v-row>
					<v-col cols="12">
						<v-textarea
							v-model="description"
							:label="$i18n.t('proposal.description')"
							readonly
						/>
					</v-col>
				</v-row>
				<v-row>
					<v-col cols="12">
						<v-textarea
							v-model="outputData"
							:label="$i18n.t('proposal.outputData')"
							readonly
						/>
					</v-col>
				</v-row>
				<v-row>
					<v-col cols="4">
						<v-text-field 
							v-model="startDate"
							:label="$i18n.t('proposal.startingDate')"
							readonly
						/>
					</v-col>
				</v-row>
			</v-container>
		</v-form>
	</v-dialog>
</template>


<script>
import { Vue } from 'vue-property-decorator';
import { proposalService } from '@src/services/proposalService'
import { facultyService } from '@src/services/facultyService'
import { courseService } from '@src/services/courseService'
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
				this.topicPolish = "";
				this.topicEnglish = "";
				this.description = "";
				this.outputData = "";
				this.specialization = "";
				this.course = "";
				this.faculty = "";
				this.promoter = "";
				this.level = "";
				this.status = "";
				this.mode = "";
				this.profile = "";
				this.freeSlots = "";
				this.startDate = "";
		},
		fillForm: function(proposalId) {
			proposalService.get(proposalId)
				.then(response => {
					if(response.status == 200) {
						var rawProposal = response.data;
						promoterService.get(rawProposal.promoterId)
							.then(response => {
								if(response.status == 200) {
									var rawPromoter = response.data;
									courseService.get(rawProposal.courseId)
										.then(response => {
											if(response.status == 200) {
												var rawCourse = response.data;
												facultyService.get(rawCourse.facultyId)
													.then(response => {
														if(response.status == 200) {
															var rawFaculty = response.data;
																var promoterFullName = rawPromoter.titlePrefix + " " 
																	+ rawPromoter.firstName + " "
																	+ rawPromoter.lastName
																if(rawPromoter.titlePostfix) {
																	promoterFullName += ", "
																	promoterFullName += rawPromoter.titlePostfix
																}
																this.promoter = promoterFullName;
																this.freeSlots = rawProposal.maxNumberOfStudents - rawProposal.students.length;
																this.startDate = rawProposal.startingDate.substring(0, 10);
																this.topicPolish = rawProposal.topicPolish;
																this.topicEnglish = rawProposal.topicEnglish;
																this.description = rawProposal.description;
																this.outputData = rawProposal.outputData;
																this.specialization = rawProposal.specialization;
																this.course = rawCourse.name;
																this.faculty = rawFaculty.name;
																this.level = this.toStudyLevel(rawProposal.level);
																this.status = this.toProposalStatus(rawProposal.status);
																this.mode = this.toStudyMode(rawProposal.mode);
																this.profile = this.toStudyProfile(rawProposal.studyProfile);
														}
													});
											}
										});
								}
							});
					}
				});
		},
		toStudyMode: function(type) {
            switch(type) {
                case 0: {
                    return this.$i18n.t('mode.fullTime');
                }
                case 1: {
                    return this.$i18n.t('mode.partTime');
                }
                default: {
                    return '?';
                }
            }
        },
        toStudyLevel: function(type) {
            switch(type) {
                case 0: {
                    return this.$i18n.t('level.bachelor');
                }
                case 1: {
                    return this.$i18n.t('level.master');
                }
                default: {
                    return '?';
                }
            }
        },
        toStudyProfile: function(type) {
            switch(type) {
                case 0: {
                    return this.$i18n.t('profile.generalAcademic');
                }
                default: {
                    return '?';
                }
            }
        },
        toProposalStatus: function(type) {
            switch(type) {
                case 0: {
                    return this.$i18n.t('status.taken');
                }
                case 1: {
                    return this.$i18n.t('status.partiallyTaken');
                }
                case 2: {
                    return this.$i18n.t('status.free');
                }
                default: {
                    return '?';
                }
            }
        }
	},
	data() {
		return {
			isFormValid: false,
			topicPolish: "",
			topicEnglish: "",
			description: "",
			outputData: "",
			specialization: "",
			course: "",
			faculty: "",
			promoter: "",
			level: "",
			status: "",
			mode: "",
			profile: "",
			freeSlots: "",
			startDate: ""
		}
	},
	created() {
		bus.$on('displayProposal', this.fillForm);
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
