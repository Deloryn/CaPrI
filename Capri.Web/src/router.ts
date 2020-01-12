import Vue from 'vue';
import Router from 'vue-router';
import LoginView from './components/loginView.vue';
import CardsView from './components/cardsView.vue';
import MyProposals from './components/myProposals.vue';
import PromoterList from './components/promotersList.vue';
import Import from './components/importPromoters.vue';
import axios from 'axios';
import VueAxios from 'vue-axios';
import sessionService from './services/sessionService';

Vue.use(Router);
Vue.use(VueAxios, axios);

const router = new Router({
    mode: 'history',
    routes: [
        { path: '/login', component: LoginView },
        { path: '/cards', component: CardsView },
        { path: '/myProposals', component: MyProposals },
        { path: '/promoterList', component: PromoterList },
        { path: '/import', component: Import },
        { path: '/', component: CardsView },
        { path: '/Home/Index/', redirect: '/' },
    ],
});

router.beforeEach((to, from, next) => {
    if (to.path !== '/login' && !sessionStorage.token) {
        next('/login');
    } else {
        next();
    }
});

Vue.axios.interceptors.request.use(
    config => {
        return config;
    },
    error => {
        if (401 === error.response.status) {
            router.push('/login');
        } else {
            return Promise.reject(error);
        }
        return Promise.reject(error);
    },
);

export default router;
