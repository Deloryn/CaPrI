<template>
	<div id="studentBar">
		<v-list-item
			v-for="filter in filters"
			:key="filter.name"
			class="paddingAndMarginZero px-3"
		>
			<v-list-item-action
				color="blue"
				class="paddingAndMarginZero my-4 listItemWidth"
			>
				<v-select
					:items="filter.values"
					:label="filter.name"
                    return-object
                    @change="update(filter)"
                    v-model="filter.chosen"
					color="rgb(18,98,141)"
					class="paddingAndMarginZero"
				>
                    <template slot="selection" slot-scope="data">
                        {{ data.item.name }}
                    </template>
                    <template slot="item" slot-scope="data">
                        {{ data.item.name }}
                    </template>
				</v-select>
			</v-list-item-action>
		</v-list-item>
	</div>
</template>
<script>
import { Vue } from 'vue-property-decorator';
import { facultyService } from '@src/services/facultyService'
import { courseService } from '@src/services/courseService'
import { bus } from '@src/services/eventBus'

export default Vue.component('proposalsFilterComponent', {
    data() {
        return {
            anyFaculty: {
                name: "Any",
                id: null
            },
            anyCourse: {
                name: "Any", 
                id: null
            },
            anyLevel: {
                name: 'Any',
                value: null
            },
            anyMode: {
                name: 'Any',
                value: null
            },
            selectedFaculty: null,
            selectedCourse: null,
            selectedLevel: null,
            selectedMode: null,
            filters: [
                {
                    name: 'Faculty',
                    values: [],
                    chosen: null,
                },
                {
                    name: 'Field of study',
                    values: [],
                    chosen: null,
                },
                {
                    name: 'Study level',
                    values: [
                                {
                                    name: 'Any',
                                    value: null
                                },
                                {
                                    name: 'Bachelor',
                                    value: 0
                                },
                                {
                                    name: 'Master',
                                    value: 1
                                }
                            ],
                    chosen: null,
                },
                {
                    name: 'Study mode',
                    values: [
                                {
                                    name: 'Any',
                                    value: null
                                },
                                {
                                    name: 'Full-Time',
                                    value: 0
                                },
                                {
                                    name: 'Part-Time',
                                    value: 1
                                }
                            ],
                    chosen: null,
                },
            ]
        }
    },
    methods: {
        getData: function() {
            facultyService.getAll()
                .then(response => {
                    if(response.status == 200) {
                        var faculties = response.data
                        this.filters[0].values = [this.anyFaculty].concat(faculties);
                    }
                });
            courseService.getAll()
                .then(response => {
                    if(response.status == 200) {
                        var courses = response.data
                        this.filters[1].values = [this.anyCourse].concat(courses);
                    }
                });
        },
        update: function(filter) {
            var chosenValue = filter.chosen;
            switch(filter.name) {
                case 'Faculty': {
                    this.selectedFaculty = chosenValue;
                    this.filters[1].values = [this.anyCourse]
                    this.filters[1].chosen = this.anyCourse;
                    this.selectedCourse = this.anyCourse;
                    if(this.selectedFaculty.courses) {
                        this.selectedFaculty.courses.forEach(courseId => {
                        courseService.get(courseId)
                            .then(response => {
                                if(response.status == 200) {
                                    var course = response.data;
                                    this.filters[1].values.push(course);
                                }
                            });
                    });
                    }
                    this.emitFilters();
                    break;
                }
                case 'Field of study': {
                    this.selectedCourse = chosenValue;
                    this.emitFilters();
                    break;
                }
                case 'Study level': {
                    this.selectedLevel = chosenValue.value;
                    this.emitFilters();
                    break;
                }
                case 'Study mode': {
                    this.selectedMode = chosenValue.value;
                    this.emitFilters();
                    break;
                }
            }
        },
        emitFilters: function() {
            bus.$emit('filtersWereChosen', {
                    faculty: this.selectedFaculty,
                    course: this.selectedCourse,
                    level: this.selectedLevel,
                    mode: this.selectedMode
                });
        },
        clearFilters: function() {
            this.filters[0].chosen = this.anyFaculty;
            this.filters[1].chosen = this.anyCourse;
            this.filters[1].values = [this.anyCourse];
            this.filters[2].chosen = this.anyLevel;
            this.filters[3].chosen = this.anyMode;
            this.selectedFaculty = this.anyFaculty;
            this.selectedCourse = this.anyCourse;
            this.selectedLevel = this.anyLevel.value;
            this.selectedMode = this.anyMode.value;
            this.emitFilters();
        }
    },
    created() {
        this.getData();
        this.clearFilters();
        bus.$on('clearFilters', this.clearFilters);
    }
})
</script>
<style lang="scss" scoped>
.listItemWidth {
	width: 310px;
}
</style>
