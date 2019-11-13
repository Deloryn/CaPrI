import Vue from 'vue';
import Vuex from 'vuex';

import {ExampleModule} from './modules/exampleModule';

Vue.use(Vuex);

export const store =  new Vuex.Store({
    modules: {
        example: ExampleModule, // here you can add modules to the store
    },
});
