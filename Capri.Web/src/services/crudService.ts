import { requestService } from '@src/services/requestService'

export abstract class CrudService {

    protected endpoint: string = "/baseendpoint"

    constructor(endpoint: string) {
        this.endpoint = endpoint;
    }

    public getAll() {
        return requestService.request("GET", this.endpoint)
    }

    public get(id: string) {
        return requestService.request("GET", this.endpoint + "/" + id)
    }

    public create(data={}) {
        return requestService.request("POST", this.endpoint, data)
    }

    public update(id: string, data={}) {
        return requestService.request("PUT", this.endpoint + "/" + id, data)
    }

    public delete(id: string) {
        return requestService.request("DELETE", this.endpoint + "/" + id)
    }
}