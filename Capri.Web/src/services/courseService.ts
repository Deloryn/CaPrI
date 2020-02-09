import { requestService } from '@src/services/requestService'

class CourseService {
    public getAll() {
        return requestService.request("GET", "/courses")
    }

    public get(id: string) {
        return requestService.request("GET", "/courses/" + id)
    }
}

export const courseService = new CourseService();