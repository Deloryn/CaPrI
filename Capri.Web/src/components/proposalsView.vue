<template>
	<v-container fluid grid-list-xl class="mainView">
		<v-row justify="center">
			<detailsPopUp :params="popUpParams">
				<template v-slot:after>
					<v-col cols="12" class="text-center">
						<v-btn
							color="#12628d"
							class="proposalDetailsCloseButton"
							@click="popUpParams.show = false"
							>Close</v-btn
						>
					</v-col>
				</template>
			</detailsPopUp>

            <v-col cols="12">
                <v-data-table 
                    :headers="headers"
                    :items="proposals"
                    id="proposalstable"
                    class="table"
                >
                    <template v-slot:item="{ item }">
                        <tr @click="showDetails(item)">
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
import { facultyService } from '@src/services/facultyService'
import { courseService } from '@src/services/courseService'
import { bus } from '@src/services/eventBus'
import detailsPopUp from '@src/components/popups/detailsPopUp.vue'

export default {
    name: 'proposalsView',
    data() {
        return {
            proposals: [],
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
            popUpParams: {
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
        this.getData();
        bus.$on('filtersWereChosen', this.filterProposals);
        bus.$on('proposalWasCreated', this.getData);
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
                        
                        proposal.promoter = promoterFullName;
                    });
                    proposal.topic = proposal.topicEnglish;
                    proposal.freeSlots = proposal.maxNumberOfStudents - proposal.students.length;
                });
            });            
        },
        filterProposals: function(chosenFilters) {
            this.proposals = [];
            var sorts = "";
            var page = 1;
            var pageSize = 10;
            var filters = "";
            if(chosenFilters.level != null) {
                filters += "level==" + chosenFilters.level + ",";
            }
            if(chosenFilters.mode != null) {
                filters += "mode==" + chosenFilters.mode + ",";
            }
            if(chosenFilters.course && chosenFilters.course.id) {
                filters += "course_id==" + chosenFilters.course.id + ",";
            }
            if(chosenFilters.faculty && chosenFilters.faculty.id) {
                filters += "faculty_id==" + chosenFilters.faculty.id + ",";
            }

            proposalService.getFiltered(sorts, filters, page, pageSize)
                .then(response => {
                    if(response.status == 200) {
                        this.proposals = response.data;
                        this.proposals.forEach(proposal => {
                            promoterService.get(proposal.promoterId)
                                .then((response) => {
                                    let promoterFullName = "";
                                    if(response.status == 200) {
                                        var promoter = response.data;
                                        promoterFullName = promoter.lastName + " " + promoter.firstName;
                                    }
                                    proposal.promoter = promoterFullName;
                                });
                            proposal.topic = proposal.topicEnglish;
                            proposal.freeSlots = proposal.maxNumberOfStudents - proposal.students.length;
                        });
                    }
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
        showDetails: function(proposal) {
            promoterService.get(proposal.promoterId)
                .then(response => {
                    if(response.status == 200) {
                        var promoter = response.data;
                        var fullName = promoter.titlePrefix + " " + promoter.firstName + " " + promoter.lastName;
                        if(promoter.titlePostfix) {
                            fullName += ", ";
                            fullName += promoter.titlePostfix;
                        }
                        this.popUpParams.data.promoter.text = fullName;
                    }
                })
            courseService.get(proposal.courseId)
                .then((response) => {
                    if(response.status == 200) {
                        var course = response.data;
                        this.popUpParams.data.course.text = course.name;
                    }
                });
            this.popUpParams.data.topicEnglish.text = proposal.topicEnglish;
            this.popUpParams.data.topicPolish.text = proposal.topicPolish;
            this.popUpParams.data.mode.text = this.toStudyMode(proposal.mode);
            this.popUpParams.data.level.text = this.toStudyLevel(proposal.level);
            this.popUpParams.data.studyProfile.text = this.toStudyProfile(proposal.studyProfile);
            this.popUpParams.data.status.text = this.toProposalStatus(proposal.status);
            this.popUpParams.data.numOfAvailableSlots.text = (proposal.maxNumberOfStudents - proposal.students.length).toString()
            this.popUpParams.data.description.text = proposal.description;
            this.popUpParams.data.specialization.text = proposal.specialization;
            this.popUpParams.data.outputData.text = proposal.outputData;
            this.popUpParams.data.startingDate.text = proposal.startingDate;
            this.popUpParams.show = true;
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
