using Microsoft.EntityFrameworkCore;
using StreetReporterAPI.Domain.Entities.Incidents;
using StreetReporterAPI.Domain.Entities.Reports;
using StreetReporterAPI.Domain.Entities.Users;

namespace StreetReporterAPI.Infrastructure.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        public virtual DbSet<Report> Reports { get; set; }
        public virtual DbSet<ReportStatus> ReportsStatuses { get; set; }
        public virtual DbSet<Incident> Incidents { get; set; }
        public virtual DbSet<IncidentCategory> IncidentCategories { get; set; }
        public virtual DbSet<IncidentMessage> IncidentsMessages { get; set; }
        public virtual DbSet<IncidentStatus> IncidentStatuses { get; set; }
        public virtual DbSet<User> Users { get; set; }

    }
}
