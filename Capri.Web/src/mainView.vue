<template>
    <div>
        <div>
            <navBar>
                <div slot="navItems">
                    <navList :userType="parsedToken.role" :key="$i18n.locale"></navList>
                </div>
            </navBar>
            <topBar> </topBar>
        </div>
        <router-view :key="$i18n.locale"></router-view>
        <downBar />
    </div>
</template>
<script lang="ts">
import { Vue, Component } from 'vue-property-decorator';
import navBar from './components/navBar.vue';
import topBar from './components/topBar.vue';
import downBar from './components/downBar.vue';
import proposalsFilterComponent from './components/proposalsFilterComponent.vue';
import navList from './components/navList.vue';
import { sessionService } from '@src/services/sessionService'

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
        proposalsFilterComponent,
        navList,
    },
})
export default class mainView extends Vue {
    public UserType = UserType;
    public parsedToken = sessionService.getParsedToken();
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
