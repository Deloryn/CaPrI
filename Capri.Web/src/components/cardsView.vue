<template>
	<v-container fluid grid-list-xl class="mainView">
		<v-row justify="center">
			<popUp :thesisData="popUp">
				<template v-slot:after>
					<v-col cols="12" class="text-center">
						<v-btn
							color="#12628d"
							class="thesisDetailCloseButton"
							@click="popUp.show = false"
							>Close</v-btn
						>
					</v-col>
				</template>
			</popUp>

            <v-col cols="12">
                <v-data-table :headers="headers"
                              :items="thesisList"
                              :search="searchTitle"
                              v-model="selected"
                              @click:row="showDialog"
                              class="table">
                    <template v-slot:header.title="{ header }">
                        <span class="headerText">{{ header.text }}</span>
                        <v-text-field v-model="searchTitle"
                                      label="Filter"
                                      single-line
                                      hide-details
                                      outlined></v-text-field>
                    </template>

                    <template v-slot:header.promoter="{ header }">
                        <span class="headerText">{{ header.text }}</span>
                        <v-text-field v-model="searchPromoter"
                                      label="Filter"
                                      single-line
                                      hide-details
                                      outlined></v-text-field>
                    </template>

                    <template v-slot:header.freeSlots="{ header }">
                        <span class="headerText">{{ header.text }}</span>
                        <v-text-field v-model="searchFreeSlots"
                                      label="Filter"
                                      single-line
                                      hide-details
                                      outlined></v-text-field>
                    </template>

                    <template v-slot:item.title="{ item }">
                        <span class="itemText">{{ item.topicEnglish }}</span>
                    </template>
                    <template v-slot:item.promoter="{ item }">
                        <span class="itemText">{{ getPromoterFullName(item.promoterId) }}</span>
                    </template>
                    <template v-slot:item.freeSlots="{ item }">
                        <span class="itemTextSlot">{{ item.status }}/{{ item.maxNumberOfStudents }}</span>
                    </template>
                </v-data-table>
            </v-col>
		</v-row>
	</v-container>
</template>
<script lang="ts">
import { Vue, Component, Prop } from 'vue-property-decorator';
import popUp from './popUp.vue';
import { bus } from '../app';
import { promoterService } from '@src/services/promoterService'
import { proposalService } from '@src/services/proposalService'
import { courseService } from '@src/services/courseService'

@Component({
    components: {
        popUp,
    },
})
export default class ProposalView extends Vue {
    public popUp = {
        show: false,
        maxWidth: 1000,
        data: {
            titlePolish: { 
                text: '', 
                label: 'Title Polish', 
                type: 'textField', 
                columns: 12 },
            titleEnglish: { 
                text: '', 
                label: 'Title English', 
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
    };
    public getData() {
        proposalService.getAll().then((response) => {
            this.thesisList = response.data
        })
        promoterService.getAll().then((response) => {
            this.promoters = response.data
        })
    };

    public dane = this.getData();
    public thesisList = [{
        "id":"",
        "topicPolish":"",
        "topicEnglish":"",
        "description":"",
        "outputData":"",
        "specialization":"",
        "maxNumberOfStudents":0,
        "startingDate":"",
        "status":0,
        "level":0,
        "mode":0,
        "studyProfile":0,
        "promoterId":"",
        "courseId":"",
        "students":[]}];
        
    public promoters = [{"id":"","titlePrefix":"","titlePostfix":"","firstName":"Loading data…","lastName":"","expectedNumberOfBachelorProposals":0,"expectedNumberOfMasterProposals":0,"proposal":[""],"userId":"","instituteId":""}];
    public data() {
        return {
            selected: [],
            searchTitle: '',
            searchPromoter: '',
            searchFreeSlots: '',
            headers: [
                {
                    sortable: true,
                    text: 'Title',
                    proposal: 'title',
                    width: '60%',
                    align: 'left',
                },
                {
                    sortable: true,
                    text: 'Promoter',
                    proposal: 'promoter',
                    width: '20%',
                    align: 'center',
                },
                {
                    sortable: true,
                    text: 'Free numOfAvailableSlots',
                    proposal: 'freeSlots',
                    align: 'center',
                },
            ],
            items: [],
        };
    }
    public toStudyType(type) {
        if (type) {
            return "Part-time"
        }
        return "Full-time"
    }
    public toThesisType(type) {
        if (type) {
            return "Master"
        }
        return "Bachelor"
    }
    public showDialog(proposal): void {
        this.popUp.data.titleEnglish.text = proposal.topicEnglish;
        this.popUp.data.titlePolish.text = proposal.topicPolish;
        this.popUp.data.mode.text = this.toStudyType(proposal.level);
        this.popUp.data.level.text = this.toThesisType(proposal.mode);
        this.popUp.data.numOfAvailableSlots.text = proposal.status + '/' + proposal.maxNumberOfStudents;
        this.popUp.data.description.text = proposal.description;
        promoterService.get(proposal.promoterId)
        .then((response) => {
            if(response.status == 200) {
                var promoter = response.data;
                var fullName = promoter.titlePrefix + " " +
                                promoter.firstName + " " +
                                promoter.lastName;
                if(promoter.titlePostfix)
                {
                    fullName += ", "
                    fullName += promoter.titlePostfix
                }
                this.popUp.data.promoter.text = fullName;
            }
        })
        courseService.get(proposal.courseId)
        .then((response) => {
            if(response.status == 200) {
                var course = response.data;
                this.popUp.data.course.text = course.name;
            }
        })
        this.popUp.show = true;
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
.headerText {
	color: #12628d;
	font-size: 30px;
}
.itemText {
	float: left;
	font-size: 24px;
	font-weight: bold;
}
.itemTextSlot {
	font-size: 24px;
	font-weight: bold;
}
.thesisDetailCloseButton {
	width: 33%;
	color: #ffffff;
	font-size: 24px;
}
</style>
