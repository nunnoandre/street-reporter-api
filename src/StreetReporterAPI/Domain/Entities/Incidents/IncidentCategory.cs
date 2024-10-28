namespace StreetReporterAPI.Domain.Entities.Incidents
{
    public class IncidentCategory
    {
        public required uint Id { get; set; }
        public required string Name { get; set; }
    }

    public enum IncidentCategoryEnum
    {
        None = 0,
        Road = 1,
        SideWalk = 2,
        Square = 3,
        PlayGround = 4,
        Garden = 5
    }
}
