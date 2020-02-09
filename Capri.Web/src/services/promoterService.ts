import { requestService } from '@src/services/requestService'

class PromoterService {
    
    public count(sorts: string, filters: string) {
        var queryString = "?sorts=" + sorts
                        + "&filters=" + filters
        return requestService.request("GET", "/promoters/filtered/total" + queryString)
    }

    public getFiltered(sorts: string, filters: string, page: number, pageSize: number) {
        var queryString = "?sorts=" + sorts
                        + "&filters=" + filters
                        + "&page=" + page
                        + "&pageSize=" + pageSize
        return requestService.request("GET", "/promoters/filtered" + queryString)
    }

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

    public exportPromoters() {
        return requestService.requestFile("GET", "/promoters/export");
    }

    public importPromoters(file) {
        return requestService.requestFile("POST", "/promoters/import", file);
    }
}

export const promoterService = new PromoterService();