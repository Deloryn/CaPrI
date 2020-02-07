import { requestService } from '@src/services/requestService'

class AccountService {

    login(sessionAuthorizationKey: string) {
        return requestService.request("POST", "/account/login", { sessionAuthorizationKey: sessionAuthorizationKey})
            .then((response) => {
                if(response.status == 200) {
                    sessionStorage.setItem('token', response.data.securityStamp)
                }
                else {
                    console.log("failed to obtain token");
                }
            });
    }
}

export const accountService = new AccountService();