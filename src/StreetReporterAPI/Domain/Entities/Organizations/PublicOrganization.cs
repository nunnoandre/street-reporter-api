using StreetReporterAPI.Domain.Entities.Incidents;
using System.ComponentModel.DataAnnotations.Schema;

namespace StreetReporterAPI.Domain.Entities.Organizations
{
    public class PublicOrganization
    {
        public required uint Id {  get; set; }
        public required string Name { get; set; }

        [ForeignKey(nameof(PublicOrganizationType))]
        public required PublicOrganizationTypeEnum TypeId { get; set; }
    }
}
