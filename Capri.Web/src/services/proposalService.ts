import { requestService } from '@src/services/requestService'
import { CrudService } from '@src/services/crudService'

class ProposalService extends CrudService {
    constructor() {
        super("/proposals")
    }
}

export const proposalService = new ProposalService();