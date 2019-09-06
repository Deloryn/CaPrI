import App from '@src/app.vue';
import { Vue } from 'vue-property-decorator';
import Vuetify from 'vuetify';
import 'vuetify/dist/vuetify.min.css';
import 'material-design-icons-iconfont/dist/material-design-icons.css';

Vue.use(Vuetify);

if (module['hot']) {  
  module['hot'].accept();  
}  

new Vue({
  el: '#app',
  vuetify: new Vuetify(),
  render: h => h(App),
});
