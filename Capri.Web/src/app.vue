<template>
	<v-app id="app" style="background-color: #EEEEEE;">
		<div v-if="$route.path !== '/'">
			<navBar />
			<topBar />
		</div>
		<router-view></router-view>
	</v-app>
</template>
<script lang="ts">
import { Vue, Component } from 'vue-property-decorator';
import navBar from './components/navBar.vue';
import topBar from './components/topBar.vue';

@Component({
    components: {
        navBar,
        topBar,
    },
})
export default class App extends Vue {}
</script>
