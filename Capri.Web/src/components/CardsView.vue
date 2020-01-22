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
				<v-data-table
					:headers="headers"
					:items="items"
					:search="searchTitle"
					v-model="selected"
					@click:row="showDialog"
					class="table"
				>
					<template v-slot:header.title="{ header }">
						<span class="headerText">{{ header.text }}</span>
						<v-text-field
							v-model="searchTitle"
							label="Filter"
							single-line
							hide-details
							outlined
						></v-text-field>
					</template>

					<template v-slot:header.promoter="{ header }">
						<span class="headerText">{{ header.text }}</span>
						<v-text-field
							v-model="searchPromoter"
							label="Filter"
							single-line
							hide-details
							outlined
						></v-text-field>
					</template>

					<template v-slot:header.freeSlots="{ header }">
						<span class="headerText">{{ header.text }}</span>
						<v-text-field
							v-model="searchFreeSlots"
							label="Filter"
							single-line
							hide-details
							outlined
						></v-text-field>
					</template>

					<template v-slot:item.title="{ item }">
						<span class="itemText">{{ item.title }}</span>
					</template>
					<template v-slot:item.promoter="{ item }">
						<span class="itemText">{{ item.promoter }}</span>
					</template>
					<template v-slot:item.freeSlots="{ item }">
						<span class="itemTextSlot">{{ item.freeSlots }}</span>
					</template>
				</v-data-table>
			</v-col>
		</v-row>
	</v-container>
</template>
<script lang="ts">
import { Vue, Component, Prop } from 'vue-property-decorator';
import popUp from './popUp.vue';

@Component({
    components: {
        popUp,
    },
})
export default class CardsView extends Vue {
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
                    align: 'center',
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
                    freeSlots: 0,
                    maxSlots: 4,
                },
                {
                    title: 'CaPri System',
                    promoter: 'Jerzy Nawrocki',
                    description:
                        'Lorem ipsum dolor sit amet, consectetur tincidunt purus sed lacus tincidunt facilisis. ',
                    thesisType: 'Master',
                    studyType: 'Full time',
                    freeSlots: 1,
                    maxSlots: 4,
                },
                {
                    title: 'CaPri System',
                    promoter: 'Jerzy Nawrocki',
                    description:
                        'Lorem ipsum dolor sit amet, consectetur tincidunt purus sed lacus tincidunt facilisis. ',
                    thesisType: 'Master',
                    studyType: 'Full time',
                    freeSlots: 2,
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
                    maxSlots: 5,
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
                    maxSlots: 3,
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
    public showDialog(value): void {
        this.popUp.data.title.text = value.title;
        this.popUp.data.promoter.text = value.promoter;
        this.popUp.data.studyType.text = value.studyType;
        this.popUp.data.thesisType.text = value.thesisType;
        this.popUp.data.slots.text = value.freeSlots + '/' + value.maxSlots;
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
