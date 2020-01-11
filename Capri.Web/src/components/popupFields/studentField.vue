<template>
	<div>
		<v-row>
			<v-col
				cols="6"
				v-for="student in elementData.students"
				:key="student"
			>
				<v-text-field :value="student" :label="elementData.label">
				</v-text-field>
			</v-col>
			<span
				v-if="elementData.students.length < elementData.max"
				@click="elementData.students.push('')"
				class="click"
			>
				<v-icon class="iconPosition">mdi-plus-box</v-icon>Add a new
				student
			</span>
		</v-row>
	</div>
</template>
<script lang="ts">
import { Vue, Component, Prop } from 'vue-property-decorator';

@Component({
    components: {},
})
export default class StudentField extends Vue {
    @Prop() public elementData!: ['elementData'];
}
</script>
<style scoped>
.click {
	cursor: pointer;
	margin-left: 8px;
}
.iconPosition {
	margin-bottom: 6px;
}
</style>
