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
        Opened = 0,
        Taken = 1,
        Refused = 2,
        InProgress = 3,
        Done = 4,
        Canceled = 5,
        Archived = 6
    }
}
