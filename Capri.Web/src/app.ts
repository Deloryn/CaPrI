import App from '@src/app.vue';
import { Vue } from 'vue-property-decorator';
import Vuetify from 'vuetify';
import {store} from '@src/store/store.ts';
import 'vuetify/dist/vuetify.min.css';
import 'material-design-icons-iconfont/dist/material-design-icons.css';
import '@mdi/font/css/materialdesignicons.css';
import router from './router';
import i18n from './plugins/i18n';

if (module.hot) {
    module.hot.accept();
}

Vue.use(Vuetify);

// tslint:disable-next-line:no-unused-expression
new Vue({
  i18n,
  router,
  el: '#app',
  vuetify: new Vuetify(),
  render: h => h(App),
});
