using System.Linq;
using Microsoft.Extensions.Options;
using Sieve.Services;
using Sieve.Models;
using Capri.Database.Entities;

namespace Capri.Web.Configuration.Sieve
{
    public class CapriSieveProcessor : SieveProcessor
    {
        public CapriSieveProcessor(
            IOptions<SieveOptions> options) 
            : base(options)
        {
        }

        protected override SievePropertyMapper MapProperties(SievePropertyMapper mapper)
        {
            mapper.Property<Proposal>(p => p.TopicPolish)
                .CanFilter()
                .CanSort();

            mapper.Property<Proposal>(p => p.TopicEnglish)
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

            mapper.Property<Proposal>(p => p.StudentIndexNumbers.Count())
                .CanSort()
                .HasName("num_of_students");

            return mapper;
        }
    }
}