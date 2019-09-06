<template>
  <v-app id="app">
    <LoginPanel></LoginPanel>
  </v-app>
</template>
<script lang="ts">
import { Vue, Component } from 'vue-property-decorator';
import Test from '@src/test.vue';
import LoginPanel from '@src/loginPanel.vue';


@Component({
  components: {
    Test,
    LoginPanel
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

