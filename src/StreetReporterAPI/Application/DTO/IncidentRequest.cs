using StreetReporterAPI.Domain.Entities.Incidents;
using StreetReporterAPI.Domain.Entities.Organizations;
using StreetReporterAPI.Domain.Entities.Reports;

namespace StreetReporterAPI.Application.DTO
{
    public class IncidentRequest
    {
        public string Description { get; set; }
        public string Coordinates { get; set; }
        public uint CategoryId { get; set; }
        public uint ResponsibleOrganizationId { get; set; }
    }
}
