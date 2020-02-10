<template>
    <v-container fluid grid-list-xl class="mainView">
        <confirmationPopUp ref="confirm"></confirmationPopUp>
        <reactionPopUp ref="reaction"></reactionPopUp>
        <v-row>
            <v-col cols="9">
                <p class="infoText">{{$i18n.t('promoter.expectedNumberOfBachelorProposals')}}: {{ numOfSubmittedBachelors + "/" + promoter.expectedNumberOfBachelorProposals }}</p>
                <p class="infoText">{{$i18n.t('promoter.expectedNumberOfMasterProposals')}}: {{ numOfSubmittedMasters + "/" + promoter.expectedNumberOfMasterProposals }}</p>
            </v-col>
            <v-col cols="3">
                <v-btn id="createButton"
                       class="promoterButton green"
                       text
                       @click="showProposalCreator">
                    {{$i18n.t('commons.create')}}
                </v-btn>
            </v-col>
        </v-row>
        <v-row justify="center">
            <createProposalPopUp :params="createProposalParams" />
        </v-row>
        <v-row justify="center">
            <updateProposalPopUp :params="updateProposalParams" />
            <v-col cols="12">
                <v-data-table :headers="headers"
                              :items="myProposals"
                              class="whiteBack"
                              id="myproposalstable">
                    <template v-slot:item="{ item }">
                        <tr @click="showProposalUpdater(item)">
                            <td>{{ item.topic }}</td>
                            <td>{{ item.levelText }}</td>
                            <td>{{ item.modeText }}</td>
                            <td>{{ item.stateText }}</td>
                            <td>
                                <v-btn @click.stop="deleteMyProposal(item)">
                                    <v-icon color="rgba(255, 0, 0, 0.9)"
                                            large>
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
import confirmationPopUp from '@src/components/popups/confirmationPopUp.vue'
import reactionPopUp from '@src/components/popups/reactionPopUp.vue'
import { promoterService } from '../services/promoterService'
import { bus } from '@src/services/eventBus'

export default {
    name: 'myProposalsView',
    components: {
        createProposalPopUp,
        updateProposalPopUp,
        confirmationPopUp,
        reactionPopUp
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
                    text: this.$i18n.t('proposal.topic'),
                    value: 'topic',
                    width: '55%',
                    align: 'center',
                    class: 'blue--text text--darken-4 display-1'
                },
                {
                    sortable: true,
                    text: this.$i18n.t('level.level'),
                    value: 'level',
                    width: '15%',
                    align: 'left',
                    class: 'blue--text text--darken-4 display-1'
                },
                {
                    sortable: true,
                    text: this.$i18n.t('mode.mode'),
                    value: 'mode',
                    width: '15%',
                    algin: 'left',
                    class: 'blue--text text--darken-4 display-1'
                },
                {
                    sortable: true,
                    text: this.$i18n.t('status.status'),
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
        bus.$on('proposalWasCreated', this.getData);
        bus.$on('proposalWasUpdated', this.getData);
        this.getData();
    },
    methods: {
        getData: function() {
            this.numOfSubmittedBachelors = 0;
            this.numOfSubmittedMasters = 0;
            promoterService.getMyData()
                .then(response => {
                    if(response.status == 200) {
                        this.promoter = response.data;
                        proposalService.getMyProposals()
                            .then(response => {
                                if(response.status == 200) {
                                    var myProposals = response.data;
                                    this.myProposals = [];
                                    myProposals.forEach(proposal => {
                                        if(this.$i18n.locale == 'pl') {
                                            proposal.topic = proposal.topicPolish;
                                        }
                                        else {
                                            proposal.topic = proposal.topicEnglish;
                                        }
                                        var level = this.toStudyLevel(proposal.level);
                                        proposal.levelText = level.name;
                                        if(level.value == 0) {
                                            this.numOfSubmittedBachelors += 1;
                                        }
                                        else if(level.value == 1) {
                                            this.numOfSubmittedMasters += 1;
                                        }
                                        proposal.modeText = this.toStudyMode(proposal.mode).name;
                                        proposal.stateText = this.toProposalStatusText(proposal);
                                        this.myProposals.push(proposal);
                                    });
                                }
                            });
                    }
                });
        },
        toStudyMode: function(type) {
            switch(type) {
                case 0: {
                    return {
                        value: 0,
                        name: this.$i18n.t('mode.fullTime')
                    };
                }
                case 1: {
                    return {
                        value: 1,
                        name: this.$i18n.t('mode.partTime')
                    };
                }
                default: {
                    return {
                        value: 2,
                        name: '?'
                    };
                }
            }
        },
        toStudyLevel: function(type) {
            switch(type) {
                case 0: {
                    return {
                        value: 0,
                        name: this.$i18n.t('level.bachelorShort')
                    };
                }
                case 1: {
                    return {
                        value: 1,
                        name: this.$i18n.t('level.masterShort')
                    };
                }
                default: {
                    return {
                        value: 2,
                        name: '?'
                    };
                }
            }
        },
        toStudyProfile: function(type) {
            switch(type) {
                case 0: {
                    return {
                        value: 0,
                        name: this.$i18n.t('profile.generalAcademic')
                    };
                }
                default: {
                    return {
                        value: 1,
                        name: '?'
                    };
                }
            }
        },
        toProposalStatus: function(type) {
            switch(type) {
                case 0: {
                    return {
                        value: 0,
                        name: this.$i18n.t('status.taken')
                    };
                }
                case 1: {
                    return {
                        value: 1,
                        name: this.$i18n.t('status.partiallyTaken')
                    };
                }
                case 2: {
                    return {
                        value: 2,
                        name: this.$i18n.t('status.free')
                    };
                }
                default: {
                    return {
                        value: 2,
                        name: '?'
                    };
                }
            }
        },
        toProposalStatusText: function(proposal) {
            return proposal.students.length + " / " + proposal.maxNumberOfStudents;
        },
        deleteMyProposal: function (proposal) {
            this.$refs.confirm.open(this.$i18n.t('commons.delete'), this.$i18n.t('confirm.deleteProposal'), { color: 'error' })
                .then((confirm) => {
                    if (confirm) {
                        proposalService.delete(proposal.id)
                            .then(response => {
                                this.$refs.reaction.open(response.status);
                                if(response.status == 200) {
                                    this.getData();
                                }
                            })
                            .catch(error => {
                                this.$refs.reaction.open(error.response.status);
                            });
                    }
                })
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
