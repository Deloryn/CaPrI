<template>
	<v-app id="inspire">
		<v-content>
			<v-container class="fill-height" fluid>
				<v-row align="center" justify="center">
					<v-col cols="12" sm="8" md="4">
						<v-card class="elevation-12" v-if="sessionKeyAvailable">
							<v-toolbar color="primary" dark flat>
								<v-toolbar-title>CaPri Login</v-toolbar-title>
								<div class="flex-grow-1"></div>
							</v-toolbar>
							<v-card-text>
								<span>{{ $i18n.t('commons.tryingToLogin') }}</span>
							</v-card-text>
						</v-card>
						<div v-else>
							<v-card class="elevation-12">
								<v-toolbar color="primary" dark flat>
									<v-toolbar-title>CaPri Login</v-toolbar-title>
									<div class="flex-grow-1"></div>
								</v-toolbar>
								<v-card-text>
									<input style="background-color: lightgrey; color: black" type="text" name="email" v-model="input.email" :placeholder="$i18n.t('commons.email')" />
									<input style="background-color: lightgrey; color: black" type="password" name="password" v-model="input.password" :placeholder="$i18n.t('commons.password')" />
									<button type="button" v-on:click="tryToLoginDirectly" v-text="$i18n.t('commons.login')" />
								</v-card-text>
								<v-card-text>
									<a :href="eLogin">
										{{ $i18n.t('commons.loginViaElogin') }}
									</a>
								</v-card-text>
							</v-card>
						</div>
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
			sessionKeyAvailable: false,
			input: {
                    email: "",
                    password: ""
            }
		}
	},
	methods: {
		tryToLogin: function(sessionAuthorizationKey) {
			accountService.login(sessionAuthorizationKey)
				.then(x => {
					this.$router.push('/');
				});
		},
		tryToLoginDirectly: function() {
			accountService.loginWithPassword(this.input.email, this.input.password)
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
