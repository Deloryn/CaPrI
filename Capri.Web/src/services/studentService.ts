import { CrudService } from '@src/services/crudService'

class StudentService extends CrudService {
    constructor() {
        super("/students")
    }
}

export const studentService = new StudentService();