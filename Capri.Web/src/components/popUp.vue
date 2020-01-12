<template>
	<v-dialog v-model="thesisData.show" :max-width="thesisData.maxWidth">
		<v-form class="whiteBackground">
			<v-container class="table">
				<v-row>
					<v-col
						v-for="popUpElement in thesisData.data"
						:key="popUpElement.text"
						:cols="popUpElement.columns"
					>
						<component
							:is="popUpElement.type"
							:elementData="popUpElement"
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
import textField from './popUpFields/textField.vue';
import editableTextField from './popUpFields/editableTextField.vue';
import textAreaField from './popUpFields/textAreaField.vue';
import editableTextAreaField from './popUpFields/editableTextAreaField.vue';
import selectableField from './popUpFields/selectableField.vue';
import studentField from './popUpFields/studentField.vue';

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
export default class PopUp extends Vue {
    @Prop() public thesisData!: ['thesisData'];
    public data() {
        return {};
    }
}
</script>
<style lang="scss" scoped>
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
