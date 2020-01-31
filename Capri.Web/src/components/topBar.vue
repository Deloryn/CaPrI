<template>
	<v-card-actions class="mainCard">
		<div class="sentence">
			<strong>{{ listType }}</strong>
		</div>
		<v-spacer></v-spacer>
		<div class="headerElement">
			<div class="polish" @click="changeLocale('pl')" />
			<div class="english" @click="changeLocale('en')" />
		</div>

		<div class="headerElement">
			<div @click="logout()" class="noTextDecoration">
				<v-avatar color="rgb(18,98,141)" class="icon" size="50">
					<v-icon color="#EEEEEE">person</v-icon>
				</v-avatar>
			</div>
		</div>
	</v-card-actions>
</template>

<script lang="ts">
import { Vue, Component, Prop } from 'vue-property-decorator';
import { bus } from '@src/services/eventBus'

export default Vue.component('topBar', {
	data() {
		return {
            showpopUp: false,
            listType: 'Thesis list',
            fontSize: { font: 12 },
            items: [
                { font: 8 },
                { font: 12 },
                { font: 16 },
                { font: 20 },
                { font: 24 },
			],
        }
	},
	methods: {
		logout: function() {
			sessionStorage.removeItem('token')
			this.$router.push('/login')
		},
		changeLocale: function(locale) {
			this.$i18n.locale = locale;
			bus.$emit('languageChanged');
		}
	},
});

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
	background-image: url('../assets/british-flag.svg');
	background-size: 100% 100%;
	margin: 10px;
	height: 25px;
	width: 50px;
}
.noTextDecoration {
	text-decoration: none;
}
</style>
