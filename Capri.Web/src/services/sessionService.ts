import jwt_decode from 'jwt-decode';

const token = sessionStorage.token;
let parsedToken = JSON.parse('{ "role":""}');
if (token) {
    parsedToken = jwt_decode(token);
}

var sessionService = {
    token,
    parsedToken,
};

export default sessionService;