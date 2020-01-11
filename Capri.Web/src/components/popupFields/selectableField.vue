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

@Component({
    components: {},
})
export default class SelectableField extends Vue {
    @Prop() public elementData!: ['elementData'];
}
</script>
<style scoped></style>
