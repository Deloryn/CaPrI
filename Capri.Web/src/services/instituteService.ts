import { CrudService } from '@src/services/crudService'

class InstituteService extends CrudService {
    constructor() {
        super("/institutes")
    }
}

export const instituteService = new InstituteService();