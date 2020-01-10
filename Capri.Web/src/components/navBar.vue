<template>
	<v-navigation-drawer
		id="app-drawer"
		app
		color="#232323"
		dark
		floating
		mobile-break-point="991"
		persistent
		width="320"
	>
		<template v-slot:img="attrs">
			<v-img
				v-bind="attrs"
				gradient="to top, rgba(0, 0, 0, .7), rgba(0, 0, 0, .7)"
			/>
		</template>

		<v-img
			:src="require('../assets/putLogoColor.png')"
			height="140"
			contain
            class="marginTen"
		/>

		<p class="text-center capriText">CaPri</p>

		<slot name="navItems"></slot>
		<v-list nav class="paddingAndMarginZero">
			<!-- Bug in Vuetify for first child of v-list not receiving proper border-radius -->
			<div />
		</v-list>
	</v-navigation-drawer>
</template>
<script lang="ts">
import { Vue, Component, Prop } from 'vue-property-decorator';

@Component
export default class NavBar extends Vue {}
</script>
<style lang="scss" scoped>
.marginTen {
    margin: 10px;
}
.capriText {
    font-size: 60px;
    color: #FFFFFF;
}
</style>
