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
import { instituteService } from '@src/services/instituteService'
import { bus } from '@src/services/eventBus'

export default Vue.component('promotersFilterComponent', {
    data() {
        return {
            anyInstitute: {
                name: this.$i18n.t('commons.any'),
                id: null
            },
            selectedInstitute: null,
            filters: [
                {
                    name: this.$i18n.t('institute.institute'),
                    values: [],
                    chosen: null,
                },
            ]
        }
    },
    methods: {
        getData: function() {
            instituteService.getAll()
                .then(response => {
                    if(response.status == 200) {
                        var institutes = response.data
                        this.filters[0].values = [this.anyInstitute].concat(institutes);
                    }
                });
        },
        update: function(filter) {
            var chosenValue = filter.chosen;
            switch(filter.name) {
                case this.$i18n.t('institute.institute'): {
                    this.selectedInstitute = chosenValue;
                    this.emitFilters();
                    break;
                }
            }
        },
        emitFilters: function() {
            bus.$emit('promotersFiltersWereChosen', this.selectedInstitute);
        },
        clearFilters: function() {
            this.filters[0].chosen = this.anyInstitute;
            this.selectedInstitute = this.anyInstitute;
            this.emitFilters();
        }
    },
    created() {
        this.getData();
        this.clearFilters();
        bus.$on('clearPromoterFilters', this.clearFilters);
    }
})
</script>
<style lang="scss" scoped>
.listItemWidth {
	width: 310px;
}
</style>
