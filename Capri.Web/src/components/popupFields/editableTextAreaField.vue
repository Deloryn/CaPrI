<template>
	<v-textarea :value="elementData.text" :label="elementData.label">
	</v-textarea>
</template>
<script lang="ts">
import { Vue, Component, Prop } from 'vue-property-decorator';
import IPopUpData from '../../models/popUp';

@Component
export default class EditableTextAreaField extends Vue {
    @Prop() public elementData!: IPopUpData;
}
</script>
<style lang="scss" scoped>
</style>
