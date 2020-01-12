import App from '@src/app.vue';
import { Vue } from 'vue-property-decorator';
import Vuetify from 'vuetify';
import {store} from '@src/store/store.ts';
import 'vuetify/dist/vuetify.min.css';
import 'material-design-icons-iconfont/dist/material-design-icons.css';
import '@mdi/font/css/materialdesignicons.css';
import router from './router';
import axios from 'axios';
import VueAxios from 'vue-axios';

if (module.hot) {
    module.hot.accept();
}

Vue.use(Vuetify);
Vue.use(VueAxios, axios)

// tslint:disable-next-line:no-unused-expression
new Vue({
  router,
  el: '#app',
  vuetify: new Vuetify(),
  render: h => h(App),
});
