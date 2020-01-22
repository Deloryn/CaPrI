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
								<v-form>
									<v-text-field
										label="Login"
										name="login"
										prepend-icon="person"
										type="text"
                                        v-model="userData.email"
									></v-text-field>

									<v-text-field
										id="password"
										label="Password"
										name="password"
										prepend-icon="lock"
										type="password"
                                        v-model="userData.password"
									></v-text-field>
								</v-form>
							</v-card-text>
							<v-card-actions>
								<div class="flex-grow-1"></div>
								<v-btn color="primary"
                                       @click="tryToLog(userData.email,userData.password)"
                                       @keyup.enter="tryToLog(userData.email,userData.password)"
                                       >Login</v-btn>
							</v-card-actions>
						</v-card>
					</v-col>
				</v-row>
			</v-container>
		</v-content>
	</v-app>
</template>
<script lang="ts">
import { Vue, Component, Prop } from 'vue-property-decorator';
import { accountService } from '@src/services/accountService'

@Component
export default class LoginPanel extends Vue {
    public userData = {
        email: '',
        password: ''
    };
    public tryToLog(email, password) {
		accountService
			.login(email, password)
			.then((response) => 
			{
				this.$router.push('/Home/Index')
        	})
    }
}
</script>
<style lang="scss" scoped></style>
