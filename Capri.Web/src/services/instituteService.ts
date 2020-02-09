import { requestService } from '@src/services/requestService'

class InstituteService {
    public getAll() {
        return requestService.request("GET", "/institutes")
    }

    public get(id: string) {
        return requestService.request("GET", "/institutes/" + id)
    }
}

export const instituteService = new InstituteService();