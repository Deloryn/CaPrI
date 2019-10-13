import App from '@src/app.vue';
import { Vue } from 'vue-property-decorator';
import { store } from '@src/store/store.ts';
if (module['hot']) {
    module['hot'].accept();
}
new Vue({
    el: '#app',
    store: store,
    render: function (h) { return h(App); },
});
//# sourceMappingURL=app.js.map