import Vue from 'vue';
import Router from 'vue-router';
import LoginPanel from './components/loginPanel.vue';
import StudentView from './components/StudentView.vue';
import PromoterView from './components/PromoterView.vue';
import DeaneryView from './components/DeaneryView.vue';

Vue.use(Router);

export default new Router({
    mode: 'history',
    // tslint:disable-next-line: object-literal-sort-keys
    base: process.env.BASE_URL,
    routes: [
        { path: '/', component: LoginPanel },
        { path: '/list/:type', component: StudentView },
        { path: '/myList', component: PromoterView },
        { path: '/deaneryList', component: DeaneryView },
    ],
});
