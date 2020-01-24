import App from '@src/app.vue';
import { Vue } from 'vue-property-decorator';
import Vuetify from 'vuetify';
import 'vuetify/dist/vuetify.min.css';
import 'material-design-icons-iconfont/dist/material-design-icons.css';
import router from './router';
export const bus = new Vue();

if (module.hot) {
    module.hot.accept();
}

Vue.use(Vuetify);

new Vue({
    router,
    el: '#app',
    vuetify: new Vuetify(),
    render: h => h(App),
});
