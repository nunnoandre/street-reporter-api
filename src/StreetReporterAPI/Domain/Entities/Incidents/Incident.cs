﻿using StreetReporterAPI.Domain.Entities.Reports;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using StreetReporterAPI.Domain.Entities.Organizations;

namespace StreetReporterAPI.Domain.Entities.Incidents
{
    public class Incident
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public uint Id { get; set; }
        public required string Description { get; set; }
        public DateTime CreationDate { get; set; } = DateTime.Now;
        public required string Coordinates { get; set; }
        public required IncidentCategoryEnum IncidentCategoryId { get; set; } = IncidentCategoryEnum.Other;
        public virtual IncidentCategory? Category { get; set; }
        public required uint? ResponsibleOrganizationId { get; set; }
        public virtual PublicOrganization? ResponsibleOrganization { get; set; }
        public IncidentStatusEnum IncidentStatusId { get; set; } = IncidentStatusEnum.Aknowledged;
        public virtual IncidentStatus? Status { get; set; }
        public bool IsArchived { get; set; } = false;
        public DateTime? ConclusionDate { get; set; }
        //public required uint ReportsCount { get; set; }
        public virtual List<IncidentMessage>? Messages { get; set; }
        public virtual List<Report>? Reports { get; set; }
    }
}
