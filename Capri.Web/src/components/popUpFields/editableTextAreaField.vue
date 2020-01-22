<template>
	<v-textarea :value="elementData.text" :label="elementData.label">
	</v-textarea>
</template>
<script lang="ts">
import { Vue, Component, Prop } from 'vue-property-decorator';

@Component({
    components: {},
})
export default class EditableTextAreaField extends Vue {
    @Prop() public elementData!: ['elementData'];
}
</script>
<style lang="scss" scoped>
</style>
