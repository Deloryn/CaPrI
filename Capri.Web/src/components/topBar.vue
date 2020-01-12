<template>
	<v-card-actions class="mainCard">
		<div class="sentence">
			<strong>{{ listType }}</strong>
		</div>
		<v-spacer></v-spacer>
		<div class="headerElement">
			<div class="fontBar">
				<span class="fontChoose">
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
			<router-link to="/login" class="noTextDecoration">
				<v-avatar color="rgb(18,98,141)" class="icon" size="50">
					<v-icon color="#EEEEEE">person</v-icon>
				</v-avatar>
			</router-link>
		</div>
	</v-card-actions>
</template>

<script lang="ts">
import { Vue, Component, Prop } from 'vue-property-decorator';
import popup from './popup.vue';

@Component({
    components: {
        popup,
    },
})
export default class TopBar extends Vue {
    public data() {
        return {
            showPopup: false,
            listType: 'Thesis list',
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
.fontChoose {
	font-size: 18px;
	color: rgb(18, 98, 141);
}
.fontBar {
	width: 100px;
	text-align: center;
}
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
	background-image: url('../assets/british-flag.svg');
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
.noTextDecoration {
	text-decoration: none;
}
</style>
