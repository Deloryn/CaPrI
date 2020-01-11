import Vue from 'vue';
import Router from 'vue-router';
import loginView from './components/loginView.vue';
import CardsView from './components/cardsView.vue';
import MyProposals from './components/myProposals.vue';
import PromoterList from './components/promotersList.vue';
import Import from './components/importPromoters.vue';

Vue.use(Router);

export default new Router({
    mode: 'history',
    routes: [
        { path: '/', component: loginView },
        { path: '/cards', component: CardsView },
        { path: '/myProposals', component: MyProposals },
        { path: '/promoterList', component: PromoterList },
        { path: '/import', component: Import },
    ],
});
