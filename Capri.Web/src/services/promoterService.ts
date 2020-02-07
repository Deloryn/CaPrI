import { requestService } from '@src/services/requestService'

class PromoterService {
    public getAll() {
        return requestService.request("GET", "/promoters")
    }

    public get(id: string) {
        return requestService.request("GET", "/promoters/" + id)
    }

    public getMyData() {
        return requestService.request("GET", "/promoters/mine");
    }

    public update(id: string, data={}) {
        return requestService.request("PUT", "/promoters/" + id, data)
    }
}

export const promoterService = new PromoterService();