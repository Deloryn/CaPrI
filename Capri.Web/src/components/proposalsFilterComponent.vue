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
                name: this.$i18n.t('commons.any'),
                id: null
            },
            anyCourse: {
                name: this.$i18n.t('commons.any'),
                id: null
            },
            anyLevel: {
                name: this.$i18n.t('commons.any'),
                value: null
            },
            anyMode: {
                name: this.$i18n.t('commons.any'),
                value: null
            },
            selectedFaculty: null,
            selectedCourse: null,
            selectedLevel: null,
            selectedMode: null,
            filters: [
                {
                    name: this.$i18n.t('faculty.faculty'),
                    values: [],
                    chosen: null,
                },
                {
                    name: this.$i18n.t('course.course'),
                    values: [],
                    chosen: null,
                },
                {
                    name: this.$i18n.t('level.level'),
                    values: [
                                {
                                    name: this.$i18n.t('commons.any'),
                                    value: null
                                },
                                {
                                    name: this.$i18n.t('level.bachelor'),
                                    value: 0
                                },
                                {
                                    name: this.$i18n.t('level.master'),
                                    value: 1
                                }
                            ],
                    chosen: null,
                },
                {
                    name: this.$i18n.t('mode.mode'),
                    values: [
                                {
                                    name: this.$i18n.t('commons.any'),
                                    value: null
                                },
                                {
                                    name: this.$i18n.t('mode.fullTime'),
                                    value: 0
                                },
                                {
                                    name: this.$i18n.t('mode.partTime'),
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
                case this.$i18n.t('faculty.faculty'): {
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
                case this.$i18n.t('course.course'): {
                    this.selectedCourse = chosenValue;
                    this.emitFilters();
                    break;
                }
                case this.$i18n.t('level.level'): {
                    this.selectedLevel = chosenValue.value;
                    this.emitFilters();
                    break;
                }
                case this.$i18n.t('mode.mode'): {
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
        bus.$on('clearProposalFilters', this.clearFilters);
    }
})
</script>
<style lang="scss" scoped>
.listItemWidth {
	width: 310px;
}
</style>
