<template>
	<v-container fluid grid-list-xl class="mainView">
		<v-row justify="center">
			<v-col cols="12">
				<v-data-table
					:headers="headers"
					:items="mySimplifiedProposals"
					@click:row="showpopUp"
					class="whiteBack"
                    id="myproposalstable"
				>
                    <template v-slot:item="{ item }">
                            <tr>
                            <td>{{ item.topic }}</td>
                            <td>{{ item.level }}</td>
                            <td>{{ item.mode }}</td>
                            <td>{{ item.state }}</td>
                            </tr>
                    </template>
				</v-data-table>
			</v-col>
		</v-row>
	</v-container>
</template>
<script>
import { proposalService } from '@src/services/proposalService'


export default {
    name: 'myProposalsView',
    data() {
        return {
            myProposals: [],
            mySimplifiedProposals: [],
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
                        var simplifiedProposals = []
                        this.myProposals.forEach(proposal => {
                            simplifiedProposals.push({
                                topic: proposal.topicEnglish,
                                level: this.toStudyLevel(proposal.level),
                                mode: this.toStudyMode(proposal.mode),
                                state: this.toProposalStatus(proposal)
                            });
                        });
                        this.mySimplifiedProposals = simplifiedProposals;
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
        toProposalStatus: function(proposal) {
            return proposal.students.length + " / " + proposal.maxNumberOfStudents;
        },
        showpopUp: function(value) {
            this.popUpParams.data.title.text = value.title;
            this.popUpParams.data.studyType.text = value.studyType;
            this.popUpParams.data.thesisType.text = value.thesisType;
            this.popUpParams.data.description.text = value.description;
            this.popUpParams.data.students.students = value.students;
            this.popUpParams.data.thesisType.chosen = value.thesisType;
            this.popUpParams.data.students.max = value.maxStudents;
            this.popUpParams.show = true;
        },
        showEmptypopUp: function() {
            this.popUpParams.data.title.text = '';
            this.popUpParams.data.studyType.text = '';
            this.popUpParams.data.thesisType.text = '';
            this.popUpParams.data.description.text = '';
            this.popUpParams.data.students.students = ['', ''];
            this.popUpParams.data.thesisType.chosen = '';
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
