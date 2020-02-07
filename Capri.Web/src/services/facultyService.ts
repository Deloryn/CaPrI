import { requestService } from '@src/services/requestService'

class FacultyService {
    public getAll() {
        return requestService.request("GET", "/faculties")
    }

    public get(id: string) {
        return requestService.request("GET", "/faculties/" + id)
    }
}

export const facultyService = new FacultyService();