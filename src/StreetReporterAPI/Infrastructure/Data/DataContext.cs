using Microsoft.EntityFrameworkCore;
using StreetReporterAPI.Domain.Entities.Incidents;
using StreetReporterAPI.Domain.Entities.Organizations;
using StreetReporterAPI.Domain.Entities.Reports;
using StreetReporterAPI.Domain.Entities.Users;

namespace StreetReporterAPI.Infrastructure.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        //reports
        public virtual DbSet<Report> Reports { get; set; }
        public virtual DbSet<ReportStatus> ReportsStatuses { get; set; }

        //incidents
        public virtual DbSet<Incident> Incidents { get; set; }
        public virtual DbSet<IncidentCategory> IncidentCategories { get; set; }
        public virtual DbSet<IncidentMessage> IncidentsMessages { get; set; }
        public virtual DbSet<IncidentStatus> IncidentStatuses { get; set; }

        //users
        public virtual DbSet<User> Users { get; set; }

        //organizations
        public virtual DbSet<Municipality> Municipalities { get; set; }
        public virtual DbSet<Parish> Parishes { get; set; }
        public virtual DbSet<PublicOrganization> PublicOrganizations { get; set; }
        public virtual DbSet<PublicOrganizationType> PublicOrganizationTypes { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {

            //populating enum entities
            foreach (var e in Enum.GetValues(typeof(IncidentCategoryEnum)).Cast<IncidentCategoryEnum>())
            {
                builder.Entity<IncidentCategory>().HasData(new IncidentCategory { Id = (uint)e+1, Name = e.ToString() });
            }

            foreach (var e in Enum.GetValues(typeof(IncidentStatusEnum)).Cast<IncidentStatusEnum>())
            {
                builder.Entity<IncidentStatus>().HasData(new IncidentStatus { Id = (uint)e + 1, Name = e.ToString() });
            }

            foreach (var e in Enum.GetValues(typeof(PublicOrganizationTypeEnum)).Cast<PublicOrganizationTypeEnum>())
            {
                builder.Entity<PublicOrganizationType>().HasData(new PublicOrganizationType { Id = (uint)e + 1, Name = e.ToString() });
            }

            foreach (var e in Enum.GetValues(typeof(ReportStatusEnum)).Cast<ReportStatusEnum>())
            {
                builder.Entity<ReportStatus>().HasData(new ReportStatus { Id = (uint)e + 1, Name = e.ToString() });
            }

            foreach (var e in Enum.GetValues(typeof(UserRoleEnum)).Cast<UserRoleEnum>())
            {
                builder.Entity<UserRole>().HasData(new UserRole { Id = (uint)e + 1, Name = e.ToString() });
            }

            //adding alternate key for user
            builder.Entity<User>().HasAlternateKey(u => u.NIF);
        }

    }
}
