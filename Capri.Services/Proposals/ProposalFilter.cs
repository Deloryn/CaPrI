using System;
using System.Collections.Generic;
using System.Linq;
using Capri.Database.Entities;
using Capri.Web.ViewModels.Proposal;

namespace Capri.Services.Proposals
{
    public class ProposalFilter : IProposalFilter
    {
        public IServiceResult<IEnumerable<Proposal>> Filter(
            ProposalFilterModel filter,
            IEnumerable<Proposal> proposals)
        {
            
            var p1 = FilterByTitle(proposals, filter.Title);
            var p2 = FilterByPromoterLastName(p1, filter.PromoterLastName);
            var p3 = FilterByStudyLevel(p2, filter.Level);
            var p4 = FilterByStudyMode(p3, filter.Mode);
            var p5 = FilterByStatus(p4, filter.Status);

            var paginated = Paginate(p5, filter.Page, filter.Limit);
            var sorted = Sort(paginated, filter.SortBy, filter.Order);

            return ServiceResult<IEnumerable<Proposal>>.Success(sorted);
        }

        private IEnumerable<Proposal> FilterByTitle(IEnumerable<Proposal> proposals, string title)
        {
            return proposals.Where(p => 
                p.Topic.StartsWith(
                    title ?? string.Empty, 
                    StringComparison.InvariantCultureIgnoreCase));
        }

        private IEnumerable<Proposal> FilterByPromoterLastName(
            IEnumerable<Proposal> proposals, 
            string promoterLastName)
            {
                if(promoterLastName == null)
                {
                    return proposals;
                }
                return proposals
                    .Where(p => p.Promoter.LastName.StartsWith(promoterLastName));
            }

        private IEnumerable<Proposal> FilterByStudyLevel(IEnumerable<Proposal> proposals, string level) {
            if(level == null)
            {
                return proposals;
            }
            switch(level)
            {
                case "bachelor":
                    return proposals.Where(p => p.Status.Equals(StudyLevel.Bachelor));
                case "master":
                    return proposals.Where(p => p.Status.Equals(StudyLevel.Master));
                default:
                    return proposals;
            }
        }

        private IEnumerable<Proposal> FilterByStudyMode(IEnumerable<Proposal> proposals, string mode) {
            if(mode == null)
            {
                return proposals;
            }
            switch(mode)
            {
                case "fulltime":
                    return proposals.Where(p => p.Status.Equals(StudyMode.FullTime));
                case "parttime":
                    return proposals.Where(p => p.Status.Equals(StudyMode.PartTime));
                default:
                    return proposals;
            }
        }

        private IEnumerable<Proposal> FilterByStatus(IEnumerable<Proposal> proposals, string status) {
            if(status == null)
            {
                return proposals;
            }
            switch(status)
            {
                case "free":
                    return proposals.Where(p => p.Status.Equals(ProposalStatus.Free));
                case "partiallytaken":
                    return proposals.Where(p => p.Status.Equals(ProposalStatus.PartiallyTaken));
                case "taken":
                    return proposals.Where(p => p.Status.Equals(ProposalStatus.Taken));
                default:
                    return proposals;
            }
        }

        private IEnumerable<Proposal> Sort(IEnumerable<Proposal> proposals, string sortBy, string order) {
            if(sortBy == null)
            {
                return proposals;
            }
            else if(order == null)
            {
                order = "asc";
            }
            switch(sortBy)
            {
                case "title":
                    if(order.Equals("desc"))
                    {
                        return proposals.OrderByDescending(p => p.Topic);
                    }
                    return proposals.OrderBy(p => p.Topic);

                case "status":
                    if(order.Equals("desc"))
                    {
                        return proposals.OrderByDescending(p => p.Status);
                    }
                    return proposals.OrderBy(p => p.Status);
                
                case "type":
                    if(order.Equals("desc"))
                        {
                            return proposals.OrderByDescending(p => p.Level);
                        }
                        return proposals.OrderBy(p => p.Level);

                case "students":
                    if(order.Equals("desc"))
                            {
                                return proposals.OrderByDescending(p => p.Students.Count);
                            }
                            return proposals.OrderBy(p => p.Students.Count);

                case "promoterlastname":
                    if(order.Equals("desc"))
                            {
                                return proposals.OrderByDescending(p => p.Promoter.LastName);
                            }
                            return proposals.OrderBy(p => p.Promoter.LastName);

                default:
                    return proposals;
            }
        }

        private IEnumerable<Proposal> Paginate(
            IEnumerable<Proposal> proposals, 
            int pageNumber, 
            int pageLimit)
        {
            if(pageNumber.Equals(0) && pageLimit.Equals(0))
            {
                return proposals;
            }

            return proposals
                .Skip((pageNumber-1)*pageLimit)
                .Take(pageLimit);
        }
    
    }
}