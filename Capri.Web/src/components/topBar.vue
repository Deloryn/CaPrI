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
			<div class="polish" @click="changeLocale('pl')"></div>
			<div class="english" @click="changeLocale('en')"></div>
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
import i18n from '../plugins/i18n';

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
			languages: [
                    { flag: 'polish', language: 'pl', title: 'Polski' },
                    { flag: 'english', language: 'en', title: 'English' }
             ],
        };
	}
	
	changeLocale(locale) {
		i18n.locale = locale;
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
	cursor: pointer;
}

.english {
	background-image: url('../assets/british-flag.svg');
	background-size: 100% 100%;
	margin: 10px;
	height: 25px;
	width: 50px;
	cursor: pointer;
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
