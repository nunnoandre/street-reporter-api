using Microsoft.EntityFrameworkCore;
using StreetReporterAPI.Domain.Entities;

namespace StreetReporterAPI.Infrastructure.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        public virtual DbSet<Report> Reports { get; set; }

    }
}
