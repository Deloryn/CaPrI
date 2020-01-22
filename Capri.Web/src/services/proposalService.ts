import { requestService } from '@src/services/requestService'
import { CrudService } from '@src/services/crudService'

class ProposalService extends CrudService {
    constructor() {
        super("/proposals")
    }

    public getFiltered(params: string) {
        return requestService.request("GET", "/proposals/filtered?" + params)
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