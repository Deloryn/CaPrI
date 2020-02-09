import { requestService } from '@src/services/requestService'

class AccountService {

    public login(sessionAuthorizationKey: string) {
        return requestService.request("POST", "/account/login", { sessionAuthorizationKey: sessionAuthorizationKey})
            .then((response) => {
                if(response.status == 200) {
                    // sessionStorage.setItem('token', response.data.securityStamp)
                    // sessionStorage.setItem('token', 'eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6IjUwNjEiLCJyb2xlIjoiRGVhbiIsIm5iZiI6MTU4MTE4MzczNywiZXhwIjoxNTgxNzg4NTM3LCJpYXQiOjE1ODExODM3MzcsImlzcyI6ImVtcHR5Q29tcGFueSJ9.xqctA1A33a390ksoZnNiaYfGVWpPN-oaOWfDnRpr-Q0');
                    sessionStorage.setItem('token', 'eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6IjE1MDkiLCJyb2xlIjoiUHJvbW90ZXIiLCJuYmYiOjE1ODExODM4MDYsImV4cCI6MTU4MTc4ODYwNiwiaWF0IjoxNTgxMTgzODA2LCJpc3MiOiJlbXB0eUNvbXBhbnkifQ.A1PqPuP7YpsXtpqAoHpAEIpc6NeJ09vb1d_ExVSbuNE')
                }
            });
    }

    public logout() {
        return requestService.request("GET", "/account/logout");
    }
}

export const accountService = new AccountService();