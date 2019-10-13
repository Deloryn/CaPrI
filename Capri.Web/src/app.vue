<template>
  <div id="app">
    <h1 class="test">Vue works!</h1>
    <Test></Test>
  </div>
</template>
<script lang="ts">
import { Vue, Component } from 'vue-property-decorator';
import Test from '@src/test.vue';

@Component({
  components: {
    Test
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

