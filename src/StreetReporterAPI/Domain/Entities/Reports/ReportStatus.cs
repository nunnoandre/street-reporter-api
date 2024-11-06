using StreetReporterAPI.Domain.Entities.Incidents;

namespace StreetReporterAPI.Domain.Entities.Reports
{
    public class ReportStatus
    {
        public required ReportStatusEnum Id { get; set; }
        public required string Name { get; set; }
    }

    public enum ReportStatusEnum
    {
        Opened = 1,
        Taken = 2,
        Refused = 3,
        InProgress = 4,
        Done = 5,
        Canceled = 6,
        Archived = 7
    }


}
