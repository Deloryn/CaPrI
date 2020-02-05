import { requestService } from '@src/services/requestService'

class AccountService {

    login(email: string, password: string) {
        return requestService.request("POST", "/account/login", {
            email: email,
            password: password
        }).then((response) => 
        {
            console.log(response.data)
            sessionStorage.setItem('token', response.data.securityStamp)
        })
    }
}

export const accountService = new AccountService();