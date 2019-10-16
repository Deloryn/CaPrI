import Vue from 'vue';
import Router from 'vue-router';
import Test from './test.vue';

Vue.use(Router);

export default new Router({
	mode: 'history',
	base: process.env.BASE_URL,
	routes: [
		{
			path: '/',
			name: 'test',
			component: Test,
		},
		{
			path: '/test',
			name: 'test',
			component: () => import('./test2.vue'),
		},
	],
});
