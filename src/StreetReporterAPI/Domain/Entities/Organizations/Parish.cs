namespace StreetReporterAPI.Domain.Entities.Organizations
{
    public class Parish
    {
        public required uint Id { get; set; }
        public required uint MunicipalityId { get; set; }
    }
}
