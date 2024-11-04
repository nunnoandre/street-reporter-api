namespace StreetReporterAPI.Domain.Entities.Organizations
{
    public class PublicOrganizationType
    {
        public required PublicOrganizationTypeEnum Id { get; set; }
        public required string Name { get; set; }
    }

    public enum PublicOrganizationTypeEnum
    {
        Municipality = 1,
        Parish = 2
    }
}
