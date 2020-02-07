<template v-key="lang">
	<v-container fluid grid-list-xl class="mainView">
		<v-row justify="center">
			<displayProposalDetailsPopUp :params="displayDetailsPopUpParams" />
            <v-col cols="12">
                <v-data-table 
                    :headers="headers"
                    :items="proposals"
                    id="proposalstable"
                    class="table"
                >
                    <template v-slot:item="{ item }">
                        <tr @click="showDetails(item.id)">
                        <td>{{ item.topic }}</td>
                        <td>{{ item.promoter }}</td>
                        <td>{{ item.freeSlots }}</td>
                        <td>
                            <v-btn @click.stop="generateDiplomaCard(item.id)">
                                <v-icon large color="blue darken-2">
                                    assignment
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
import { bus } from '@src/services/eventBus'
import { promoterService } from '@src/services/promoterService'
import { proposalService } from '@src/services/proposalService'
import { facultyService } from '@src/services/facultyService'
import { courseService } from '@src/services/courseService'
import displayProposalDetailsPopUp from '@src/components/popups/displayProposalDetailsPopUp.vue'

export default {
    name: 'proposalsView',
    components: {
        displayProposalDetailsPopUp
    },
    watch: {
        lang: function(val) {
            console.log("watcher");
            this.lang = val;
            console.log("lang: " + this.lang);
        }
    },
    data() {
        return {
            proposals: [],
            displayDetailsPopUpParams: {
                show: false,
                maxWidth: 1000
            },
            headers: [
                {
                    sortable: true,
                    text: this.$i18n.t('proposal.topic'),
                    value: 'topic',
                    width: '60%',
                    align: 'left',
                    class: 'blue--text text--darken-4 display-1'
                },
                {
                    sortable: true,
                    text: this.$i18n.t('promoter.promoter'),
                    value: 'promoter',
                    width: '30%',
                    align: 'left',
                    class: 'blue--text text--darken-4 display-1'
                },
                {
                    sortable: true,
                    text: this.$i18n.t('proposal.freeSlots'),
                    value: 'freeSlots',
                    width: '10%',
                    align: 'left',
                    class: 'blue--text text--darken-4 display-1'
                },
            ],
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
                var proposals = response.data;
                this.proposals = [];
                proposals.forEach(proposal => {
                    promoterService.get(proposal.promoterId)
                    .then((response) => {
                        let promoterFullName = "";
                        if(response.status == 200) {
                            var promoter = response.data;
                            promoterFullName = promoter.lastName + " " + promoter.firstName;
                        }
                        proposal.promoter = promoterFullName;
                        if(this.$i18n.locale == 'pl') {
                            proposal.topic = proposal.topicPolish;
                        }
                        else {
                            proposal.topic = proposal.topicEnglish;
                        }
                        proposal.freeSlots = proposal.maxNumberOfStudents - proposal.students.length;
                        this.proposals.push(proposal);
                    });
                });
            });            
        },
        showDetails: function(proposalId) {
            bus.$emit('displayProposal', proposalId);
			this.displayDetailsPopUpParams.show = true;
        },
        generateDiplomaCard: function(proposalId) {
            proposalService.getDiplomaCard(proposalId)
                .then(response => {
                    let filename = response.headers['content-disposition'];
                    filename = filename.slice(filename.indexOf('filename=')+9, 
                        filename.indexOf('.docx', filename.indexOf('filename='))+5);
                    if (!filename.endsWith('.docx')) filename += '.docx';

                    const url = window.URL.createObjectURL(new Blob([response.data], 
                        {type: response.headers['content-type']}));
                    const link = document.createElement('a');
                    link.href = url;
                    link.setAttribute('download', filename);
                    document.body.appendChild(link);
                    link.click();
                })
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
