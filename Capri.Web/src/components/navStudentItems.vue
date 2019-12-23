<template>
	<div id="studentBar">
		<v-list-item
			v-for="(filter, i) in filters"
			:key="i"
			style="padding: 0; margin: 0;"
			class="px-3"
		>
			<v-list-item-action
				color="blue"
				style="padding: 0; margin: 0; width: 310px;"
				class="my-4"
			>
				<v-select
					:items="filter.values"
					:label="filter.name"
					:model="filter.chosen"
					v-on:change="changeRoute(i)"
					color="blue"
					style="padding: 0; margin: 0;"
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
    public filters: boolean[];
    public data() {
        return {
            isAllSelected: 'nie',
            filters: [
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
            ],
        };
    }
    public changeRoute(num) {
        this.filters[num] = true;
        for (let i = 0; i < this.filters.length; i += 1) {
            if ((this as any).filters[i].chosen === false) {
                return;
            }
        }
        this.$router.push({ path: '/cards' });
    }
}
</script>
<style lang="scss" scoped></style>
