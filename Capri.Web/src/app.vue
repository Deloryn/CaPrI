<template>
	<v-app id="app" style="background-color: #EEEEEE;">
		<div v-if="$route.path !== '/'">
			<navBar>
				<div slot="navItems">
					<navStudentItems
						v-if="parsedToken.userType === 'student'"
					></navStudentItems>
					<navPromoterItems
						v-if="parsedToken.userType === 'promoter'"
					></navPromoterItems>
					<navDeanItems v-if="parsedToken.userType === 'dean'"></navDeanItems>
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
import navPromoterItems from './components/navPromoterItems.vue';
import navDeanItems from './components/navDeanItems.vue';

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
        navPromoterItems,
        navDeanItems,
    },
})
export default class App extends Vue {
    public token = 'eyJ0eXAiOiJKV1QiLCJhbGciOiJIUzI1NiJ9.eyJpc3MiOiJPbmxpbmUgSldUIEJ1aWxkZXIiLCJpYXQiOjE1NzgyMTIyMzksImV4cCI6MTYwOTc0ODIzOSwiYXVkIjoid3d3LmV4YW1wbGUuY29tIiwic3ViIjoianJvY2tldEBleGFtcGxlLmNvbSIsIm5hbWUiOiJKYW4iLCJzdXJuYW1lIjoiS293YWxza2kiLCJ1c2VyVHlwZSI6InN0dWRlbnQifQ.ctvoGDzu1NduvYTfMnpegWPt8dgLhCuUfPouUaaDtwY.ctvoGDzu1NduvYTfMnpegWPt8dgLhCuUfPouUaaDtwY';
    public parsedToken = this.parseJwt(this.token);
    public parseJwt(token: string): JSON {
        const base64Url = token.split('.')[1];
        const base64 = base64Url.replace(/-/g, '+').replace(/_/g, '/');
        const jsonPayload = decodeURIComponent(atob(base64).split('').map((c) => {
            return '%' + ('00' + c.charCodeAt(0).toString(16)).slice(-2);
        }).join(''));
        return JSON.parse(jsonPayload);
    }
}
</script>
