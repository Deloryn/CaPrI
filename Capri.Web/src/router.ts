import Vue from 'vue';
import Router from 'vue-router';
import LoginPanel from './components/loginPanel.vue';
import CardsView from './components/cardsView.vue';
import MyProporsals from './components/myProporsals.vue';
import PromoterList from './components/promotersList.vue';
import Import from './components/importPromoters.vue';

Vue.use(Router);

export default new Router({
    mode: 'history',
    // tslint:disable-next-line: object-literal-sort-keys
    base: process.env.BASE_URL,
    routes: [
        { path: '/', component: LoginPanel },
        { path: '/cards', component: CardsView },
        { path: '/myProporsals', component: MyProporsals },
        { path: '/promoterList', component: PromoterList },
        { path: '/import', component: Import },
    ],
});
