import App from '@src/app.vue';
import { Vue } from 'vue-property-decorator';
import Vuetify from 'vuetify';
import 'vuetify/dist/vuetify.min.css';
import 'material-design-icons-iconfont/dist/material-design-icons.css';
import '@mdi/font/css/materialdesignicons.css';
import router from './router';
Vue.use(Vuetify);
if (module['hot']) {
    module['hot'].accept();
}
// tslint:disable-next-line:no-unused-expression
new Vue({
    router: router,
    // tslint:disable-next-line: object-literal-sort-keys
    el: '#app',
    vuetify: new Vuetify(),
    render: function (h) { return h(App); },
});
//# sourceMappingURL=app.js.map