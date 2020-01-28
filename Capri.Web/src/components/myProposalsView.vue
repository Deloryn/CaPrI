<template>
	<v-container fluid grid-list-xl class="mainView">
        <v-row>
            <v-col>
                <p class="infoText">Expected BSc proposals: {{ numOfSubmittedBachelors + "/" + promoter.expectedNumberOfBachelorProposals }}</p>
                <p class="infoText">Expected MSc proposals: {{ numOfSubmittedMasters + "/" + promoter.expectedNumberOfMasterProposals }}</p>
            </v-col>
            <v-col>
                <v-btn
                    id="createButton"
                    class="promoterButton green"
                    text
                    @click="showProposalCreator"
                >
                    Create
                </v-btn>
            </v-col>
        </v-row>
        <v-row justify="center">
            <createProposalPopUp :params="createProposalParams" />
        </v-row>
		<v-row justify="center">
            <updateProposalPopUp :params="updateProposalParams" />
			<v-col cols="12">
				<v-data-table
					:headers="headers"
					:items="myProposals"
					class="whiteBack"
                    id="myproposalstable"
				>
                    <template v-slot:item="{ item }">
                            <tr @click="showProposalUpdater(item)">
                            <td>{{ item.topic }}</td>
                            <td>{{ item.levelText }}</td>
                            <td>{{ item.modeText }}</td>
                            <td>{{ item.stateText }}</td>
                            <td>
                                <v-btn
                                    @click.stop="deleteMyProposal(item)"
                                >
                                    <v-icon 
                                        color="rgba(255, 0, 0, 0.9)" 
                                        large
                                    >
                                        delete
                                    </v-icon>
                                </v-btn>
                            </td>
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
import createProposalPopUp from '@src/components/popups/createProposalPopUp.vue'
import updateProposalPopUp from '@src/components/popups/updateProposalPopUp.vue'
import { promoterService } from '../services/promoterService'
import { bus } from '@src/services/eventBus'

export default {
    name: 'myProposalsView',
    components: {
        createProposalPopUp,
        updateProposalPopUp,
    },
    data() {
        return {
            promoter: {},
            numOfSubmittedBachelors: 0,
            numOfSubmittedMasters: 0,
            myProposals: [],
            createProposalParams: {
                show: false,
                maxWidth: 1000
            },
            updateProposalParams: {
                show: false,
                maxWidth: 1000
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
                    width: '10%',
                    algin: 'left',
                    class: 'blue--text text--darken-4 display-1'
                },
                {
                    sortable: false,
                    text: '',
                    value: 'actions',
                    width: '5%',
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
            promoterService.getMyData()
                .then(response => {
                    if(response.status == 200) {
                        this.promoter = response.data;
                    }
                });
            
            this.numOfSubmittedBachelors = 0;
            this.numOfSubmittedMasters = 0;
            proposalService.getMyProposals()
                .then(response => {
                    if(response.status == 200) {
                        this.myProposals = response.data;
                        this.myProposals.forEach(proposal => {
                            proposal.topic = proposal.topicEnglish;
                            proposal.levelText = this.toStudyLevel(proposal.level);
                            if(proposal.levelText == "Bachelor") {
                                this.numOfSubmittedBachelors += 1;
                            }
                            else if(proposal.levelText == "Master") {
                                this.numOfSubmittedMasters += 1;
                            }
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
        deleteMyProposal: function(proposal) {
            proposalService.delete(proposal.id)
                .then(response => {
                    if(response.status == 200) {
                        this.getData();
                    }
                });
        },
        showProposalCreator: function() {
            this.createProposalParams.show = true;
        },
        showProposalUpdater: function(proposal) {
            bus.$emit('showProposalToUpdate', proposal);
            this.updateProposalParams.show = true;
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
.promoterButton {
    font-size: 18px !important;
	color: rgb(255, 255, 255) !important;
	width: 180px !important;
	height: 70px !important;
    float: left;
}
.infoText {
    font-size:24px;
    font-weight: bold;
}
</style>
