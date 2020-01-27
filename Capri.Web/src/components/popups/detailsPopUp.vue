<template>
    <v-dialog 
		v-model="params.show"
		:max-width="params.maxWidth"
	>
		<v-form class="whiteBackground">
			<v-container class="table">
				<v-row>
					<v-col
						v-for="element in params.data"
						:key="element.label"
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


<script>
import { Vue, Component, Prop } from 'vue-property-decorator';
import textField from '@src/components/popups/popUpFields/textField.vue';
import editableTextField from '@src/components/popups/popUpFields/editableTextField.vue';
import textAreaField from '@src/components/popups/popUpFields/textAreaField.vue';
import editableTextAreaField from '@src/components/popups/popUpFields/editableTextAreaField.vue';
import selectableField from '@src/components/popups/popUpFields/selectableField.vue';
import studentField from '@src/components/popups/popUpFields/studentField.vue';

export default Vue.component('detailsPopUp', {
	props: {
		params: Object
	},
	components: {
        textField,
        editableTextField,
        textAreaField,
        editableTextAreaField,
        selectableField,
        studentField,
	}
})
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
