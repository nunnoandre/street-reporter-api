using System.Runtime.ConstrainedExecution;

namespace StreetReporterAPI.Application.Constants
{
    public static class ErrorMessage
    {
        //reports
        public static string ReportNotFoundById = "There was no report found with that id";
        public static string ReportsNotFoundByUser = "There was no reports found for that user";
        public static string ReportsNotFoundByOrganization = "There was no reports found for that organization";
        public static string ActiveReportsNotFoundByOrganization = "There was no active reports found for that organization";

        //incidents
        public static string IncidentNotFoundById = "There was no incident found with that id";
        public static string IncidentsNotFoundByUser = "There was no incidents found for that user";
        public static string IncidentsNotFoundByOrganization = "There was no incidents found for that organization";
        public static string ActiveIncidentsNotFoundByOrganization = "There was no active incidents found for that organization";
    }
}
