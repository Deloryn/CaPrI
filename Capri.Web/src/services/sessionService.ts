import jwt_decode from 'jwt-decode';

export default class SessionService {
    public getParsedToken(): object {
        const token = sessionStorage.token;
        let parsedToken = JSON.parse('{ "role":""}');
        if (token) {
            parsedToken = jwt_decode(token);
        }
        return parsedToken;
    }
}