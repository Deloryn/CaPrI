<template>
	<v-footer
		fixed
		height="128"
		class="footerContainer"
	>
		<v-spacer></v-spacer>
		<div class="footer">&copy; {{ new Date().getFullYear() }}</div>
	</v-footer>
</template>

<script lang="ts">
import { Vue, Component, Prop } from 'vue-property-decorator';

@Component
export default class DownBar extends Vue {}
</script>
<style lang="scss" scoped>
.footer {
	font-size: 80px;
	color: rgb(0, 100, 139);
	position: absolute;
	left: 50%;
	transform: translateX(-50%);
}
.footerContainer {
    left: 320px;
    background-color: rgb(149, 149, 149);
}
</style>
