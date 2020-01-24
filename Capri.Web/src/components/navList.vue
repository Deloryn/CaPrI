<template>
	<div id="deanBar">
		<v-list-item
			v-for="(link, i) in selectLinks(userType)"
			:key="i"
			:to="link.to"
			active-class="primary white--text"
			class="paddingAndMarginZero noBorder listDim"
		>
			<v-list-item-action class="paddingAndMarginZero px-3">
				<v-icon>{{ link.icon }}</v-icon>
			</v-list-item-action>

			<v-list-item-title v-text="link.text" />
		</v-list-item>
	</div>
</template>
<script lang="ts">
import { Vue, Component, Prop } from 'vue-property-decorator';

@Component
export default class NavDeanItems extends Vue {
    @Prop() public userType!: ['userType'];
    public links = [
        {
            to: '/view/institutes',
            icon: '',
            text: 'Institutes',
        },
        {
            to: '/view/promoters',
            icon: 'mdi-account-multiple',
            text: 'Promoters',
        },
        {
            to: '/view/proposals',
            icon: 'mdi-school-outline',
            text: 'Proposals',
        },
        {
            to: '/view/import',
            icon: 'mdi-import',
            text: 'Import promoters',
        },
        {
            to: '/view/my_proposals',
            icon: 'mdi-book-open',
            text: 'My proposals',
        },
    ];
    public data() {
        return {};
    }
    public selectLinks(userType): [] {
        const newLinks = [] as any;
        if (userType === 'Promoter') {
            newLinks.push(this.links[2], this.links[4]);
        } 
        else if (userType === 'Dean') {
            newLinks.push(this.links[0], this.links[1], this.links[2], this.links[3]);
        }
        else if (userType === 'Student') {
            newLinks.push(this.links[2])
        }
        return newLinks;
    }
}
</script>
<style lang="scss" scoped>
div .v-list-item__title {
	font-size: 24px;
	font-weight: bold;
}
.paddingAndMarginZero {
	padding: 0px;
	margin: 0px;
}
.noBorder {
	border-radius: 0px;
}
.listDim {
	height: 80px;
	font-size: 50px;
}
</style>
