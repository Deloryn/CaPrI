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
            <component v-if="link.component" :is="link.component" :key="$i18n.locale"></component>
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
            links: {
                promoters: {
                    to: '/view/promoters',
                    icon: 'mdi-account-multiple',
                    text: this.$i18n.t('promoter.promoterPlural'),
                    dropDownOnStart: false
                },
                proposals: {
                    to: '/view/proposals',
                    icon: 'mdi-school-outline',
                    text: this.$i18n.t('proposal.proposalPlural'),
                    dropDownOnStart: true,
                    component: proposalsFilterComponent
                },
                myProposals: {
                    to: '/view/my_proposals',
                    icon: 'mdi-book-open',
                    text: this.$i18n.t('proposal.myProposals'),
                    dropDownOnStart: false
                },
            },
        }
    },
	methods: {
        selectLinks: function(userType) {
            const newLinks = [];
            if (userType === 'Promoter') {
                newLinks.push(this.links.proposals, this.links.myProposals);
            } 
            else if (userType === 'Dean') {
                newLinks.push(this.links.proposals, this.links.promoters);
            }
            else if (userType === 'Student') {
                newLinks.push(this.links.proposals)
            }
            return newLinks;
        },
        render: function(url) {
            router.push(url);
            bus.$emit('clearProposalFilters');
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
