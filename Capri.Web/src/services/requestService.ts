import { Vue } from 'vue-property-decorator';
import { Method } from 'axios';

class RequestService {
    private serverAddres: string = "https://capri.cs.put.poznan.pl";

    public request(method: string, api: string, data={}) {
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

    public requestFile(method: string, api: string, data = null) {
        const token = sessionStorage.token;
        return Vue.axios.request({
            url: this.serverAddres + api,
            method: method as Method,
            data: data,
            responseType: method.toLowerCase().includes('get') ? 'blob' : 'json',
            headers: {
                'Authorization': 'Bearer ' + token
            }
        })
    }
}

export const requestService = new RequestService();