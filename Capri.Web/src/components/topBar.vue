<template>
	<v-card-actions class="mainCard">
		<div class="sentence">
			<strong>{{ listType }}</strong>
		</div>
		<v-spacer></v-spacer>
		<div class="headerElement">
			<div style="width: 100px; text-align: center;">
				<span style="font-size: 18px; color: rgb(18,98,141);">
					<strong>Font size</strong>
				</span>
				<v-select
					v-model="fontSize"
					:items="items"
					item-text="font"
					item-value="font"
					return-object
					class="selectStyle"
				></v-select>
			</div>
		</div>
		<div class="headerElement">
			<div class="polish"></div>
			<div class="english"></div>
		</div>

		<div class="headerElement">
			<router-link to="/" style="text-decoration: none;">
				<v-avatar color="rgb(18,98,141)" class="icon" size="50">
					<v-icon color="#EEEEEE">person</v-icon>
				</v-avatar>
			</router-link>
		</div>
	</v-card-actions>
</template>

<script lang="ts">
import { Vue, Component, Prop } from 'vue-property-decorator';

@Component
export default class TopBar extends Vue {
    public data() {
        return {
            listType: 'Bachelor thesis',
            fontSize: { font: 12 },
            items: [
                { font: 8 },
                { font: 12 },
                { font: 16 },
                { font: 20 },
                { font: 24 },
            ],
        };
    }
}
</script>
<style lang="scss" scoped>
.mainCard {
	margin-left: 340px;
	width: calc(100% - 340px);
	padding-left: 10px;
	padding-right: 10px;
	padding-top: 25px;
}
.sentence {
	font-size: 40px;
	color: rgb(18, 98, 141);
}
.headerElement {
	margin-left: 32px;
}
.icon {
	color: #000000;
	font-size: 50px;
	margin-right: 20px;
}
.polish {
	margin: 10px;
	height: 25px;
	width: 50px;
	background: linear-gradient(to bottom, #ffffff 50%, #d4213d 50%);
}

.english {
	background: url('data:image/svg+xml;base64,PHN2ZyB3aWR0aD0iMTIwMCIgeG1sbnM9Imh0dHA6Ly93d3cudzMub3JnLzIwMDAvc3ZnIiB2aWV3Qm94PSIwIDAgNjAgMzAiIGhlaWdodD0iNjAwIj4NCjxkZWZzPg0KPGNsaXBQYXRoIGlkPSJ0Ij4NCjxwYXRoIGQ9Im0zMCwxNWgzMHYxNXp2MTVoLTMwemgtMzB2LTE1enYtMTVoMzB6Ii8+DQo8L2NsaXBQYXRoPg0KPC9kZWZzPg0KPHBhdGggZmlsbD0iIzAwMjQ3ZCIgZD0ibTAsMHYzMGg2MHYtMzB6Ii8+DQo8cGF0aCBzdHJva2U9IiNmZmYiIHN0cm9rZS13aWR0aD0iNiIgZD0ibTAsMGw2MCwzMG0wLTMwbC02MCwzMCIvPg0KPHBhdGggc3Ryb2tlPSIjY2YxNDJiIiBzdHJva2Utd2lkdGg9IjQiIGQ9Im0wLDBsNjAsMzBtMC0zMGwtNjAsMzAiIGNsaXAtcGF0aD0idXJsKCN0KSIvPg0KPHBhdGggc3Ryb2tlPSIjZmZmIiBzdHJva2Utd2lkdGg9IjEwIiBkPSJtMzAsMHYzMG0tMzAtMTVoNjAiLz4NCjxwYXRoIHN0cm9rZT0iI2NmMTQyYiIgc3Ryb2tlLXdpZHRoPSI2IiBkPSJtMzAsMHYzMG0tMzAtMTVoNjAiLz4NCjwvc3ZnPg0K');
	background-size: 100% 100%;
	margin: 10px;
	height: 25px;
	width: 50px;
}

.selectStyle {
	background-color: #ffffff;
	padding: 0px;
	width: 56px;
	height: 32px;
	text-decoration-style: none;
	display: inline-block;
}
</style>
