import App from '@src/app.vue';
import { Vue } from 'vue-property-decorator';

if (module['hot']) {  
  module['hot'].accept();  
}  

new Vue({
  el: '#app',
  render: h => h(App),
});
