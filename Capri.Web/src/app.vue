<template>
    <v-app id="app" class="appColor">
        <div v-if="$route.path === '/login'">
            <loginView />
        </div>
        <div v-else>
            <mainView />
        </div>
    </v-app>
</template>
<script lang="ts">
import { Vue, Component } from 'vue-property-decorator';
import mainView from './mainView.vue';
import loginView from './components/loginView.vue';
import navBar from './components/navBar.vue';
import topBar from './components/topBar.vue';
import downBar from './components/downBar.vue';
import navStudentItems from './components/navStudentItems.vue';
import navList from './components/navList.vue';
import { sessionService } from './services/sessionService';

enum UserType {
    student = 'student',
    promoter = 'promoter',
    dean = 'dean',
}

@Component({
    components: {
        mainView,
        loginView
    },
})
export default class App extends Vue {
    public UserType = UserType;
    public parsedToken = sessionService.getParsedToken();
}
</script>
<style lang="scss" scoped>
.appColor {
	background-color: #eeeeee;
}
</style>
