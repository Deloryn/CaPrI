<template>
	<div id="studentBar">
		<v-list-item
			v-for="(filter, i) in filters"
			:key="i"
			class="paddingAndMarginZero px-3"
		>
			<v-list-item-action
				color="blue"
				class="paddingAndMarginZero my-4"
                style="width: 310px;"
			>
				<v-select
					:items="filter.values"
					:label="filter.name"
					:model="filter.chosen"
					v-on:change="changeRoute(i)"
					color="blue"
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
    public data() {
        return {
            isAllSelected: 'nie',
        };
    }
    public changeRoute(which): void {
        this.filters[which].chosen = true;
        for (let i = 0; i < this.filters.length; i += 1) {
            if (this.filters[i].chosen === false) {
                return;
            }
        }
        this.$router.push({ path: '/cards' });
    }
}
</script>
<style lang="scss" scoped>
.paddingAndMarginZero {
    padding: 0px;
    margin: 0px;
}
</style>
