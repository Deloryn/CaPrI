<template>
	<div id="studentBar">
		<v-list-item
			v-for="(filter, i) in filters"
			:key="i"
			class="paddingAndMarginZero px-3"
		>
			<v-list-item-action color="blue"
								class="paddingAndMarginZero my-4"
								style="width: 310px;">
				<v-select :items="filter.values"
						  :label="$i18n.t(filter.name)"
						  :model=true
						  clearable
						  v-on:change="changeRoute(i)"
						  color="blue"
						  class="paddingAndMarginZero">

					<template slot="selection" slot-scope="data">
						{{ $i18n.t(data.item) }}
					</template>
					<template slot="item" slot-scope="data">
						{{ $i18n.t(data.item) }}
					</template>
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
            name: 'faculty',
            values: ['computerScience'],
            chosen: false,
        },
        {
            name: 'fieldOfStudy',
            values: ['IT', 'robotics', 'bioinformatics'],
            chosen: false,
        },
        {
            name: 'degree',
            values: ['bachelor', 'master'],
            chosen: false,
        },
        {
            name: 'type',
            values: ['fullTime', 'partTime'],
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
