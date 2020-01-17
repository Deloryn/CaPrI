import App from '@src/app.vue';
import { Vue } from 'vue-property-decorator';
import Vuetify from 'vuetify';
import 'vuetify/dist/vuetify.min.css';
import '@mdi/font/css/materialdesignicons.css';
import router from './router';
if (module.hot) {
    module.hot.accept();
}
Vue.use(Vuetify);
// tslint:disable-next-line:no-unused-expression
new Vue({
    router: router,
    el: '#app',
    vuetify: new Vuetify(),
    render: function (h) { return h(App); },
});
//# sourceMappingURL=app.js.map