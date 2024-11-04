using StreetReporterAPI.Domain.Entities.Incidents;
using System.ComponentModel.DataAnnotations.Schema;

namespace StreetReporterAPI.Domain.Entities.Organizations
{
    public class PublicOrganization
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public required uint Id {  get; set; }
        public required PublicOrganizationTypeEnum? PublicOrganizationTypeId { get; set; }
        public virtual PublicOrganizationType? Type { get; set; }
    }
}
