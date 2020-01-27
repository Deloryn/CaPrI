<template>
    <v-dialog
		v-model="params.show"
		:max-width="params.maxWidth"
	>
		<v-form class="whiteBackground" ref="createProposalForm" v-model="isFormValid">
			<v-container class="table">
				<v-row>
					<v-col :cols="8">
						<v-select
							:items="faculties"
							:rules="selectRules"
							:label="'Faculty*'"
							v-model="chosenFaculty"
							@change="onChangeFaculty"
							return-object
							color="rgb(18,98,141)"
						>
							<template slot="selection" slot-scope="data">
								{{ data.item.name }}
							</template>
							<template slot="item" slot-scope="data">
								{{ data.item.name }}
							</template>
						</v-select>
					</v-col>
					<v-col :cols="4">
						<v-select
							:items="courses"
							:rules="selectRules"
							:label="'Field of study*'"
							:disabled="selectCoursesDisabled"
							v-model="chosenCourse"
							return-object
							color="rgb(18,98,141)"
						>
							<template slot="selection" slot-scope="data">
								{{ data.item.name }}
							</template>
							<template slot="item" slot-scope="data">
								{{ data.item.name }}
							</template>
						</v-select>
					</v-col>
				</v-row>
				<v-row>
					<v-col :cols="4">
						<v-select
							:items="levels"
							:rules="selectRules"
							:label="'Study level*'"
							v-model="chosenLevel"
							return-object
							color="rgb(18,98,141)"
						>
							<template slot="selection" slot-scope="data">
								{{ data.item.name }}
							</template>
							<template slot="item" slot-scope="data">
								{{ data.item.name }}
							</template>
						</v-select>
					</v-col>
					<v-col :cols="4">
						<v-select
							:items="modes"
							:rules="selectRules"
							:label="'Study mode*'"
							v-model="chosenMode"
							return-object
							color="rgb(18,98,141)"
						>
							<template slot="selection" slot-scope="data">
								{{ data.item.name }}
							</template>
							<template slot="item" slot-scope="data">
								{{ data.item.name }}
							</template>
						</v-select>
					</v-col>
					<v-col :cols="4">
						<v-select
							:items="profiles"
							:rules="selectRules"
							:label="'Study profile*'"
							v-model="chosenProfile"
							return-object
							color="rgb(18,98,141)"
						>
							<template slot="selection" slot-scope="data">
								{{ data.item.name }}
							</template>
							<template slot="item" slot-scope="data">
								{{ data.item.name }}
							</template>
						</v-select>
					</v-col>
				</v-row>
				<v-row>
					<v-col>
						<v-text-field 
							:label="'Polish title*'" 
							:rules="topicRules" 
							v-model="topicPolish"
						/>
					</v-col>
				</v-row>
				<v-row>
					<v-col>
						<v-text-field 
							:label="'English title*'" 
							:rules="topicRules" 
							v-model="topicEnglish"
						/>
					</v-col>
				</v-row>
				<v-row>
					<v-col>
						<v-textarea 
							:value="'Write a description here'" 
							:rules="descriptionRules" 
							:label="'Description*'" 
							v-model="description"
						/>
					</v-col>
				</v-row>
				<v-row>
					<v-col>
						<v-text-field 
							type="number"
							single-line
							:rules="maxNumberOfStudentsRules"
							:label="'Maximal number of students*'" 
							v-model="chosenMaximalNumberOfStudents"
							@change="onChangeMaximalNumberOfStudents"
						/>
					</v-col>
				</v-row>
				<v-row>
					<v-col>
						<v-textarea 
							:rules="outputDataRules"
							:label="'Output data (optional)'" 
							v-model="outputData"
						/>
					</v-col>
				</v-row>
				<v-row>
					<v-col>
						<v-textarea 
							:rules="specializationRules"
							:label="'Specialization (optional)'" 
							v-model="specialization"
						/>
					</v-col>
				</v-row>
				<v-row>
					<v-col>
						<v-list v-show="!hideStudentList">
							<v-subheader>
								Students (optional)
							</v-subheader>
							<v-list-item v-for="indexNumber in indexNumbers" :key="indexNumber">
								<v-list-item-title>
									<v-icon 
										@click.stop="deleteIndexNumFromList(indexNumber)" 
										color="rgba(255, 0, 0, 0.9)" 
										large
									>
										delete
									</v-icon>
									{{ indexNumber }}
								</v-list-item-title>
							</v-list-item>
							<v-list-item>
								<v-list-item-title>
									<v-tooltip top>
										<template v-slot:activator="{ on }">
											<v-text-field
											@keyup.enter.stop="addStudent"
											@click:prepend.stop="addStudent"
											ref="studentIndexNumberInput"
											type="number"
											single-line
											prepend-icon="group_add"
											:rules="studentRules"
											:label="'Student ID'" 
											v-model="chosenIndexNumber"
											v-on="on"
											/>
										</template>
										<span>Students are not necessary for now. You can add them later</span>
									</v-tooltip>
								</v-list-item-title>
							</v-list-item>
						</v-list>
					</v-col>
				</v-row>
				<v-row>
					<v-col>
						<v-btn 
							color="#12628d" 
							class="cancelButton" 
							@click="params.show = false"
						>
							Cancel
						</v-btn>
					</v-col>
					<v-col>
						<v-btn class="submitButton green" @click="submit">Submit</v-btn>
					</v-col>
				</v-row>
			</v-container>
		</v-form>
	</v-dialog>
