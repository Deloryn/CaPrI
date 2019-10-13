import Vue from 'vue';
import Vuex from 'vuex';

//example template of a module to show how it works
//remove it or replace with your own data
export const ExampleModule = {
    state: {
        count: 5,
    },
    mutations: {    //synchronous change
        increment(state) {
            state.count += 1;
        },
        decrement(state) {
            state.count -= 1;
        },
    },
    actions: {      //asynchronous change
        increment(context) {
            context.commit('increment');
        },
        decrement(context) {
            context.commit('decrement');
        }
    },
    getters: {

    },
};
