import App from '@src/app.vue';
import { Vue } from 'vue-property-decorator';
import router from './router';

if (module['hot']) {  
  module['hot'].accept();  
}  

new Vue({
  router,
  el: '#app',
  render: h => h(App),
});
