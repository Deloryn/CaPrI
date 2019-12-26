<template>
	<v-container fluid grid-list-xl class="mainView">
		<v-row justify="center">
			<v-dialog v-model="dialog" max-width="1000">
				<v-form>
					<v-container class="table">
						<v-row>
							<v-col cols="12">
								<v-text-field
									:value="popup.title"
									label="Thesis title"
									readonly
								></v-text-field>
							</v-col>
						</v-row>
						<v-row>
							<v-col cols="12">
								<v-text-field
									:value="popup.promoter"
									label="Promoter"
									readonly
								></v-text-field>
							</v-col>
						</v-row>

						<v-row>
							<v-col cols="4">
								<v-text-field
									:value="popup.thesisType"
									label="Thesis type"
									readonly
								></v-text-field>
							</v-col>
							<v-col cols="4">
								<v-text-field
									:value="popup.studyType"
									label="Study type"
									readonly
								></v-text-field>
							</v-col>
							<v-col cols="4">
								<v-text-field
									:value="popup.freeSlots + '/' + popup.maxSlots"
									label="State"
									readonly
								></v-text-field>
							</v-col>
						</v-row>

						<v-row>
							<v-col cols="12">
								<v-textarea
									:value="popup.description"
									label="Description"
									readonly
								></v-textarea>
							</v-col>
						</v-row>

						<v-row>
							<v-col cols="12" class="text-center">
								<v-btn
									text
									@click="dialog = false"
									class="closeButton"
								>
									Close
								</v-btn>
							</v-col>
						</v-row>
					</v-container>
				</v-form>
			</v-dialog>

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

