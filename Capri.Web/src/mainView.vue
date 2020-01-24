<template>
    <div>
        <div>
            <navBar>
                <div slot="navItems">
                    <navStudentItems v-if="parsedToken.role === UserType.student"></navStudentItems>
                    <navList :userType="parsedToken.role"
                             v-if="
							parsedToken.role === UserType.promoter ||
								parsedToken.role === UserType.dean
						"></navList>
                </div>
            </navBar>
            <topBar> </topBar>
        </div>
        <router-view></router-view>
        <downBar />
    </div>
</template>
<script lang="ts">
import { Vue, Component } from 'vue-property-decorator';
import navBar from './components/navBar.vue';
import topBar from './components/topBar.vue';
import downBar from './components/downBar.vue';
import navStudentItems from './components/navStudentItems.vue';
import navList from './components/navList.vue';
import SessionService from '@src/services/sessionService'
enum UserType {
    student = 'Student',
    promoter = 'Promoter',
    dean = 'Dean',
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
export default class mainView extends Vue {
    public UserType = UserType;
    public parsedToken = new SessionService().getParsedToken();
    public checkNav(): string {
        return this.parsedToken["role"]
    }
}
</script>
<style lang="scss" scoped>
.appColor {
	background-color: #eeeeee;
}
</style>
