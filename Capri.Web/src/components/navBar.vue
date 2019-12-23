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
			style="margin: 10px;"
		/>

		<p class="text-center" style="font-size: 60px; color: #FFFFFF">CaPri</p>

		<slot name="navItems"></slot>
		<v-list nav style="margin: 0; padding: 0;">
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
<style lang="scss" scoped></style>