</template>


<script>
import { Vue } from 'vue-property-decorator';
import { proposalService } from '@src/services/proposalService'
import { facultyService } from '@src/services/facultyService'
import { courseService } from '@src/services/courseService'
import selectableField from '@src/components/popups/popUpFields/selectableField'
import { bus } from '@src/services/eventBus'

export default Vue.component('createProposalPopUp',{
	props: {
		params: Object
	},
	components: {
		selectableField
	},
	methods: {
		addStudent: function() {
			var maxNumOfStudents = parseInt(this.chosenMaximalNumberOfStudents);
			if(this.indexNumbers.length < maxNumOfStudents) {
				var indexNumber = this.chosenIndexNumber;
				var isnum = /^\d+$/.test(indexNumber);
				if(isnum && !indexNumber.startsWith("0")) {
					var num = parseInt(indexNumber);
					if(!this.indexNumbers.includes(num)) {
						this.indexNumbers.push(num);
					}
				}
			}
			this.$refs.studentIndexNumberInput.reset();
		},
		onChangeFaculty: function() {
			this.courses = [];
			this.chosenCourse = null;
			this.chosenFaculty.courses.forEach(courseId => {
				courseService.get(courseId)
					.then(response => {
						if(response.status == 200) {
							var course = response.data;
							this.courses.push(course);
						}
					});
			});
			this.selectCoursesDisabled = false;
		},
		onChangeMaximalNumberOfStudents: function() {
			if(this.chosenMaximalNumberOfStudents.length > 0) {
				this.hideStudentList = false;
			}
			else {
				this.hideStudentList = true;
				this.indexNumbers = [];
			}
		},
		deleteIndexNumFromList: function(indexNumber) {
			var i = this.indexNumbers.indexOf(indexNumber);
			if (i !== -1) this.indexNumbers.splice(i, 1);
		},
		submit: function() {
			if(this.$refs.studentIndexNumberInput.value == "") {
				this.$refs.studentIndexNumberInput.resetValidation();
			}
			if(this.$refs.createProposalForm.validate()) {
				var proposalRegistration = {
					courseId: this.chosenCourse.id,
					students: this.indexNumbers,
					topicPolish: this.topicPolish,
					topicEnglish: this.topicEnglish,
					description: this.description,
					outputData: this.outputData,
					specialization: this.specialization,
					maxNumberOfStudents: this.chosenMaximalNumberOfStudents,
					studyProfile: this.chosenProfile.value,
					level: this.chosenLevel.value,
					mode: this.chosenMode.value
				}
				proposalService.create(proposalRegistration)
					.then(response => {
						if(response.status == 200) {
							bus.$emit('proposalWasCreated');
							this.params.show = false;
							this.$refs.createProposalForm.reset();
						}
					});
			}
		},
	},
	data() {
		return {
			isFormValid: false,
			selectCoursesDisabled: true,
			hideStudentList: true,
			topicPolish: "",
			topicEnglish: "",
			description: "",
			outputData: "",
			specialization: "",
			indexNumbers: [],
			faculties: [],
			courses: [],
			levels: [
				{
					name: 'Bachelor',
					value: 0
				},
				{
					name: 'Master',
					value: 1
				}
			],
			modes: [
				{
					name: 'Full-Time',
					value: 0
				},
				{
					name: 'Part-Time',
					value: 1
				}
			],
			profiles: [
				{
					name: "General academic",
					value: 0
				}
			],
			chosenFaculty: null,
			chosenCourse: null,
			chosenLevel: null,
			chosenMode: null,
			chosenProfile: null,
			chosenIndexNumber: null,
			chosenMaximalNumberOfStudents: null,
			topicRules: [
				v => !!v || 'Title is required',
				v => v.length >= 5 || 'Title should contain at least 5 characters',
				v => v.length <= 100 || 'Title should contain at most 100 characters'
			],
			descriptionRules: [
				v => !!v || 'Description is required',
				v => v.length >= 5 || 'Description should contain at least 5 characters',
				v => v.length <= 400 || 'Description should contain at most 400 characters'
			],
			outputDataRules: [
				v => v.length <= 400 || 'Output data should contain at most 400 characters',
			],
			specializationRules: [
				v => v.length <= 50 || 'Specialization should contain at most 50 characters'
			],
			maxNumberOfStudentsRules: [
				v => v >= 1 || 'The maximal number of students should be greater or equal to 1',
				v => v <= 4 || 'The maximal number of students should be less or equal to 4'
			],
			selectRules: [
				v => !!v || 'You must select a value'
			],
			studentRules: [
				v => v ? v >= 1 || 'Student ID number should be greater or equal to 1' : true,
				v => v == "" ? 'Student ID number should contain only digits' : false
			]
		}
	},
	created() {
		this.selectCoursesDisabled = true;
		this.disabledStudentList = true;
		facultyService.getAll()
			.then(response => {
				if(response.status == 200) {
					this.faculties = response.data;
				}
			});
	}
})
</script>


<style lang="scss" scoped>
.table {
	background-color: #ffffff;
}
.submitButton {
    font-size: 18px !important;
	color: rgb(255, 255, 255) !important;
	width: 180px !important;
	height: 70px !important;
	margin-left: 50px;
	float: left;
}

.cancelButton {
	font-size: 18px !important;
	color: rgb(255, 255, 255) !important;
	width: 180px !important;
	height: 70px !important;
	margin-right: 50px;
	float: right;
}
</style>
