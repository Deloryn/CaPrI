import { requestService } from '@src/services/requestService'

class AccountService {

    public login(sessionAuthorizationKey: string) {
        return requestService.request("POST", "/account/login", { sessionAuthorizationKey: sessionAuthorizationKey })
            .then((response) => {
                if(response.status == 200) {
                    sessionStorage.setItem('token', response.data.securityStamp);
                }
            });
    }

    public loginWithPassword(email: string, password: string) {
        return requestService.request("POST", "/account/login/direct", { email: email, password: password })
            .then((response => {
                if(response.status == 200) {
                    sessionStorage.setItem('token', response.data.securityStamp);
                }
            }));
    }

    public logout() {
        return requestService.request("GET", "/account/logout");
    }
}

export const accountService = new AccountService();