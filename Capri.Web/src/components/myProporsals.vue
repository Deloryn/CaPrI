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
								></v-text-field>
							</v-col>
						</v-row>
						<v-row>
							<v-col cols="6">
								<v-select
									:items="thesisTypes"
									label="Thesis type"
									v-model="popup.thesisType"
								>
								</v-select>
							</v-col>
							<v-col cols="6">
								<v-select
									:items="studyTypes"
									label="Study type"
									v-model="popup.studyType"
								>
								</v-select>
							</v-col>
						</v-row>
						<v-row>
							<v-col
								cols="6"
								v-for="student in popup.students"
								v-bind:key="student.name"
							>
								<v-text-field
									:value="student"
									label="Student"
								></v-text-field>
							</v-col>
							<v-col>
								<span @click="addStudent()">
									<v-icon style="margin-bottom: 6px;"
										>mdi-plus-box</v-icon
									>Add a new student
								</span>
							</v-col>
						</v-row>

						<v-row>
							<v-col cols="12">
								<v-textarea
									:value="popup.description"
									label="Description"
								></v-textarea>
							</v-col>
						</v-row>

						<v-row>
							<v-col cols="12" class="text-center">
								<v-btn
									style="background-color: green;"
									class="buttonStyle mx-12"
									text
									color="#FFFFFF"
									@click="dialog = false"
								>
									Save
								</v-btn>
								<v-btn
									style="background-color: red;"
									class="buttonStyle mx-12"
									text
									color="#FFFFFF"
									@click="dialog = false"
								>
									Cancel
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
					:search="search"
					@click:row="handleClick"
					style="background-color: #FFFFFF;"
				>
					<template v-slot:header.title="{ header }">
						<span style="font-size: 30px; color: rgb(18,98,141)">{{
							header.text
						}}</span>
					</template>

					<template v-slot:header.thesisType="{ header }">
						<span style="font-size: 30px; color: rgb(18,98,141)">{{
							header.text
						}}</span>
					</template>

					<template v-slot:header.studyType="{ header }">
						<span style="font-size: 30px; color: rgb(18,98,141)">{{
							header.text
						}}</span>
					</template>

					<template v-slot:header.freeSlots="{ header }">
						<span style="font-size: 30px; color: rgb(18,98,141)">{{
							header.text
						}}</span>
					</template>

					<template v-slot:item.title="{ item }">
						<span
							style="float: left; font-size: 24px; font-weight: bold;"
							>{{ item.title }}</span
						>
					</template>
					<template v-slot:item.thesisType="{ item }">
						<span
							style="float: left; font-size: 24px; font-weight: bold;"
							>{{ item.thesisType }}</span
						>
					</template>
					<template v-slot:item.studyType="{ item }">
						<span
							style="float: left; font-size: 24px; font-weight: bold;"
							>{{ item.studyType }}</span
						>
					</template>
					<template v-slot:item.freeSlots="{ item }">
						<span
							style="float: left; font-size: 24px; font-weight: bold;"
							>{{ item.maxStudents - item.freeSlots }} /
							{{ item.maxStudents }}
						</span>
					</template>

					<template v-slot:body.append>
						<td @click="handleClick">
							<span style="font-size: 24px; font-weight: bold;"
								><v-icon style="margin-bottom: 6px;"
									>mdi-plus-box</v-icon
								>
								Add a new thesis</span
							>
						</td>
					</template>
				</v-data-table>
			</v-col>
		</v-row>
	</v-container>
</template>
<script lang="ts">
import { Vue, Component, Prop } from 'vue-property-decorator';

@Component
export default class MyProporsals extends Vue {
    public data() {
        return {
            studyTypes: ['Full-time', 'Part-time'],
            thesisTypes: ['Bachelor', 'Master'],
            search: '',
            numberOfThesis: 6,
            dialog: false,
            popup: {
                title: '',
                thesisType: '',
                studyType: '',
                students: [],
                freeSlots: -1,
                description: '',
            },
            headers: [
                {
                    sortable: true,
                    text: 'Title',
                    value: 'title',
                    width: '55%',
                    align: 'center',
                },
                {
                    sortable: true,
                    text: 'Degree',
                    value: 'thesisType',
                    width: '15%',
                    align: 'center',
                },
                {
                    sortable: true,
                    text: 'Type',
                    value: 'studyType',
                    width: '15%',
                    algin: 'center',
                },
                {
                    sortable: true,
                    text: 'State',
                    value: 'freeSlots',
                    width: '15%',
                    algin: 'center',
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
                    students: ['Jan Nowak', 'Jan Kowalski'],
                    maxStudents: 4,
                },
                {
                    title: 'CaPri2 System',
                    promoter: 'Nawrocki Jerzy',
                    description:
                        'Lorem ipsum dolor sit amet, consectetur adipiscing elit. Fusce nulla lacus, facilisis vel felis id, porta blandit nulla. Quisque congue congue orci elementum tristique. Integer consequat est a nibh mollis aliquam. Integer leo justo, posuere fermentum euismod sit amet, blandit sagittis elit. Suspendisse laoreet massa nec neque tincidunt, in ullamcorper urna sollicitudin. Mauris vitae arcu bibendum, bibendum nisi vitae, aliquet nunc. In tincidunt purus sed lacus tincidunt facilisis. ',
                    thesisType: 'Bachelor',
                    studyType: 'Part time',
                    freeSlots: 2,
                    students: ['Jan 2', 'Jan 23'],
                    maxStudents: 4,
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
    public handleClick(value): void {
        this.popup.title = value.title;
        this.popup.promoter = value.promoter;
        this.popup.studyType = value.studyType;
        this.popup.thesisType = value.thesisType;
        this.popup.freeSlots = value.freeSlots;
        this.popup.description = value.description;
        this.popup.students = value.students;
        this.dialog = true;
    }
    public addStudent(): void {
        if (this.popup.students === undefined) {
            this.popup.students = [];
        }
        this.popup.students.push('');
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
.buttonStyle {
     width: 200px;
     height: 50px;
     font-size: 24px;
}
</style>
