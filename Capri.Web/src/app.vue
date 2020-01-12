<template>
	<v-app id="app" class="appColor">
		<div v-if="$route.path !== '/login'">
			<navBar>
				<div slot="navItems">
					<navStudentItems
						v-if="parsedToken.role === 'student'"
					></navStudentItems>
					<navList
						:userType="parsedToken.role"
						v-if="
							parsedToken.role === 'promoter' ||
								userType === 'dean'
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
import jwt_decode from 'jwt-decode';

enum UserTypes {
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
    public token = sessionStorage.token;
    public parsedToken = jwt_decode(this.token);
}
</script>
<style scoped>
.appColor {
	background-color: #eeeeee;
}
</style>
