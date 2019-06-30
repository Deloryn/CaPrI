<template>
  <div>
    <h1 class="test1">Test Comp</h1>
    <img src="@src/assets/testimage.jpg" />
  </div>
</template>
<script lang="ts">
import { Vue, Component, Prop } from 'vue-property-decorator';

@Component
export default class Test extends Vue {

}
</script>
<style lang="scss" scoped>
.test1 {
  color: #555555;
}
</style>

