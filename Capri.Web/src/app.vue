<template>
    <v-app id="app" class="appColor">
        <div v-if="$route.path === '/Home/Index/login'">
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

@Component({
    components: {
        mainView,
        loginView
    },
})
export default class App extends Vue {
}
</script>
<style lang="scss" scoped>
.appColor {
	background-color: #eeeeee;
}
</style>
