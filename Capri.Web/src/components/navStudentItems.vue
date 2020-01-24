<template>
	<div id="studentBar">
		<v-list-item
			v-for="(filter, i) in filters"
			:key="i"
			class="paddingAndMarginZero px-3"
		>
			<v-list-item-action
				color="blue"
				class="paddingAndMarginZero my-4 listItemWidth"
			>
				<v-select
					:items="filter.values"
					:label="filter.name"
					v-model="filter.chosen"
                    @change="update(filter)"
					color="rgb(18,98,141)"
					class="paddingAndMarginZero"
				>
				</v-select>
			</v-list-item-action>
		</v-list-item>
	</div>
</template>
<script>
import { facultyService } from '@src/services/facultyService'
import { courseService } from '@src/services/courseService'
import { bus } from '@src/services/eventBus'

export default {
    name: 'navStudentItems',
    data() {
        return {
            filters: [
                {
                    name: 'Faculty',
                    values: [],
                    chosen: false,
                },
                {
                    name: 'Field of study',
                    values: [],
                    chosen: false,
                },
                {
                    name: 'Study level',
                    values: ['Bachelor', 'Master'],
                    chosen: false,
                },
                {
                    name: 'Study mode',
                    values: ['Full-Time', 'Part-Time'],
                    chosen: false,
                },
            ]
        }
    },
    methods: {
        getData: function() {
            facultyService.getAll()
                .then(response => {
                    if(response.status == 200) {
                        var faculties = response.data.map(faculty => faculty.name);
                        this.filters[0].values = faculties;
                    }
                });
            courseService.getAll()
                .then(response => {
                    if(response.status == 200) {
                        var courses = response.data.map(course => course.name);
                        this.filters[1].values = courses;
                    }
                });
        },
        update: function(filter) {
            var chosenValue = filter.chosen;
            switch(filter.name) {
                case 'Faculty': {
                    facultyService.getAll()
                    .then(response => {
                        if(response.status == 200) {
                            var faculties = response.data;
                            var faculty = faculties.find(f => f.name == chosenValue);
                            if(faculty) {
                                this.filters[1].values = []
                                faculty.courses.forEach(courseId => {
                                    courseService.get(courseId)
                                        .then(response => {
                                            if(response.status == 200) {
                                                var course = response.data;
                                                this.filters[1].values.push(course.name);
                                            }
                                        });
                                });
                                bus.$emit('facultyWasChosen', faculty.id);
                            }
                        }
                    });
                }
                case 'Field of study': {
                    break;
                }
                case 'Study level': {
                    break;
                }
                case 'Study mode': {
                    break;
                }
            }
        }
    },
    created() {
        this.getData();
    }
}
</script>
<style lang="scss" scoped>
.listItemWidth {
	width: 310px;
}
</style>
