import jwt_decode from 'jwt-decode';

class sessionService {
    token: string;
    parsedToken: {};
    constructor() {
        this.token = sessionStorage.token;
        this.parsedToken = JSON.parse('{ "role":""}');
        if (this.token) {
            this.parsedToken = jwt_decode(this.token);
        } 
    }
}

export default sessionService;