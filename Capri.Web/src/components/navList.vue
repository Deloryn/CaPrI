<template>
    <v-list>
        <v-list-group
            v-for="link in selectLinks(userType)"
            :key="link.text"
            active-class="primary white--text"
            @click="render(link.to)"
            :value="link.dropDownOnStart"
        >
            <template v-slot:activator>
                <v-list-item-title v-text="link.text" class="margins"/>
            </template>
            <component v-if="link.component" :is="link.component"></component>
        </v-list-group>
    </v-list>
</template>
<script>
import { Vue } from 'vue-property-decorator';
import proposalsFilterComponent from '@src/components/proposalsFilterComponent'
import router from '@src/router'
import { bus } from '@src/services/eventBus'

export default Vue.component('navList', {
	props: {
		userType: ''
    },
    components: {
        proposalsFilterComponent
    },
    data() {
        return {
            links: [
                {
                    to: '/view/institutes',
                    icon: '',
                    text: 'Institutes',
                    dropDownOnStart: false
                },
                {
                    to: '/view/promoters',
                    icon: 'mdi-account-multiple',
                    text: 'Promoters',
                    dropDownOnStart: false
                },
                {
                    to: '/view/proposals',
                    icon: 'mdi-school-outline',
                    text: 'Proposals',
                    dropDownOnStart: true,
                    component: proposalsFilterComponent
                },
                {
                    to: '/view/import',
                    icon: 'mdi-import',
                    text: 'Import data',
                    dropDownOnStart: false
                },
                {
                    to: '/view/my_proposals',
                    icon: 'mdi-book-open',
                    text: 'My proposals',
                    dropDownOnStart: false
                },
            ],
        }
    },
	methods: {
        selectLinks: function(userType) {
            const newLinks = [];
            if (userType === 'Promoter') {
                newLinks.push(this.links[2], this.links[4]);
            } 
            else if (userType === 'Dean') {
                newLinks.push(this.links[2], this.links[1], this.links[0], this.links[3]);
            }
            else if (userType === 'Student') {
                newLinks.push(this.links[2])
            }
            return newLinks;
        },
        render: function(url) {
            router.push(url);
            bus.$emit('clearFilters');
        }
	}
})

</script>
<style lang="scss" scoped>
div .v-list-item__title {
	font-size: 24px;
	font-weight: bold;
}

.margins {
    margin-top: 30px;
    margin-bottom: 30px;
}
</style>
