import { CrudService } from '@src/services/crudService'

class PromoterService extends CrudService {
    constructor() {
        super("/promoters")
    }
}

export const promoterService = new PromoterService();