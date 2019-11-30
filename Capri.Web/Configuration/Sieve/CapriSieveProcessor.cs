using Microsoft.Extensions.Options;
using Sieve.Services;
using Sieve.Models;
using Capri.Database.Entities;

namespace Capri.Web.Configuration.Sieve
{
    public class CapriSieveProcessor : SieveProcessor
    {
        public CapriSieveProcessor(
            IOptions<SieveOptions> options, 
            ISieveCustomSortMethods customSortMethods, 
            ISieveCustomFilterMethods customFilterMethods) 
            : base(options, customSortMethods, customFilterMethods)
        {
        }

        protected override SievePropertyMapper MapProperties(SievePropertyMapper mapper)
        {
            mapper.Property<Proposal>(p => p.Topic)
                .CanFilter()
                .CanSort();

            mapper.Property<Proposal>(p => p.Status)
                .CanFilter()
                .CanSort();
            
            mapper.Property<Proposal>(p => p.Mode)
                .CanFilter()
                .CanSort();
            
            mapper.Property<Proposal>(p => p.Level)
                .CanFilter()
                .CanSort();

            mapper.Property<Proposal>(p => p.Promoter.LastName)
                .CanFilter()
                .CanSort()
                .HasName("promoter_lastname");

            mapper.Property<Proposal>(p => p.Students.Count)
                .CanSort()
                .HasName("num_of_students");

            return mapper;
        }
    }
}