import App from '@src/app.vue';
import { Vue } from 'vue-property-decorator';
if (module['hot']) {
    module['hot'].accept();
}
new Vue({
    el: '#app',
    render: function (h) { return h(App); },
});
//# sourceMappingURL=app.js.map