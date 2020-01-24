<template>
    <v-dialog 
        v-model="popup.show"
        :max-width="popup.maxWidth"
    >
		<v-form class="whiteBackground">
			<v-container class="table">
				<v-row>
					<v-col
						v-for="element in popup.data"
						:key="element.text"
						:cols="element.columns"
					>
						<component
							:is="element.type"
							:elementData="element"
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
import textField from '@src/components/popUpFields/textField.vue';
import editableTextField from '@src/components/popUpFields/editableTextField.vue';
import textAreaField from '@src/components/popUpFields/textAreaField.vue';
import editableTextAreaField from '@src/components/popUpFields/editableTextAreaField.vue';
import selectableField from '@src/components/popUpFields/selectableField.vue';
import studentField from '@src/components/popUpFields/studentField.vue';

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
export default class DisplayDetailsPopUp extends Vue {
    @Prop() public popup!: ['popup'];
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
