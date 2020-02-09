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
							<v-card-text v-if="sessionKeyAvailable">
								<span>{{ $i18n.t('commons.tryingToLogin') }}</span>
							</v-card-text>
							<v-card-text v-else>
								<a :href="eLogin">
									{{ $i18n.t('commons.loginViaElogin') }}
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
			eLogin: 'https://elogin.put.poznan.pl/?do=Authorize&system=capri.esys.put.poznan.pl',
			sessionKeyAvailable: false
		}
	},
	methods: {
		tryToLogin: function(sessionAuthorizationKey) {
			accountService.login(sessionAuthorizationKey)
				.then(x => {
					this.$router.push('/');
				});
		}
	},
	created() {
		var sessionAuthorizationKey = document.getElementById("sessionKey").value;
		if(sessionAuthorizationKey) {
			this.sessionKeyAvailable = true;
			this.tryToLogin(sessionAuthorizationKey);
		}
		else {
			this.sessionKeyAvailable = false;
		}
	}
});
</script>
<style lang="scss" scoped></style>