@Component
export default class CardsView extends Vue {
    public popup: {
        title: string;
        promoter: string;
        thesisType: string;
        studyType: string;
        freeSlots: string;
        maxSlots: string;
        description: string;
    };
    public dialog: boolean;
    public data() {
        return {
            dialog: false,
            popup: {
                title: '',
                promoter: '',
                thesisType: '',
                studyType: '',
                freeSlots: -1,
                maxSlots: -1,
                description: '',
            },
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
                        'Lorem ipsum dolor sit amet, consectetur adipiscing elit. Fusce nulla lacus, facilisis vel felis id, porta blandit nulla. Quisque congue congue orci elementum tristique. Integer consequat est a nibh mollis aliquam. Integer leo justo, posuere fermentum euismod sit amet, blandit sagittis elit. Suspendisse laoreet massa nec neque tincidunt, in ullamcorper urna sollicitudin. Mauris vitae arcu bibendum, bibendum nisi vitae, aliquet nunc. In tincidunt purus sed lacus tincidunt facilisis. ',
                    thesisType: 'Master',
                    studyType: 'Full time',
                    freeSlots: 3,
                    maxSlots: 4,
                },
                {
                    title: 'CaPri System',
                    promoter: 'Jerzy Nawrocki',
                    description:
                        'Lorem ipsum dolor sit amet, consectetur adipiscing elit. Fusce nulla lacus, facilisis vel felis id, porta blandit nulla. Quisque congue congue orci elementum tristique. Integer consequat est a nibh mollis aliquam. Integer leo justo, posuere fermentum euismod sit amet, blandit sagittis elit. Suspendisse laoreet massa nec neque tincidunt, in ullamcorper urna sollicitudin. Mauris vitae arcu bibendum, bibendum nisi vitae, aliquet nunc. In tincidunt purus sed lacus tincidunt facilisis. ',
                    thesisType: 'Master',
                    studyType: 'Full time',
                    freeSlots: 0,
                    maxSlots: 4,
                },
                {
                    title: 'CaPri System',
                    promoter: 'Jerzy Nawrocki',
                    description:
                        'Lorem ipsum dolor sit amet, consectetur adipiscing elit. Fusce nulla lacus, facilisis vel felis id, porta blandit nulla. Quisque congue congue orci elementum tristique. Integer consequat est a nibh mollis aliquam. Integer leo justo, posuere fermentum euismod sit amet, blandit sagittis elit. Suspendisse laoreet massa nec neque tincidunt, in ullamcorper urna sollicitudin. Mauris vitae arcu bibendum, bibendum nisi vitae, aliquet nunc. In tincidunt purus sed lacus tincidunt facilisis. ',
                    thesisType: 'Master',
                    studyType: 'Full time',
                    freeSlots: 1,
                    maxSlots: 4,
                },
                {
                    title: 'CaPri System',
                    promoter: 'Jerzy Nawrocki',
                    description:
                        'Lorem ipsum dolor sit amet, consectetur adipiscing elit. Fusce nulla lacus, facilisis vel felis id, porta blandit nulla. Quisque congue congue orci elementum tristique. Integer consequat est a nibh mollis aliquam. Integer leo justo, posuere fermentum euismod sit amet, blandit sagittis elit. Suspendisse laoreet massa nec neque tincidunt, in ullamcorper urna sollicitudin. Mauris vitae arcu bibendum, bibendum nisi vitae, aliquet nunc. In tincidunt purus sed lacus tincidunt facilisis. ',
                    thesisType: 'Master',
                    studyType: 'Full time',
                    freeSlots: 2,
                    maxSlots: 4,
                },
                {
                    title: 'CaPri System',
                    promoter: 'Jerzy Nawrocki',
                    description:
                        'Lorem ipsum dolor sit amet, consectetur adipiscing elit. Fusce nulla lacus, facilisis vel felis id, porta blandit nulla. Quisque congue congue orci elementum tristique. Integer consequat est a nibh mollis aliquam. Integer leo justo, posuere fermentum euismod sit amet, blandit sagittis elit. Suspendisse laoreet massa nec neque tincidunt, in ullamcorper urna sollicitudin. Mauris vitae arcu bibendum, bibendum nisi vitae, aliquet nunc. In tincidunt purus sed lacus tincidunt facilisis. ',
                    thesisType: 'Master',
                    studyType: 'Full time',
                    freeSlots: 3,
                    maxSlots: 4,
                },
                {
                    title: 'CaPri System',
                    promoter: 'Jerzy Nawrocki',
                    description:
                        'Lorem ipsum dolor sit amet, consectetur adipiscing elit. Fusce nulla lacus, facilisis vel felis id, porta blandit nulla. Quisque congue congue orci elementum tristique. Integer consequat est a nibh mollis aliquam. Integer leo justo, posuere fermentum euismod sit amet, blandit sagittis elit. Suspendisse laoreet massa nec neque tincidunt, in ullamcorper urna sollicitudin. Mauris vitae arcu bibendum, bibendum nisi vitae, aliquet nunc. In tincidunt purus sed lacus tincidunt facilisis. ',
                    thesisType: 'Master',
                    studyType: 'Full time',
                    freeSlots: 3,
                    maxSlots: 4,
                },
                {
                    title: 'CaPri System',
                    promoter: 'Jerzy Nawrocki',
                    description:
                        'Lorem ipsum dolor sit amet, consectetur adipiscing elit. Fusce nulla lacus, facilisis vel felis id, porta blandit nulla. Quisque congue congue orci elementum tristique. Integer consequat est a nibh mollis aliquam. Integer leo justo, posuere fermentum euismod sit amet, blandit sagittis elit. Suspendisse laoreet massa nec neque tincidunt, in ullamcorper urna sollicitudin. Mauris vitae arcu bibendum, bibendum nisi vitae, aliquet nunc. In tincidunt purus sed lacus tincidunt facilisis. ',
                    thesisType: 'Master',
                    studyType: 'Full time',
                    freeSlots: 3,
                    maxSlots: 4,
                },
                {
                    title: 'CaPri System',
                    promoter: 'Jerzy Nawrocki',
                    description:
                        'Lorem ipsum dolor sit amet, consectetur adipiscing elit. Fusce nulla lacus, facilisis vel felis id, porta blandit nulla. Quisque congue congue orci elementum tristique. Integer consequat est a nibh mollis aliquam. Integer leo justo, posuere fermentum euismod sit amet, blandit sagittis elit. Suspendisse laoreet massa nec neque tincidunt, in ullamcorper urna sollicitudin. Mauris vitae arcu bibendum, bibendum nisi vitae, aliquet nunc. In tincidunt purus sed lacus tincidunt facilisis. ',
                    thesisType: 'Master',
                    studyType: 'Full time',
                    freeSlots: 3,
                    maxSlots: 4,
                },
                {
                    title: 'CaPri System',
                    promoter: 'Jerzy Nawrocki',
                    description:
                        'Lorem ipsum dolor sit amet, consectetur adipiscing elit. Fusce nulla lacus, facilisis vel felis id, porta blandit nulla. Quisque congue congue orci elementum tristique. Integer consequat est a nibh mollis aliquam. Integer leo justo, posuere fermentum euismod sit amet, blandit sagittis elit. Suspendisse laoreet massa nec neque tincidunt, in ullamcorper urna sollicitudin. Mauris vitae arcu bibendum, bibendum nisi vitae, aliquet nunc. In tincidunt purus sed lacus tincidunt facilisis. ',
                    thesisType: 'Master',
                    studyType: 'Full time',
                    freeSlots: 3,
                    maxSlots: 4,
                },
                {
                    title: 'CaPri System',
                    promoter: 'Jerzy Nawrocki',
                    description:
                        'Lorem ipsum dolor sit amet, consectetur adipiscing elit. Fusce nulla lacus, facilisis vel felis id, porta blandit nulla. Quisque congue congue orci elementum tristique. Integer consequat est a nibh mollis aliquam. Integer leo justo, posuere fermentum euismod sit amet, blandit sagittis elit. Suspendisse laoreet massa nec neque tincidunt, in ullamcorper urna sollicitudin. Mauris vitae arcu bibendum, bibendum nisi vitae, aliquet nunc. In tincidunt purus sed lacus tincidunt facilisis. ',
                    thesisType: 'Master',
                    studyType: 'Full time',
                    freeSlots: 3,
                    maxSlots: 4,
                },
                {
                    title: 'CaPri System',
                    promoter: 'Jerzy Nawrocki',
                    description:
                        'Lorem ipsum dolor sit amet, consectetur adipiscing elit. Fusce nulla lacus, facilisis vel felis id, porta blandit nulla. Quisque congue congue orci elementum tristique. Integer consequat est a nibh mollis aliquam. Integer leo justo, posuere fermentum euismod sit amet, blandit sagittis elit. Suspendisse laoreet massa nec neque tincidunt, in ullamcorper urna sollicitudin. Mauris vitae arcu bibendum, bibendum nisi vitae, aliquet nunc. In tincidunt purus sed lacus tincidunt facilisis. ',
                    thesisType: 'Master',
                    studyType: 'Full time',
                    freeSlots: 3,
                    maxSlots: 5,
                },
                {
                    title: 'CaPri System',
                    promoter: 'Jerzy Nawrocki',
                    description:
                        'Lorem ipsum dolor sit amet, consectetur adipiscing elit. Fusce nulla lacus, facilisis vel felis id, porta blandit nulla. Quisque congue congue orci elementum tristique. Integer consequat est a nibh mollis aliquam. Integer leo justo, posuere fermentum euismod sit amet, blandit sagittis elit. Suspendisse laoreet massa nec neque tincidunt, in ullamcorper urna sollicitudin. Mauris vitae arcu bibendum, bibendum nisi vitae, aliquet nunc. In tincidunt purus sed lacus tincidunt facilisis. ',
                    thesisType: 'Master',
                    studyType: 'Full time',
                    freeSlots: 3,
                    maxSlots: 4,
                },
                {
                    title: 'CaPri System',
                    promoter: 'Jerzy Nawrocki',
                    description:
                        'Lorem ipsum dolor sit amet, consectetur adipiscing elit. Fusce nulla lacus, facilisis vel felis id, porta blandit nulla. Quisque congue congue orci elementum tristique. Integer consequat est a nibh mollis aliquam. Integer leo justo, posuere fermentum euismod sit amet, blandit sagittis elit. Suspendisse laoreet massa nec neque tincidunt, in ullamcorper urna sollicitudin. Mauris vitae arcu bibendum, bibendum nisi vitae, aliquet nunc. In tincidunt purus sed lacus tincidunt facilisis. ',
                    thesisType: 'Master',
                    studyType: 'Full time',
                    freeSlots: 3,
                    maxSlots: 4,
                },
                {
                    title: 'CaPri System',
                    promoter: 'Jerzy Nawrocki',
                    description:
                        'Lorem ipsum dolor sit amet, consectetur adipiscing elit. Fusce nulla lacus, facilisis vel felis id, porta blandit nulla. Quisque congue congue orci elementum tristique. Integer consequat est a nibh mollis aliquam. Integer leo justo, posuere fermentum euismod sit amet, blandit sagittis elit. Suspendisse laoreet massa nec neque tincidunt, in ullamcorper urna sollicitudin. Mauris vitae arcu bibendum, bibendum nisi vitae, aliquet nunc. In tincidunt purus sed lacus tincidunt facilisis. ',
                    thesisType: 'Master',
                    studyType: 'Full time',
                    freeSlots: 3,
                    maxSlots: 4,
                },
                {
                    title: 'CaPri System',
                    promoter: 'Jerzy Nawrocki',
                    description:
                        'Lorem ipsum dolor sit amet, consectetur adipiscing elit. Fusce nulla lacus, facilisis vel felis id, porta blandit nulla. Quisque congue congue orci elementum tristique. Integer consequat est a nibh mollis aliquam. Integer leo justo, posuere fermentum euismod sit amet, blandit sagittis elit. Suspendisse laoreet massa nec neque tincidunt, in ullamcorper urna sollicitudin. Mauris vitae arcu bibendum, bibendum nisi vitae, aliquet nunc. In tincidunt purus sed lacus tincidunt facilisis. ',
                    thesisType: 'Master',
                    studyType: 'Full time',
                    freeSlots: 3,
                    maxSlots: 4,
                },
                {
                    title: 'CaPri System',
                    promoter: 'Jerzy Nawrocki',
                    description:
                        'Lorem ipsum dolor sit amet, consectetur adipiscing elit. Fusce nulla lacus, facilisis vel felis id, porta blandit nulla. Quisque congue congue orci elementum tristique. Integer consequat est a nibh mollis aliquam. Integer leo justo, posuere fermentum euismod sit amet, blandit sagittis elit. Suspendisse laoreet massa nec neque tincidunt, in ullamcorper urna sollicitudin. Mauris vitae arcu bibendum, bibendum nisi vitae, aliquet nunc. In tincidunt purus sed lacus tincidunt facilisis. ',
                    thesisType: 'Master',
                    studyType: 'Full time',
                    freeSlots: 3,
                    maxSlots: 4,
                },
                {
                    title: 'CaPri System',
                    promoter: 'Jerzy Nawrocki',
                    description:
                        'Lorem ipsum dolor sit amet, consectetur adipiscing elit. Fusce nulla lacus, facilisis vel felis id, porta blandit nulla. Quisque congue congue orci elementum tristique. Integer consequat est a nibh mollis aliquam. Integer leo justo, posuere fermentum euismod sit amet, blandit sagittis elit. Suspendisse laoreet massa nec neque tincidunt, in ullamcorper urna sollicitudin. Mauris vitae arcu bibendum, bibendum nisi vitae, aliquet nunc. In tincidunt purus sed lacus tincidunt facilisis. ',
                    thesisType: 'Master',
                    studyType: 'Full time',
                    freeSlots: 3,
                    maxSlots: 4,
                },
                {
                    title: 'CaPri System',
                    promoter: 'Jerzy Nawrocki',
                    description:
                        'Lorem ipsum dolor sit amet, consectetur adipiscing elit. Fusce nulla lacus, facilisis vel felis id, porta blandit nulla. Quisque congue congue orci elementum tristique. Integer consequat est a nibh mollis aliquam. Integer leo justo, posuere fermentum euismod sit amet, blandit sagittis elit. Suspendisse laoreet massa nec neque tincidunt, in ullamcorper urna sollicitudin. Mauris vitae arcu bibendum, bibendum nisi vitae, aliquet nunc. In tincidunt purus sed lacus tincidunt facilisis. ',
                    thesisType: 'Master',
                    studyType: 'Full time',
                    freeSlots: 3,
                    maxSlots: 4,
                },
                {
                    title: 'CaPri System',
                    promoter: 'Jerzy Nawrocki',
                    description:
                        'Lorem ipsum dolor sit amet, consectetur adipiscing elit. Fusce nulla lacus, facilisis vel felis id, porta blandit nulla. Quisque congue congue orci elementum tristique. Integer consequat est a nibh mollis aliquam. Integer leo justo, posuere fermentum euismod sit amet, blandit sagittis elit. Suspendisse laoreet massa nec neque tincidunt, in ullamcorper urna sollicitudin. Mauris vitae arcu bibendum, bibendum nisi vitae, aliquet nunc. In tincidunt purus sed lacus tincidunt facilisis. ',
                    thesisType: 'Master',
                    studyType: 'Full time',
                    freeSlots: 3,
                    maxSlots: 4,
                },
                {
                    title: 'CaPri System',
                    promoter: 'Jerzy Nawrocki',
                    description:
                        'Lorem ipsum dolor sit amet, consectetur adipiscing elit. Fusce nulla lacus, facilisis vel felis id, porta blandit nulla. Quisque congue congue orci elementum tristique. Integer consequat est a nibh mollis aliquam. Integer leo justo, posuere fermentum euismod sit amet, blandit sagittis elit. Suspendisse laoreet massa nec neque tincidunt, in ullamcorper urna sollicitudin. Mauris vitae arcu bibendum, bibendum nisi vitae, aliquet nunc. In tincidunt purus sed lacus tincidunt facilisis. ',
                    thesisType: 'Master',
                    studyType: 'Full time',
                    freeSlots: 3,
                    maxSlots: 3,
                },
                {
                    title: 'CaPri System',
                    promoter: 'Jerzy Nawrocki',
                    description:
                        'Lorem ipsum dolor sit amet, consectetur adipiscing elit. Fusce nulla lacus, facilisis vel felis id, porta blandit nulla. Quisque congue congue orci elementum tristique. Integer consequat est a nibh mollis aliquam. Integer leo justo, posuere fermentum euismod sit amet, blandit sagittis elit. Suspendisse laoreet massa nec neque tincidunt, in ullamcorper urna sollicitudin. Mauris vitae arcu bibendum, bibendum nisi vitae, aliquet nunc. In tincidunt purus sed lacus tincidunt facilisis. ',
                    thesisType: 'Master',
                    studyType: 'Full time',
                    freeSlots: 3,
                    maxSlots: 4,
                },
            ],
        };
    }
    public showDialog(value) {
        this.popup.title = value.title;
        this.popup.promoter = value.promoter;
        this.popup.studyType = value.studyType;
        this.popup.thesisType = value.thesisType;
        this.popup.freeSlots = value.freeSlots;
        this.popup.maxSlots = value.maxSlots;
        this.popup.description = value.description;
        this.dialog = true;
    }
}
</script>
<style scoped>
.mainView {
	width: calc(100% - 370px);
	margin-left: 350px;
	margin-right: 10px;
	margin-top: 0px;
	margin-bottom: 140px;
	background-color: #ffffff;
}
.table {
	background-color: #ffffff;
}
.closeButton {
	width: 25%;
	height: 64px;
	font-size: 24px;
	color: #ffffff;
	background-color: #12628d;
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
</style>
