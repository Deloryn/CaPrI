<template>
  <div>
    <h1 class="test1">Test Comp 2</h1>
  </div>
</template>
<script lang="ts">
import { Vue, Component, Prop } from 'vue-property-decorator';

@Component
export default class Test2 extends Vue {

}
</script>
<style lang="scss" scoped>
.test1 {
  color: #F00;
}
</style>

