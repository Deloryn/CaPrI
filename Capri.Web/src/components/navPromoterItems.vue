<template>
	<div id="promoterBar">
		<v-list-item
			v-for="(link, i) in links"
			:key="i"
			:to="link.to"
			active-class="primary white--text"
			class="promoterItems"
		>
			<v-list-item-action class="promoterItem px-3">
				<v-icon>{{ link.icon }}</v-icon>
			</v-list-item-action>

			<v-list-item-title v-text="$i18n.t(link.text)" />
		</v-list-item>
	</div>
</template>
<script lang="ts">
import { Vue, Component, Prop } from 'vue-property-decorator';
import i18n from '../plugins/i18n'

@Component
export default class NavPromoterItems extends Vue {


    public data() {
        return {
            links: [
                {
                    to: '/myProporsals',
                    icon: 'mdi-book-open',
                    text: 'promoter.myProposals',
                },
                {
                    to: '/cards',
                    icon: 'mdi-school-outline',
                    text: 'promoter.listOfThesis',
                },
            ],
        };
    }
}
</script>
<style lang="scss" scoped>
div .v-list-item__title {
	font-size: 24px;
	font-weight: bold;
}
.promoterItems {
	margin: 0;
	padding: 0;
	border-radius: 0;
	height: 80px;
}
.promoterItem {
	margin: 0;
	padding: 0;
}
</style>
