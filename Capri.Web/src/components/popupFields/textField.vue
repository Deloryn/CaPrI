<template>
	<v-text-field :value="elementData.text" :label="elementData.label" readonly>
	</v-text-field>
</template>
<script lang="ts">
import { Vue, Component, Prop } from 'vue-property-decorator';
import IPopUpData from '../../models/popUp';

@Component
export default class TextField extends Vue {
    @Prop() public elementData!: IPopUpData;
}
</script>
<style lang="scss" scoped>
</style>
