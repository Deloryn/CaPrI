<template>
	<v-dialog v-model="thesisData.show" :max-width="thesisData.maxWidth">
		<v-form class="whiteBackground">
			<v-container class="table">
				<v-row>
					<v-col
						v-for="popupElement in thesisData.data"
						:key="popupElement.text"
						:cols="popupElement.columns"
					>
						<component
							:is="popupElement.type"
							:elementData="popupElement"
						>
						</component>
					</v-col>
					<slot name="after"></slot>
				</v-row>
			</v-container>
		</v-form>
	</v-dialog>
</template>
<script lang="ts">
import { Vue, Component, Prop } from 'vue-property-decorator';
import textField from './popupFields/textField.vue';
import editableTextField from './popupFields/editableTextField.vue';
import textAreaField from './popupFields/textAreaField.vue';
import editableTextAreaField from './popupFields/editableTextAreaField.vue';
import selectableField from './popupFields/selectableField.vue';
import studentField from './popupFields/studentField.vue';

@Component({
    components: {
        textField,
        editableTextField,
        textAreaField,
        editableTextAreaField,
        selectableField,
        studentField,
    },
})
export default class Popup extends Vue {
    @Prop() public thesisData!: ['thesisData'];
    public data() {
        return {};
    }
}
</script>
<style scoped>
.table {
	background-color: #ffffff;
}
.closeButton {
	width: 25%;
	height: 64px;
	font-size: 24px;
	color: #ffffff;
	background-color: #ff0000;
}
</style>
