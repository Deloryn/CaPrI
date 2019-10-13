<template>
  <div id="app">
    <h1 class="test">Vue works!</h1>
    <Test></Test>
    <Counter></Counter>
    <Inc></Inc>
  </div>
</template>
<script lang="ts">
import { Vue, Component } from 'vue-property-decorator';
import Test from '@src/test.vue';
import Counter from '@src/counter.vue';
import Inc from '@src/inc.vue';

@Component({
  components: {
    Test,
    Counter,
    Inc,
  }
})
export default class App extends Vue {
    readonly imagePath: string = '/assets/testImage.jpg';
}
</script>
<style lang="scss" scoped>
.test {
  color: #555555;
}
</style>

