using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StreetReporterAPI.Domain.Entities.Incidents;

namespace StreetReporterAPI.Infrastructure.Data.Configuration
{
    //public class IncidentStatusConfiguration : IEntityTypeConfiguration<IncidentStatus>
    //{
    //    public void Configure(EntityTypeBuilder<IncidentStatus> builder)
    //    {
    //        builder.HasData()
    //    }

    //    public IEnumerable<TModel> BuildEnumerableFromEnumType() where  : class 
    //    {
    //        var enumArray = Enum.GetValues(typeof(IncidentStatusEnum));
    //        var statusList = new List<IncidentStatus>();

    //        foreach (var enumValue in enumArray)
    //        {
    //            statusList.Add
    //                (
    //                    new IncidentStatus { Id = enumValue, Name = enumValue.ToString() }
    //                );
    //        }
    //        return statusList;
    //    }


    //    public abstract class BuildConfig<TModel, TEnum> where TModel : IncidentStatus where TModel : IncidentCategory  
    //                                                        where TEnum : struct, IConvertible
    //    {

    //    }
    //}
}
