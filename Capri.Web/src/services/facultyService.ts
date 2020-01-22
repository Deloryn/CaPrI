import { CrudService } from '@src/services/crudService'

class FacultyService extends CrudService {
    constructor() {
        super("/faculties")
    }
}

export const facultyService = new FacultyService();