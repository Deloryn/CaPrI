<template>
	<v-container fluid grid-list-xl class="mainView">
		<v-row justify="center">
			<!-- <popUp :proposals="popUp">
				<template v-slot:after>
					<v-col cols="12" class="text-center">
						<v-btn
							color="#12628d"
							class="proposalDetailsCloseButton"
							@click="popUp.show = false"
							>Close</v-btn
						>
					</v-col>
				</template>
			</popUp> -->

            <v-col cols="12">
                <v-data-table 
                    :headers="headers"
                    :items="simplifiedProposals"
                    @click:row="showDialog"
                    id="proposalstable"
                    class="table"
                >
                    <template v-slot:item="{ item }">
                        <tr>
                        <td>{{ item.topic }}</td>
                        <td>{{ item.promoter }}</td>
                        <td>{{ item.freeSlots }}</td>
                        </tr>
                    </template>

                </v-data-table>
            </v-col>
		</v-row>
	</v-container>
</template>
<script>
import { promoterService } from '@src/services/promoterService'
import { proposalService } from '@src/services/proposalService'
import { courseService } from '@src/services/courseService'
import displayDetailsPopUp from '@src/components/popups/displayDetailsPopUp'

export default {
    name: 'proposalsView',
    data() {
        return {
            proposals: [],
            simplifiedProposals: [],
            headers: [
                {
                    sortable: true,
                    text: 'Topic',
                    value: 'topic',
                    width: '60%',
                    align: 'left',
                    class: 'blue--text text--darken-4 display-1'
                },
                {
                    sortable: true,
                    text: 'Promoter',
                    value: 'promoter',
                    width: '30%',
                    align: 'left',
                    class: 'blue--text text--darken-4 display-1'
                },
                {
                    sortable: true,
                    text: 'Free slots',
                    value: 'freeSlots',
                    width: '10%',
                    align: 'left',
                    class: 'blue--text text--darken-4 display-1'
                },
            ],
            displayDetailsPopUpParams: {
                show: false,
                maxWidth: 1000,
                data: {
                    topicPolish: { 
                        text: '', 
                        label: 'Polish title', 
                        type: 'textField', 
                        columns: 12 },
                    topicEnglish: { 
                        text: '', 
                        label: 'English title', 
                        type: 'textField', 
                        columns: 12 },
                    promoter: {
                        text: '',
                        label: 'Promoter',
                        type: 'textField',
                        columns: 12,
                    },
                    course: {
                        text: '',
                        label: 'Course',
                        type: 'textField',
                        columns: 12,
                    },
                    level: {
                        text: '',
                        label: 'Study level',
                        type: 'textField',
                        columns: 4,
                    },
                    mode: {
                        text: '',
                        label: 'Study mode',
                        type: 'textField',
                        columns: 4,
                    },
                    status: {
                        text: '',
                        label: 'Proposal status',
                        type: 'textField',
                        columns: 4,
                    },
                    studyProfile: {
                        text: '',
                        label: 'Study profile',
                        type: 'textField',
                        columns: 4,
                    },
                    numOfAvailableSlots: { 
                        text: '', 
                        label: 'Number of available slots', 
                        type: 'textField', 
                        columns: 4 },
                    description: {
                        text: '',
                        label: 'Description',
                        type: 'textAreaField',
                        columns: 12,
                    },
                    outputData: {
                        text: '',
                        label: 'Output data',
                        type: 'textAreaField',
                        columns: 12,
                    },
                    specialization: {
                        text: '',
                        label: 'Specialization',
                        type: 'textAreaField',
                        columns: 12,
                    },
                    startingDate: {
                        text: '',
                        label: 'StartingDate',
                        type: 'textAreaField',
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
            proposalService.getAll().then((response) => {
                this.proposals = response.data;
                var simplifiedProposals = [];
                this.proposals.forEach(proposal => {
                    promoterService.get(proposal.promoterId)
                    .then((response) => {
                        let promoterFullName = "";
                        if(response.status == 200) {
                            var promoter = response.data;
                            promoterFullName = promoter.lastName + " " + promoter.firstName;
                        }
                        simplifiedProposals.push({
                            topic: proposal.topicEnglish,
                            promoter: promoterFullName,
                            freeSlots: proposal.maxNumberOfStudents - proposal.students.length
                        });
                    });
                });
                this.simplifiedProposals = simplifiedProposals;
            });            
        },
        toStudyMode: function(type) {
            switch(type) {
                case 0: {
                    return "Full-Time";
                }
                case 1: {
                    return "Part-Time";
                }
                default: {
                    return "Unknown";
                }
            }
        },
        toStudyLevel: function(type) {
            switch(type) {
                case 0: {
                    return "Bachelor";
                }
                case 1: {
                    return "Master";
                }
                default: {
                    return "Unknown";
                }
            }
        },
        toStudyProfile: function(type) {
            switch(type) {
                case 0: {
                    return "General academic";
                }
                default: {
                    return "Unknown";
                }
            }
        },
        toProposalStatus: function(type) {
            switch(type) {
                case 0: {
                    return "Taken";
                }
                case 1: {
                    return "Partially taken";
                }
                case 2: {
                    return "Free";
                }
                default: {
                    return "Unknown";
                }
            }
        },
        showDialog: function(proposal) {
            promoterService.get(proposal.promoterId)
                .then(response => {
                    if(response.status == 200) {
                        var promoter = response.data;
                        var fullName = promoter.titlePrefix + " " + promoter.firstName + promoter.lastName;
                        if(promoter.titlePostfix) {
                            fullName += ", ";
                            fullName += promoter.titlePostfix;
                        }
                        this.displayDetailsPopUpParams.data.promoter.text = fullName;
                    }
                })
            courseService.get(proposal.courseId)
                .then((response) => {
                    if(response.status == 200) {
                        var course = response.data;
                        this.displayDetailsPopUpParams.data.course.text = course.name;
                    }
                    return "";
                })
            this.displayDetailsPopUpParams.data.topicEnglish.text = proposal.topicEnglish;
            this.displayDetailsPopUpParams.data.topicPolish.text = proposal.topicPolish;
            this.displayDetailsPopUpParams.data.mode.text = this.toStudyMode(proposal.mode);
            this.displayDetailsPopUpParams.data.level.text = this.toStudyLevel(proposal.level);
            this.displayDetailsPopUpParams.data.studyProfile.text = this.toStudyProfile(proposal.studyProfile);
            this.displayDetailsPopUpParams.data.status.text = this.toProposalStatus(proposal.status);
            this.displayDetailsPopUpParams.data.numOfAvailableSlots.text = (proposal.maxNumberOfStudents - proposal.students.length).toString()
            this.displayDetailsPopUpParams.data.description.text = proposal.description;
            this.displayDetailsPopUpParams.data.specialization.text = proposal.specialization;
            this.displayDetailsPopUpParams.data.outputData.text = proposal.outputData;
            this.displayDetailsPopUpParams.data.startingDate.text = proposal.startingDate;
            this.displayDetailsPopUpParams.show = true;
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

#proposalstable td {
	font-size: 24px;
	font-weight: bold;
}

.proposalDetailsCloseButton {
	width: 33%;
	color: #ffffff;
	font-size: 24px;
}
</style>
