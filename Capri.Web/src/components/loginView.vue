<template>
	<v-app id="inspire">
		<v-content>
			<v-container class="fill-height" fluid>
				<v-row align="center" justify="center">
					<v-col cols="12" sm="8" md="4">
						<v-card class="elevation-12">
							<v-toolbar color="primary" dark flat>
								<v-toolbar-title>CaPri Login</v-toolbar-title>
								<div class="flex-grow-1"></div>
							</v-toolbar>
							<v-card-text>
								<a :href="eLogin">
									<img src="/img/eLoginLogo.png" alt="login via eLogin"/>
								</a>
							</v-card-text>
						</v-card>
					</v-col>
				</v-row>
			</v-container>
		</v-content>
	</v-app>
</template>
<script>
import { Vue } from 'vue-property-decorator';
import { accountService } from '@src/services/accountService'

export default Vue.component('loginPanel', {
	data() {
		return {
			eLogin: 'https://elogin.put.poznan.pl/?do=Authorize&system=capri.esys.put.poznan.pl'
		}
	},
	methods: {
		tryToLogin: function() {
			console.log(this.$route);
			var sessionAuthorizationKey = document.getElementById("sessionKey").value;
			if(sessionAuthorizationKey) {
				accountService.login(sessionAuthorizationKey)
					.then(x => {
						this.$router.push('/');
					});
			}
		}
	},
	created() {
		this.tryToLogin();
	}
});
</script>
<style lang="scss" scoped></style>
