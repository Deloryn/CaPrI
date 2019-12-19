<template>
	<v-container fluid grid-list-xl class="mainView">
		<v-row justify="center">
			<v-dialog v-model="dialog" max-width="1000">
				<v-form>
					<v-container style="background-color: #FFFFFF;">
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
									:value="popup.freeSlots"
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
									style="background-color: rgb(18,98,141);"
									text
									color="#FFFFFF"
									@click="dialog = false"
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
					@click:row="handleClick"
					style="background-color: #FFFFFF;"
				>
					<template v-slot:header.title="{ header }">
						<span style="font-size: 30px; color: rgb(18,98,141)">{{
							header.text
						}}</span>
						<v-text-field
							v-model="searchTitle"
							label="Filter"
							single-line
							hide-details
							outlined="true"
							style="border-radius: 0;"
						></v-text-field>
					</template>

					<template v-slot:header.promoter="{ header }">
						<span style="font-size: 30px; color: rgb(18,98,141)">{{
							header.text
						}}</span>
						<v-text-field
							v-model="searchPromoter"
							label="Filter"
							single-line
							hide-details
							outlined="true"
							style="border-radius: 0;"
						></v-text-field>
					</template>

					<template v-slot:header.freeSlots="{ header }">
						<span style="font-size: 30px; color: rgb(18,98,141)">{{
							header.text
						}}</span>
						<v-text-field
							v-model="searchFreeSlots"
							label="Filter"
							single-line
							hide-details
							outlined="true"
							style="border-radius: 0;"
						></v-text-field>
					</template>

					<template v-slot:item.title="{ item }">
						<span
							style="float: left; font-size: 24px; font-weight: bold;"
							>{{ item.title }}</span
						>
					</template>
					<template v-slot:item.promoter="{ item }">
						<span
							style="float: left; font-size: 24px; font-weight: bold;"
							>{{ item.promoter }}</span
						>
					</template>
					<template v-slot:item.freeSlots="{ item }">
						<span
							style="float: left; font-size: 24px; font-weight: bold;"
							>{{ item.freeSlots }}</span
						>
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
    public data() {
        return {
            dialog: false,
            popup: {
                title: '',
                promoter: '',
                thesisType: '',
                studyType: '',
                freeSlots: -1,
                description: '',
            },
            ile: 3,
            selected: 2,
            searchTitle: '',
            searchPromoter: '',
            searchFreeSlots: '',
            headers: [
                {
                    sortable: false,
                    text: 'Title',
                    value: 'title',
                    width: '60%',
                    align: 'center',
                },
                {
                    sortable: false,
                    text: 'Promoter',
                    value: 'promoter',
                    width: '20%',
                    align: 'center',
                },
                {
                    sortable: false,
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
                },
                {
                    title: 'CaPri System',
                    promoter: 'Jerzy Nawrocki',
                    description:
                        'Lorem ipsum dolor sit amet, consectetur adipiscing elit. Fusce nulla lacus, facilisis vel felis id, porta blandit nulla. Quisque congue congue orci elementum tristique. Integer consequat est a nibh mollis aliquam. Integer leo justo, posuere fermentum euismod sit amet, blandit sagittis elit. Suspendisse laoreet massa nec neque tincidunt, in ullamcorper urna sollicitudin. Mauris vitae arcu bibendum, bibendum nisi vitae, aliquet nunc. In tincidunt purus sed lacus tincidunt facilisis. ',
                    thesisType: 'Master',
                    studyType: 'Full time',
                    freeSlots: 0,
                },
                {
                    title: 'CaPri System',
                    promoter: 'Jerzy Nawrocki',
                    description:
                        'Lorem ipsum dolor sit amet, consectetur adipiscing elit. Fusce nulla lacus, facilisis vel felis id, porta blandit nulla. Quisque congue congue orci elementum tristique. Integer consequat est a nibh mollis aliquam. Integer leo justo, posuere fermentum euismod sit amet, blandit sagittis elit. Suspendisse laoreet massa nec neque tincidunt, in ullamcorper urna sollicitudin. Mauris vitae arcu bibendum, bibendum nisi vitae, aliquet nunc. In tincidunt purus sed lacus tincidunt facilisis. ',
                    thesisType: 'Master',
                    studyType: 'Full time',
                    freeSlots: 1,
                },
                {
                    title: 'CaPri System',
                    promoter: 'Jerzy Nawrocki',
                    description:
                        'Lorem ipsum dolor sit amet, consectetur adipiscing elit. Fusce nulla lacus, facilisis vel felis id, porta blandit nulla. Quisque congue congue orci elementum tristique. Integer consequat est a nibh mollis aliquam. Integer leo justo, posuere fermentum euismod sit amet, blandit sagittis elit. Suspendisse laoreet massa nec neque tincidunt, in ullamcorper urna sollicitudin. Mauris vitae arcu bibendum, bibendum nisi vitae, aliquet nunc. In tincidunt purus sed lacus tincidunt facilisis. ',
                    thesisType: 'Master',
                    studyType: 'Full time',
                    freeSlots: 2,
                },
                {
                    title: 'CaPri System',
                    promoter: 'Jerzy Nawrocki',
                    description:
                        'Lorem ipsum dolor sit amet, consectetur adipiscing elit. Fusce nulla lacus, facilisis vel felis id, porta blandit nulla. Quisque congue congue orci elementum tristique. Integer consequat est a nibh mollis aliquam. Integer leo justo, posuere fermentum euismod sit amet, blandit sagittis elit. Suspendisse laoreet massa nec neque tincidunt, in ullamcorper urna sollicitudin. Mauris vitae arcu bibendum, bibendum nisi vitae, aliquet nunc. In tincidunt purus sed lacus tincidunt facilisis. ',
                    thesisType: 'Master',
                    studyType: 'Full time',
                    freeSlots: 3,
                },
                {
                    title: 'CaPri System',
                    promoter: 'Jerzy Nawrocki',
                    description:
                        'Lorem ipsum dolor sit amet, consectetur adipiscing elit. Fusce nulla lacus, facilisis vel felis id, porta blandit nulla. Quisque congue congue orci elementum tristique. Integer consequat est a nibh mollis aliquam. Integer leo justo, posuere fermentum euismod sit amet, blandit sagittis elit. Suspendisse laoreet massa nec neque tincidunt, in ullamcorper urna sollicitudin. Mauris vitae arcu bibendum, bibendum nisi vitae, aliquet nunc. In tincidunt purus sed lacus tincidunt facilisis. ',
                    thesisType: 'Master',
                    studyType: 'Full time',
                    freeSlots: 3,
                },
                {
                    title: 'CaPri System',
                    promoter: 'Jerzy Nawrocki',
                    description:
                        'Lorem ipsum dolor sit amet, consectetur adipiscing elit. Fusce nulla lacus, facilisis vel felis id, porta blandit nulla. Quisque congue congue orci elementum tristique. Integer consequat est a nibh mollis aliquam. Integer leo justo, posuere fermentum euismod sit amet, blandit sagittis elit. Suspendisse laoreet massa nec neque tincidunt, in ullamcorper urna sollicitudin. Mauris vitae arcu bibendum, bibendum nisi vitae, aliquet nunc. In tincidunt purus sed lacus tincidunt facilisis. ',
                    thesisType: 'Master',
                    studyType: 'Full time',
                    freeSlots: 3,
                },
                {
                    title: 'CaPri System',
                    promoter: 'Jerzy Nawrocki',
                    description:
                        'Lorem ipsum dolor sit amet, consectetur adipiscing elit. Fusce nulla lacus, facilisis vel felis id, porta blandit nulla. Quisque congue congue orci elementum tristique. Integer consequat est a nibh mollis aliquam. Integer leo justo, posuere fermentum euismod sit amet, blandit sagittis elit. Suspendisse laoreet massa nec neque tincidunt, in ullamcorper urna sollicitudin. Mauris vitae arcu bibendum, bibendum nisi vitae, aliquet nunc. In tincidunt purus sed lacus tincidunt facilisis. ',
                    thesisType: 'Master',
                    studyType: 'Full time',
                    freeSlots: 3,
                },
                {
                    title: 'CaPri System',
                    promoter: 'Jerzy Nawrocki',
                    description:
                        'Lorem ipsum dolor sit amet, consectetur adipiscing elit. Fusce nulla lacus, facilisis vel felis id, porta blandit nulla. Quisque congue congue orci elementum tristique. Integer consequat est a nibh mollis aliquam. Integer leo justo, posuere fermentum euismod sit amet, blandit sagittis elit. Suspendisse laoreet massa nec neque tincidunt, in ullamcorper urna sollicitudin. Mauris vitae arcu bibendum, bibendum nisi vitae, aliquet nunc. In tincidunt purus sed lacus tincidunt facilisis. ',
                    thesisType: 'Master',
                    studyType: 'Full time',
                    freeSlots: 3,
                },
                {
                    title: 'CaPri System',
                    promoter: 'Jerzy Nawrocki',
                    description:
                        'Lorem ipsum dolor sit amet, consectetur adipiscing elit. Fusce nulla lacus, facilisis vel felis id, porta blandit nulla. Quisque congue congue orci elementum tristique. Integer consequat est a nibh mollis aliquam. Integer leo justo, posuere fermentum euismod sit amet, blandit sagittis elit. Suspendisse laoreet massa nec neque tincidunt, in ullamcorper urna sollicitudin. Mauris vitae arcu bibendum, bibendum nisi vitae, aliquet nunc. In tincidunt purus sed lacus tincidunt facilisis. ',
                    thesisType: 'Master',
                    studyType: 'Full time',
                    freeSlots: 3,
                },
                {
                    title: 'CaPri System',
                    promoter: 'Jerzy Nawrocki',
                    description:
                        'Lorem ipsum dolor sit amet, consectetur adipiscing elit. Fusce nulla lacus, facilisis vel felis id, porta blandit nulla. Quisque congue congue orci elementum tristique. Integer consequat est a nibh mollis aliquam. Integer leo justo, posuere fermentum euismod sit amet, blandit sagittis elit. Suspendisse laoreet massa nec neque tincidunt, in ullamcorper urna sollicitudin. Mauris vitae arcu bibendum, bibendum nisi vitae, aliquet nunc. In tincidunt purus sed lacus tincidunt facilisis. ',
                    thesisType: 'Master',
                    studyType: 'Full time',
                    freeSlots: 3,
                },
                {
                    title: 'CaPri System',
                    promoter: 'Jerzy Nawrocki',
                    description:
                        'Lorem ipsum dolor sit amet, consectetur adipiscing elit. Fusce nulla lacus, facilisis vel felis id, porta blandit nulla. Quisque congue congue orci elementum tristique. Integer consequat est a nibh mollis aliquam. Integer leo justo, posuere fermentum euismod sit amet, blandit sagittis elit. Suspendisse laoreet massa nec neque tincidunt, in ullamcorper urna sollicitudin. Mauris vitae arcu bibendum, bibendum nisi vitae, aliquet nunc. In tincidunt purus sed lacus tincidunt facilisis. ',
                    thesisType: 'Master',
                    studyType: 'Full time',
                    freeSlots: 3,
                },
                {
                    title: 'CaPri System',
                    promoter: 'Jerzy Nawrocki',
                    description:
                        'Lorem ipsum dolor sit amet, consectetur adipiscing elit. Fusce nulla lacus, facilisis vel felis id, porta blandit nulla. Quisque congue congue orci elementum tristique. Integer consequat est a nibh mollis aliquam. Integer leo justo, posuere fermentum euismod sit amet, blandit sagittis elit. Suspendisse laoreet massa nec neque tincidunt, in ullamcorper urna sollicitudin. Mauris vitae arcu bibendum, bibendum nisi vitae, aliquet nunc. In tincidunt purus sed lacus tincidunt facilisis. ',
                    thesisType: 'Master',
                    studyType: 'Full time',
                    freeSlots: 3,
                },
                {
                    title: 'CaPri System',
                    promoter: 'Jerzy Nawrocki',
                    description:
                        'Lorem ipsum dolor sit amet, consectetur adipiscing elit. Fusce nulla lacus, facilisis vel felis id, porta blandit nulla. Quisque congue congue orci elementum tristique. Integer consequat est a nibh mollis aliquam. Integer leo justo, posuere fermentum euismod sit amet, blandit sagittis elit. Suspendisse laoreet massa nec neque tincidunt, in ullamcorper urna sollicitudin. Mauris vitae arcu bibendum, bibendum nisi vitae, aliquet nunc. In tincidunt purus sed lacus tincidunt facilisis. ',
                    thesisType: 'Master',
                    studyType: 'Full time',
                    freeSlots: 3,
                },
                {
                    title: 'CaPri System',
                    promoter: 'Jerzy Nawrocki',
                    description:
                        'Lorem ipsum dolor sit amet, consectetur adipiscing elit. Fusce nulla lacus, facilisis vel felis id, porta blandit nulla. Quisque congue congue orci elementum tristique. Integer consequat est a nibh mollis aliquam. Integer leo justo, posuere fermentum euismod sit amet, blandit sagittis elit. Suspendisse laoreet massa nec neque tincidunt, in ullamcorper urna sollicitudin. Mauris vitae arcu bibendum, bibendum nisi vitae, aliquet nunc. In tincidunt purus sed lacus tincidunt facilisis. ',
                    thesisType: 'Master',
                    studyType: 'Full time',
                    freeSlots: 3,
                },
                {
                    title: 'CaPri System',
                    promoter: 'Jerzy Nawrocki',
                    description:
                        'Lorem ipsum dolor sit amet, consectetur adipiscing elit. Fusce nulla lacus, facilisis vel felis id, porta blandit nulla. Quisque congue congue orci elementum tristique. Integer consequat est a nibh mollis aliquam. Integer leo justo, posuere fermentum euismod sit amet, blandit sagittis elit. Suspendisse laoreet massa nec neque tincidunt, in ullamcorper urna sollicitudin. Mauris vitae arcu bibendum, bibendum nisi vitae, aliquet nunc. In tincidunt purus sed lacus tincidunt facilisis. ',
                    thesisType: 'Master',
                    studyType: 'Full time',
                    freeSlots: 3,
                },
                {
                    title: 'CaPri System',
                    promoter: 'Jerzy Nawrocki',
                    description:
                        'Lorem ipsum dolor sit amet, consectetur adipiscing elit. Fusce nulla lacus, facilisis vel felis id, porta blandit nulla. Quisque congue congue orci elementum tristique. Integer consequat est a nibh mollis aliquam. Integer leo justo, posuere fermentum euismod sit amet, blandit sagittis elit. Suspendisse laoreet massa nec neque tincidunt, in ullamcorper urna sollicitudin. Mauris vitae arcu bibendum, bibendum nisi vitae, aliquet nunc. In tincidunt purus sed lacus tincidunt facilisis. ',
                    thesisType: 'Master',
                    studyType: 'Full time',
                    freeSlots: 3,
                },
                {
                    title: 'CaPri System',
                    promoter: 'Jerzy Nawrocki',
                    description:
                        'Lorem ipsum dolor sit amet, consectetur adipiscing elit. Fusce nulla lacus, facilisis vel felis id, porta blandit nulla. Quisque congue congue orci elementum tristique. Integer consequat est a nibh mollis aliquam. Integer leo justo, posuere fermentum euismod sit amet, blandit sagittis elit. Suspendisse laoreet massa nec neque tincidunt, in ullamcorper urna sollicitudin. Mauris vitae arcu bibendum, bibendum nisi vitae, aliquet nunc. In tincidunt purus sed lacus tincidunt facilisis. ',
                    thesisType: 'Master',
                    studyType: 'Full time',
                    freeSlots: 3,
                },
                {
                    title: 'CaPri System',
                    promoter: 'Jerzy Nawrocki',
                    description:
                        'Lorem ipsum dolor sit amet, consectetur adipiscing elit. Fusce nulla lacus, facilisis vel felis id, porta blandit nulla. Quisque congue congue orci elementum tristique. Integer consequat est a nibh mollis aliquam. Integer leo justo, posuere fermentum euismod sit amet, blandit sagittis elit. Suspendisse laoreet massa nec neque tincidunt, in ullamcorper urna sollicitudin. Mauris vitae arcu bibendum, bibendum nisi vitae, aliquet nunc. In tincidunt purus sed lacus tincidunt facilisis. ',
                    thesisType: 'Master',
                    studyType: 'Full time',
                    freeSlots: 3,
                },
                {
                    title: 'CaPri System',
                    promoter: 'Jerzy Nawrocki',
                    description:
                        'Lorem ipsum dolor sit amet, consectetur adipiscing elit. Fusce nulla lacus, facilisis vel felis id, porta blandit nulla. Quisque congue congue orci elementum tristique. Integer consequat est a nibh mollis aliquam. Integer leo justo, posuere fermentum euismod sit amet, blandit sagittis elit. Suspendisse laoreet massa nec neque tincidunt, in ullamcorper urna sollicitudin. Mauris vitae arcu bibendum, bibendum nisi vitae, aliquet nunc. In tincidunt purus sed lacus tincidunt facilisis. ',
                    thesisType: 'Master',
                    studyType: 'Full time',
                    freeSlots: 3,
                },
                {
                    title: 'CaPri System',
                    promoter: 'Jerzy Nawrocki',
                    description:
                        'Lorem ipsum dolor sit amet, consectetur adipiscing elit. Fusce nulla lacus, facilisis vel felis id, porta blandit nulla. Quisque congue congue orci elementum tristique. Integer consequat est a nibh mollis aliquam. Integer leo justo, posuere fermentum euismod sit amet, blandit sagittis elit. Suspendisse laoreet massa nec neque tincidunt, in ullamcorper urna sollicitudin. Mauris vitae arcu bibendum, bibendum nisi vitae, aliquet nunc. In tincidunt purus sed lacus tincidunt facilisis. ',
                    thesisType: 'Master',
                    studyType: 'Full time',
                    freeSlots: 3,
                },
            ],
        };
    }
    public chechAvailability(freeSlots): string {
        if (freeSlots === 0) { return 'unavailable'; }
        return 'available';
    }
    public handleClick(value) {
        (<any>this).popup.title = value.title;
        (<any>this).popup.promoter = value.promoter;
        (<any>this).popup.studyType = value.studyType;
        (<any>this).popup.thesisType = value.thesisType;
        (<any>this).popup.freeSlots = value.freeSlots;
        (<any>this).popup.description = value.description;
        (<any>this).dialog = true;
    }
}
</script>
<style scoped>
.mainView {
	width: calc(100% - 370px);
	margin-left: 350px;
	margin-right: 10px;
	margin-top: 0px;
	margin-bottom: 0px;
	background-color: #ffffff;
}

.paintData {
	width: 100%;
	height: 100%;
	border-radius: 0;
}
</style>
