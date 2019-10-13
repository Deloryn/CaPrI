<template>
    <div class="counter-panel">
        Counter value: {{ totalCount }}
    </div>
</template>

<script lang="ts">
import { Vue, Component } from 'vue-property-decorator';
import { store } from './store/store';
import { ExampleModule } from './store/modules/exampleModule';

@Component
export default class Counter extends Vue {

    get totalCount(): number {
        return this.$store.state.example.count;
    }
}
</script>

<style lang="scss" scoped>

</style>