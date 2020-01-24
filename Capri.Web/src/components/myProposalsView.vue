<template>
	<v-container fluid grid-list-xl class="mainView">
		<v-row justify="center">
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
					:items="myProposals"
					class="whiteBack"
                    id="myproposalstable"
				>
                    <template v-slot:item="{ item }">
                            <tr @click="showDetails(item)">
                            <td>{{ item.topic }}</td>
                            <td>{{ item.levelText }}</td>
                            <td>{{ item.modeText }}</td>
                            <td>{{ item.stateText }}</td>
                            </tr>
                    </template>
				</v-data-table>
			</v-col>
		</v-row>
	</v-container>
</template>
<script>
import { proposalService } from '@src/services/proposalService'
import { facultyService } from '@src/services/facultyService'
import { courseService } from '@src/services/courseService'
import detailsPopUp from '@src/components/popups/detailsPopUp.vue'

export default {
    name: 'myProposalsView',
    components: {
        detailsPopUp
    },
    data() {
        return {
            myProposals: [],
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
                    faculty: {
                        text: '',
                        label: 'Faculty',
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
                    status: {
                        text: '',
                        label: 'Status',
                        type: 'textField',
                        columns: 4,
                    },
                    mode: {
                        text: '',
                        label: 'Study mode',
                        type: 'textField',
                        columns: 4,
                    },
                    studyProfile: {
                        text: '',
                        label: 'Study profile',
                        type: 'textField',
                        columns: 4,
                    },
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
                    students: {
                        text: '',
                        label: 'Students',
                        type: 'studentField',
                        columns: 12,
                    },
                    startingDate: {
                        text: '',
                        label: 'StartingDate',
                        type: 'textAreaField',
                        columns: 12,
                    }
                },
            },
            studyTypes: ['Full-time', 'Part-time'],
            thesisTypes: ['Bachelor', 'Master'],
            headers: [
                {
                    sortable: true,
                    text: 'Topic',
                    value: 'topic',
                    width: '55%',
                    align: 'center',
                    class: 'blue--text text--darken-4 display-1'
                },
                {
                    sortable: true,
                    text: 'Level',
                    value: 'level',
                    width: '15%',
                    align: 'left',
                    class: 'blue--text text--darken-4 display-1'
                },
                {
                    sortable: true,
                    text: 'Mode',
                    value: 'mode',
                    width: '15%',
                    algin: 'left',
                    class: 'blue--text text--darken-4 display-1'
                },
                {
                    sortable: true,
                    text: 'State',
                    value: 'state',
                    width: '15%',
                    algin: 'left',
                    class: 'blue--text text--darken-4 display-1'
                }
            ]
        }
    },
    created() {
        this.getData();
    },
    methods: {
        getData: function() {
            proposalService.getMyProposals()
                .then(response => {
                    if(response.status == 200) {
                        this.myProposals = response.data;
                        this.myProposals.forEach(proposal => {
                            proposal.topic = proposal.topicEnglish;
                            proposal.levelText = this.toStudyLevel(proposal.level);
                            proposal.modeText = this.toStudyMode(proposal.mode);
                            proposal.stateText = this.toProposalStatusText(proposal);
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
        toProposalStatusText: function(proposal) {
            return proposal.students.length + " / " + proposal.maxNumberOfStudents;
        },
        showDetails: function(proposal) {
            this.popUpParams.data.topicEnglish.text = proposal.topicEnglish;
            this.popUpParams.data.topicPolish.text = proposal.topicPolish;
            this.popUpParams.data.mode.text = this.toStudyMode(proposal.mode);
            this.popUpParams.data.level.text = this.toStudyLevel(proposal.level);
            this.popUpParams.data.studyProfile.text = this.toStudyProfile(proposal.studyProfile);
            this.popUpParams.data.status.text = this.toProposalStatus(proposal.status);
            this.popUpParams.data.description.text = proposal.description;
            this.popUpParams.data.specialization.text = proposal.specialization;
            this.popUpParams.data.outputData.text = proposal.outputData;
            this.popUpParams.data.startingDate.text = proposal.startingDate;

            this.popUpParams.data.faculty.text = 'to do';
            this.popUpParams.data.course.text = 'to do';

            this.popUpParams.show = true;
        },
        showEmptyDetails: function(proposal) {
            this.popUpParams.data.forEach(element => {
                element.text = '';
            });
            this.popUpParams.data.students.students = ['', ''];
            this.popUpParams.data.students.max = 4;
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
	margin-bottom: 0px;
	background-color: #ffffff;
}
#myproposalstable td {
	font-size: 24px;
	font-weight: bold;
}
.marginBottomSix {
	margin-bottom: 6px;
}
.paintData {
	width: 100%;
	height: 100%;
	border-radius: 0;
}

.buttonStyle {
	width: 200px;
	height: 50px;
	font-size: 24px;
}
.whiteBack {
	background-color: #ffffff;
}
.headerText {
	font-size: 30px;
	color: rgb(18, 98, 141);
}
.itemText {
	float: left;
	font-size: 24px;
	font-weight: bold;
}
.addItem {
	font-size: 24px;
	font-weight: bold;
}
.formDiv {
	color: rgb(255, 255, 255);
	width: 150px;
	height: 50px;
	font-size: 24px;
}
</style>
