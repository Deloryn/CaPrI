<template>
	<v-textarea :value="elementData.text" :label="elementData.label" readonly>
	</v-textarea>
</template>
<script lang="ts">
import { Vue, Component, Prop } from 'vue-property-decorator';

@Component({
    components: {},
})
export default class TextAreaField extends Vue {
    @Prop() public elementData!: ['elementData'];
}
</script>
<style scoped></style>
