import Vue from 'vue';
import Router from 'vue-router';
import loginView from './components/loginView.vue';
import proposalsView from './components/proposalsView.vue';
import myProposalsView from './components/myProposalsView.vue';
import promotersView from './components/promotersView.vue'
import axios from 'axios';
import VueAxios from 'vue-axios';

Vue.use(Router);
Vue.use(VueAxios, axios);

const router = new Router({
    mode: 'history',
    routes: [
        { path: '/login', component: loginView },
        { path: '/view/proposals', component: proposalsView },
        { path: '/view/my_proposals', component: myProposalsView },
        { path: '/view/promoters', component: promotersView },
        { path: '/', component: proposalsView },
    ],
});

router.beforeEach((to, from, next) => {
    if (to.path !== '/login' && !sessionStorage.token) {
        next('/login');
    }
    else {
        next();
    }
});

router.afterEach((to, from) => {
    console.log("From: ");
    console.log(from);
    console.log("=======")
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