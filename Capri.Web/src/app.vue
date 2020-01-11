<template>
	<v-app id="app" class="appColor">
		<div v-if="$route.path !== '/'">
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
		<downBar v-if="$route.path !== '/'" />
	</v-app>
</template>
<script lang="ts">
import { Vue, Component } from 'vue-property-decorator';
import navBar from './components/navBar.vue';
import topBar from './components/topBar.vue';
import downBar from './components/downBar.vue';
import navStudentItems from './components/navStudentItems.vue';
import navList from './components/navList.vue';

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
    public parsedToken = this.parseJwt();
    public parseJwt(): JSON {
        if (this.token === undefined) {
            sessionStorage.setItem(
                'token',
                'eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6Ijg4NDhlMGFlLTJkOGYtNDM2MS04MjVmLTU1MDU1ZmNjNGEwMiIsInJvbGUiOiJwcm9tb3RlciIsIm5iZiI6MTU3ODY5MjEyNiwiZXhwIjoxNTc5Mjk2OTI2LCJpYXQiOjE1Nzg2OTIxMjYsImlzcyI6ImVtcHR5Q29tcGFueSJ9.2WuO_GDiGUkW_rfr6Rxn4fao3q-D6Mx-RUrNtOahWiQ',
            );
            this.token = sessionStorage.token;
        }
        const base64Url = this.token.split('.')[1];
        const base64 = base64Url.replace(/-/g, '+').replace(/_/g, '/');
        const jsonPayload = decodeURIComponent(
            atob(base64)
                .split('')
                .map(c => {
                    return (
                        '%' + ('00' + c.charCodeAt(0).toString(16)).slice(-2)
                    );
                })
                .join(''),
        );
        return JSON.parse(jsonPayload);
    }
}
</script>
<style scoped>
.appColor {
	background-color: #eeeeee;
}
</style>
