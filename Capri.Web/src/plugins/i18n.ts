import Vue from 'vue';
import VueI18n from 'vue-i18n';
import messages from '@src/translations';

Vue.use(VueI18n);
const i18n = new VueI18n({
	locale: 'pl',
	fallbackLocale: 'en',
	messages,
});

export default i18n;