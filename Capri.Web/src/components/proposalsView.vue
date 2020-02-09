<template v-key="lang">
	<v-container fluid grid-list-xl class="mainView">
        <v-row>
			<v-col cols="2" offset="10">
				<v-select
					v-model="itemsPerPage"
					:items="itemsPerPageOptions"
					:label="$i18n.t('commons.itemsPerPage')"
				/>
			</v-col>
		</v-row>
		<v-row justify="center">
			<displayProposalDetailsPopUp :params="displayDetailsPopUpParams" />
            <v-col cols="12">
                <v-data-table 
                    :headers="headers"
                    :items="proposals"
                    :items-per-page="itemsPerPage"
					:page.sync="page"
					hide-default-footer
                    id="proposalstable"
                    class="table"
                >
                    <template slot="no-data">
                        {{ $i18n.t('commons.dataLoading') }}
                    </template>
                    <template v-slot:item="{ item }">
                        <tr @click="showDetails(item.id)">
                        <td>{{ item.topic }}</td>
                        <td>{{ item.promoter }}</td>
                        <td>{{ item.freeSlots }}</td>
                        <td v-if="role == 'Dean'">
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
import { bus } from '@src/services/eventBus'
import { promoterService } from '@src/services/promoterService'
import { proposalService } from '@src/services/proposalService'
import { facultyService } from '@src/services/facultyService'
import { courseService } from '@src/services/courseService'
import { sessionService } from '@src/services/sessionService'
import displayProposalDetailsPopUp from '@src/components/popups/displayProposalDetailsPopUp.vue'

export default {
    name: 'proposalsView',
    components: {
        displayProposalDetailsPopUp
    },
    watch: {
        lang: function(val) {
            this.lang = val;
        },
        page: function(newpage) {
			this.getFilteredProposals();
		},
		itemsPerPage: function(newItemsPerPage) {
			this.getFilteredProposals();
		}
    },
    data() {
        return {
            role: "",
            page: 1,
            howManyPagesInTotal: 10,
            itemsPerPage: 10,
            itemsPerPageOptions: [
                5,
                10,
                15
            ],
            totalVisible: 8,
            faculty: null,
            course: null,
            level: null,
            mode: null,
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
        bus.$on('proposalsFiltersWereChosen', this.onFiltersChange);
        bus.$on('proposalWasCreated', this.getFilteredProposals);
        this.role = sessionService.getParsedToken()["role"];
        this.getFilteredProposals();
    },
    methods: {
        onFiltersChange: function(filters) {
            this.page = 1;
            this.faculty = filters.faculty;
            this.course = filters.course;
            this.level = filters.level;
            this.mode = filters.mode;
            this.getFilteredProposals();
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
        getFilteredProposals: function() {
            this.proposals = [];
            var page = this.page;
            var pageSize = this.itemsPerPage;
            var sorts = "";
            if(this.$i18n.locale == 'pl') {
                sorts="topicpolish";
            }
            else {
                sorts = "topicenglish";
            }
            var filters = "";
            if(this.level != null) {
                filters += "level==" + this.level + ",";
            }
            if(this.mode != null) {
                filters += "mode==" + this.mode + ",";
            }
            if(this.course && this.course.id) {
                filters += "course_id==" + this.course.id + ",";
            }
            if(this.faculty && this.faculty.id) {
                filters += "faculty_id==" + this.faculty.id + ",";
            }

            proposalService.count(sorts, filters)
                .then(response => {
                    if(response.status == 200) {
                        var total = response.data;
                        this.howManyPagesInTotal = Math.ceil(total/this.itemsPerPage);
                        proposalService.getFiltered(sorts, filters, page, pageSize)
                            .then(response => {
                                if(response.status == 200) {
                                    var proposals = response.data;
                                    proposals.forEach(proposal => {
                                        promoterService.get(proposal.promoterId)
                                            .then((response) => {
                                                let promoterFullName = "";
                                                if(response.status == 200) {
                                                    var promoter = response.data;
                                                    promoterFullName = promoter.lastName + " " + promoter.firstName;
                                                }
                                                proposal.promoter = promoterFullName;
                                                if(this.$root.$i18n.locale == 'pl') {
                                                    proposal.topic = proposal.topicPolish;
                                                }
                                                else {
                                                    proposal.topic = proposal.topicEnglish;
                                                }
                                                proposal.freeSlots = proposal.maxNumberOfStudents - proposal.students.length;
                                                this.proposals.push(proposal);
                                            });
                                    });
                                }
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
