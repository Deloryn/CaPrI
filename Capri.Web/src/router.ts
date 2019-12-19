import Vue from 'vue';
import Router from 'vue-router';
import LoginPanel from './components/loginPanel.vue';
import StudentView from './components/StudentView.vue';
import PromoterView from './components/PromoterView.vue';
import DeaneryView from './components/DeaneryView.vue';
import CardsView from './components/CardsView.vue';
import MyProporsals from './components/myProporsals.vue';
import PromoterList from './components/promotersList.vue';
import Import from './components/Import.vue';

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
        { path: '/cards', component: CardsView },
        { path: '/myProporsals', component: MyProporsals },
        { path: '/promoterList', component: PromoterList },
        { path: '/import', component: Import },
    ],
});
