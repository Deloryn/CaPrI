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
					:model="filter.chosen"
					color="rgb(18,98,141)"
					class="paddingAndMarginZero"
				>
				</v-select>
			</v-list-item-action>
		</v-list-item>
	</div>
</template>
<script lang="ts">
import { Vue, Component, Prop } from 'vue-property-decorator';

@Component
export default class NavStudentItems extends Vue {
    public filters = [
        {
            name: 'Faculty',
            values: ['Computer Science'],
            chosen: false,
        },
        {
            name: 'Field of study',
            values: ['IT', 'Robotics', 'Bioinformatics'],
            chosen: false,
        },
        {
            name: 'Degree',
            values: ['Bacheloer', 'Master'],
            chosen: false,
        },
        {
            name: 'Type',
            values: ['Full time', 'Part time'],
            chosen: false,
        },
    ];
}
</script>
<style lang="scss" scoped>
.listItemWidth {
	width: 310px;
}
</style>
