import { requestService } from '@src/services/requestService'
import { CrudService } from '@src/services/crudService'

class PromoterService extends CrudService {
    constructor() {
        super("/promoters")
    }

    public getMyData() {
        return requestService.request("GET", "/promoters/mine");
    }
}

export const promoterService = new PromoterService();