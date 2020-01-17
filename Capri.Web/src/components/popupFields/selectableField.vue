<template>
	<v-select
		:items="elementData.items"
		:label="elementData.label"
		:model="elementData.chosen"
		:value="elementData.chosen"
	>
	</v-select>
</template>
<script lang="ts">
import { Vue, Component, Prop } from 'vue-property-decorator';
import IPopUpData from '../../models/popUp'

@Component
export default class SelectableField extends Vue {
    @Prop() public elementData!: IPopUpData;
}
</script>
<style lang="scss" scoped>
</style>

