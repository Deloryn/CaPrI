import { Vue } from 'vue-property-decorator';
import { Method } from 'axios';

class RequestService {
    private serverAddres: string = "http://localhost:5000";
    request(method: string, api: string, data={}) {
        const token = sessionStorage.token;
        return Vue.axios.request({
            url: this.serverAddres + api,
            method: method as Method,
            data: data,
            headers: {
                'Authorization': 'Bearer ' + token
            }
        })
    }
}

export const requestService = new RequestService();