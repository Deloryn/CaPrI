<template>
	<v-footer fixed height="50">
		<v-spacer></v-spacer>
		<div class="footer">&copy; 2020 Michalak Krzysztof, Liszka Szymon, Karczewski Krzysztof, Ginna Naatay</div>
	</v-footer>
</template>

<script lang="ts">
import { Vue, Component, Prop } from 'vue-property-decorator';

@Component
export default class DownBar extends Vue {}
</script>
<style lang="scss" scoped>
.footer {
	font-size: 16px;
	color: rgb(0, 100, 139);
	position: absolute;
	left: 50%;
	transform: translateX(-50%);
}
.theme--light.v-footer {
	margin-left: 320px;
	background-color: rgb(149, 149, 149);
}
</style>
