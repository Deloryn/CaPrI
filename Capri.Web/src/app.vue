<template>
	<v-app id="app" style="background-color: #EEEEEE;">
		<div v-if="$route.path !== '/'">
			<navBar>
				<div slot="navItems">
					<navStudentItems
						v-if="userType === 'student'"
					></navStudentItems>
					<navPromoterItems
						v-if="userType === 'promoter'"
					></navPromoterItems>
					<navDeanItems v-if="userType === 'dean'"></navDeanItems>
				</div>
			</navBar>
			<topBar> </topBar>
		</div>
		<router-view></router-view>
		<downBar />
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
    public data() {
        return {
            userType: UserTypes.student,
        };
    }
}
</script>
