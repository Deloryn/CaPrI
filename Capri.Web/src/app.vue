<template>
	<v-app id="app" class="appColor">
		<div v-if="$route.path !== '/login'">
			<navBar>
				<div slot="navItems">
					<navStudentItems
						v-if="parsedToken.role === UserType.student"
					></navStudentItems>
					<navList
						:userType="parsedToken.role"
						v-if="
							parsedToken.role === UserType.promoter ||
								parsedToken.role === UserType.dean
						"
					></navList>
				</div>
			</navBar>
			<topBar> </topBar>
		</div>
		<router-view></router-view>
		<downBar v-if="$route.path !== '/login'" />
	</v-app>
</template>
<script lang="ts">
import { Vue, Component } from 'vue-property-decorator';
import navBar from './components/navBar.vue';
import topBar from './components/topBar.vue';
import downBar from './components/downBar.vue';
import navStudentItems from './components/navStudentItems.vue';
import navList from './components/navList.vue';
import sessionService from './services/sessionService';

enum UserType {
    student = 'student',
    promoter = 'promoter',
    dean = 'dean',
}

@Component({
    components: {
        navBar,
        topBar,
        downBar,
        navStudentItems,
        navList,
    },
})
export default class App extends Vue {
    public UserType = UserType;
    public parsedToken = new sessionService().parsedToken;
}
</script>
<style lang="scss" scoped>
.appColor {
	background-color: #eeeeee;
}
</style>
