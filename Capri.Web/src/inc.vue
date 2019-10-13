<template>
    <div class="buttons-panel">
        <button @click="decrease">Decrease</button>
        <button @click="increase">Increase</button>
    </div>
</template>

<script lang="ts">
import { Vue, Component } from 'vue-property-decorator';
import { store } from './store/store';
import { ExampleModule } from './store/modules/exampleModule';

@Component
export default class Inc extends Vue {

    private decrease() {
        this.$store.dispatch('decrement');
    }
    private increase() {
        this.$store.dispatch('increment');
    }
}
</script>

<style lang="scss" scoped>

</style>