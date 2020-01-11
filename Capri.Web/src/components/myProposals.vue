<template>
	<v-container fluid grid-list-xl class="mainView">
		<v-row justify="center">
			<popup :thesisData="popup">
				<template v-slot:after>
					<v-col cols="6" class="text-center">
						<v-btn
							id="saveButton"
							class="formDiv mx-12 green"
							text
							@click="popup.show = false"
						>
							Save
						</v-btn>
					</v-col>
					<v-col cols="6" class="text-center">
						<v-btn
							id="cancelButton"
							class="formDiv mx-12 red"
							text
							@click="popup.show = false"
						>
							Cancel
						</v-btn>
					</v-col>
				</template>
			</popup>

			<v-col cols="12">
				<v-data-table
					:headers="headers"
					:items="items"
					:search="search"
					@click:row="showPopup"
					class="whiteBack"
				>
					<template v-slot:header.title="{ header }">
						<span class="headerText">
							{{ header.text }}
						</span>
					</template>

					<template v-slot:header.thesisType="{ header }">
						<span class="headerText">
							{{ header.text }}
						</span>
					</template>

					<template v-slot:header.studyType="{ header }">
						<span class="headerText">
							{{ header.text }}
						</span>
					</template>

					<template v-slot:header.freeSlots="{ header }">
						<span class="headerText">
							{{ header.text }}
						</span>
					</template>

					<template v-slot:item.title="{ item }">
						<span class="itemText">{{ item.title }}</span>
					</template>
					<template v-slot:item.thesisType="{ item }">
						<span class="itemText">{{ item.thesisType }}</span>
					</template>
					<template v-slot:item.studyType="{ item }">
						<span class="itemText">{{ item.studyType }}</span>
					</template>
					<template v-slot:item.freeSlots="{ item }">
						<span class="itemText">
							{{ item.maxStudents - item.freeSlots }} /
							{{ item.maxStudents }}
						</span>
					</template>

					<template v-slot:body.append>
						<td @click="showEmptyPopup">
							<span class="addItem">
								<v-icon class="marginBottomSix"
									>mdi-plus-box</v-icon
								>
								Add a new thesis
							</span>
						</td>
					</template>
				</v-data-table>
			</v-col>
		</v-row>
	</v-container>
</template>
<script lang="ts">
import { Vue, Component, Prop } from 'vue-property-decorator';
import popup from './popup.vue';

@Component({
    components: {
        popup,
    },
})
export default class MyProporsals extends Vue {
    public popup = {
        show: false,
        maxWidth: 1000,
        data: {
            title: {
                text: '',
                label: 'Thesis title',
                type: 'editableTextField',
                columns: 12,
            },
            thesisType: {
                text: '',
                label: 'Thesis type',
                items: ['Bachelor', 'Master'],
                chosen: '',
                type: 'selectableField',
                columns: 6,
            },
            studyType: {
                text: '',
                label: 'Study type',
                items: ['Full-time', 'Part-time'],
                chosen: '',
                type: 'selectableField',
                columns: 6,
            },
            students: {
                text: '',
                label: 'Student',
                type: 'studentField',
                columns: 12,
                students: ['', ''],
                max: 4,
            },
            description: {
                text: '',
                label: 'Description',
                type: 'editableTextAreaField',
                columns: 12,
            },
        },
    };
    public data() {
        return {
            studyTypes: ['Full-time', 'Part-time'],
            thesisTypes: ['Bachelor', 'Master'],
            search: '',
            numberOfThesis: 6,
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
                    students: ['Jan Nowak', 'Jan Kowalski'],
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
                    students: ['Jan Nowak', 'Jan Kowalski'],
                    maxStudents: 4,
                },
            ],
        };
    }
    public showPopup(value): void {
        this.popup.data.title.text = value.title;
        this.popup.data.studyType.text = value.studyType;
        this.popup.data.thesisType.text = value.thesisType;
        this.popup.data.description.text = value.description;
        this.popup.data.students.students = value.students;
        this.popup.data.thesisType.chosen = value.thesisType;
        this.popup.data.students.max = value.maxStudents;
        this.popup.show = true;
    }
    public showEmptyPopup(): void {
        this.popup.data.title.text = '';
        this.popup.data.studyType.text = '';
        this.popup.data.thesisType.text = '';
        this.popup.data.description.text = '';
        this.popup.data.students.students = ['', ''];
        this.popup.data.thesisType.chosen = '';
        this.popup.data.students.max = 4;
        this.popup.show = true;
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
.formDiv {
	color: rgb(255, 255, 255);
	width: 150px;
	height: 50px;
	font-size: 24px;
}
</style>
