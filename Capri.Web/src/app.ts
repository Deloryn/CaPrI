import App from '@src/app.vue';
import { Vue } from 'vue-property-decorator';
import store from '@src/store.ts';

if (module['hot']) {  
  module['hot'].accept();  
}  

new Vue({
    el: '#app',
    store,
    render: h => h(App),
});
