import { requestService } from '@src/services/requestService'

class ProposalService {

    public create(data={}) {
        return requestService.request("POST", "/proposals", data)
    }

    public update(id: string, data={}) {
        return requestService.request("PUT", "/proposals/" + id, data)
    }

    public delete(id: string) {
        return requestService.request("DELETE", "/proposals/" + id)
    }

    public getAll() {
        return requestService.request("GET", "/proposals")
    }

    public get(id: string) {
        return requestService.request("GET", "/proposals/" + id)
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

    public getDiplomaCard(id: string) {
        return requestService.requestFile("GET", "/proposals/" + id + "/docx")
    }

    public calculateSubmittedBachelorProposals(promoterId: string) {
        return requestService.request("GET", "/proposals/submitted/bachelor/" + promoterId)
    }

    public calculateSubmittedMasterProposals(promoterId: string) {
        return requestService.request("GET", "/proposals/submitted/master/" + promoterId)
    }
}

export const proposalService = new ProposalService();