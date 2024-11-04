namespace StreetReporterAPI.Domain.Entities.Incidents
{
    public class IncidentCategory
    {
        public required IncidentCategoryEnum Id { get; set; }
        public required string Name { get; set; }
    }

    public enum IncidentCategoryEnum
    {
        Uncategorized = 1,
        Road = 2,
        SideWalk = 3,
        Square = 4,
        PlayGround = 5,
        Garden = 6,
        Other = 7,
    }
}
