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
                        <span class="itemText">{{ findPromoter(item.promoterId) }}</span>
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

@Component({
    components: {
        popUp,
    },
})
export default class CardsView extends Vue {
    public napis = "czesc";
    public popUp = {
        show: false,
        maxWidth: 1000,
        data: {
            title: { text: '', label: 'Title', type: 'textField', columns: 12 },
            promoter: {
                text: '',
                label: 'Promoter',
                type: 'textField',
                columns: 12,
            },
            thesisType: {
                text: '',
                label: 'Thesis type',
                type: 'textField',
                columns: 4,
            },
            studyType: {
                text: '',
                label: 'Study type',
                type: 'textField',
                columns: 4,
            },
            slots: { text: '', label: 'State', type: 'textField', columns: 4 },
            description: {
                text: '',
                label: 'Description',
                type: 'textAreaField',
                columns: 12,
            },
        },
    };
    public getData() {
        Vue.axios.get('http://40.87.155.231/proposals').then((response) => {
            this.thesisList = response.data
        })
        Vue.axios.get('http://40.87.155.231/promoters').then((response) => {
            this.promoters = response.data
        })
    };
    //public getData2() {
    //    alert("dziala")
    //    Vue.axios.get('http://40.87.155.231//proposals/filtered?filters=level==1').then((response) => {
    //        this.thesisList = response.data;
    //    })
    //};
    public findPromoter(promoterId: string): string {
        let indexOfPromoter = -1;
        this.promoters.find((o, i) => {
            if (o.id === promoterId) {
                indexOfPromoter = i;
            }
        });
        if (indexOfPromoter !== -1) {
            let prefixPostfix = "";
            if (this.promoters[indexOfPromoter].titlePostfix) {
                prefixPostfix = ", "
            }
            return this.promoters[indexOfPromoter].titlePrefix + " " +
                this.promoters[indexOfPromoter].firstName + " " +
                this.promoters[indexOfPromoter].lastName + prefixPostfix +
                this.promoters[indexOfPromoter].titlePostfix
        }
        return promoterId;
    }
    public dane = this.getData();
    public thesisList = [{"id":"","topicPolish":"","topicEnglish":"Loading data…","description":"","outputData":"","specialization":"","maxNumberOfStudents":4,"startingDate":"","status":0,"level":0,"mode":0,"studyProfile":0,"promoterId":"","courseId":"","students":[]}];
    public promoters = [{"id":"","titlePrefix":"","titlePostfix":"","firstName":"Loading data…","lastName":"","expectedNumberOfBachelorProposals":0,"expectedNumberOfMasterProposals":0,"proposals":[""],"userId":"","instituteId":""}];
    //public odSomsiada = bus.$on('someEvent', (interesting_data) => {
    //    console.log(interesting_data)
    //    this.napis = interesting_data;
    //    Vue.axios.get('http://40.87.155.231//proposals/filtered?filters=level==1').then((response) => {
    //        this.thesisList = response.data;
    //    })
    //});
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
                    value: 'title',
                    width: '60%',
                    align: 'left',
                },
                {
                    sortable: true,
                    text: 'Promoter',
                    value: 'promoter',
                    width: '20%',
                    align: 'center',
                },
                {
                    sortable: true,
                    text: 'Free slots',
                    value: 'freeSlots',
                    align: 'center',
                },
            ],
            items: [
                {
                    title: 'CaPri System',
                    promoter: 'Jerzy Nawrocki',
                    description:
                        'Lorem ipsum dolor sit amet, consectetur tincidunt purus sed lacus tincidunt facilisis. ',
                    thesisType: 'Master',
                    studyType: 'Full time',
                    freeSlots: 3,
                    maxSlots: 4,
                },
                {
                    title: 'CaPri System',
                    promoter: 'Jerzy Nawrocki',
                    description:
                        'Lorem ipsum dolor sit amet, consectetur tincidunt purus sed lacus tincidunt facilisis. ',
                    thesisType: 'Master',
                    studyType: 'Full time',
                    freeSlots: 3,
                    maxSlots: 4,
                },
            ],
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
    public showDialog(value): void {
        this.popUp.data.title.text = value.topicEnglish;
        this.popUp.data.promoter.text = this.findPromoter(value.promoterId);
        this.popUp.data.studyType.text = this.toStudyType(value.level);
        this.popUp.data.thesisType.text = this.toThesisType(value.mode);
        this.popUp.data.slots.text = value.status + '/' + value.maxNumberOfStudents;
        this.popUp.data.description.text = value.description;
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
