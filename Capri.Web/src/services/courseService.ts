import { CrudService } from '@src/services/crudService'

class CourseService extends CrudService {
    constructor() {
        super("/courses")
    }
}

export const courseService = new CourseService();