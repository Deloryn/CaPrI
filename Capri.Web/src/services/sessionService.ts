import jwt_decode from 'jwt-decode';

const token = sessionStorage.token;
let parsedToken = JSON.parse('{ "role":""}');
if (token) {
    parsedToken = jwt_decode(token);
}

const sessionService = {
    token,
    parsedToken,
};

export default sessionService;
