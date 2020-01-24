import { requestService } from '@src/services/requestService'
import { CrudService } from '@src/services/crudService'

class ProposalService extends CrudService {
    constructor() {
        super("/proposals")
    }

    public getMyProposals() {
        return requestService.request("GET", "/proposals/mine");
    }

    public getFiltered(sorts: string, filters: string, page: number, pageSize: number) {
        var queryString = "?sorts=" + sorts
                        + "&filters=" + filters
                        + "&page=" + page
                        + "&pageSize=" + pageSize
        return requestService.request("GET", "/proposals/filtered" + queryString)
    }

    public getCsv(id: string) {
        return requestService.request("GET", "/proposals/" + id + "/csv")
    }

    public calculateSubmittedBachelorProposals(promoterId: string) {
        return requestService.request("GET", "/proposals/submitted/bachelor/" + promoterId)
    }

    public calculateSubmittedMasterProposals(promoterId: string) {
        return requestService.request("GET", "/proposals/submitted/master/" + promoterId)
    }
}

export const proposalService = new ProposalService();