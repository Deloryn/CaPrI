<template>
	<v-text-field :value="elementData.text" :label="elementData.label">
	</v-text-field>
</template>
<script lang="ts">
import { Vue, Component, Prop } from 'vue-property-decorator';

@Component({
    components: {},
})
export default class EditableTextField extends Vue {
    @Prop() public elementData!: ['elementData'];
}
</script>
<style scoped></style>
