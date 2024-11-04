using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace StreetReporterAPI.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "IncidentCategories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IncidentCategories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "IncidentStatuses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IncidentStatuses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Municipalities",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Municipalities", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PublicOrganizationTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PublicOrganizationTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ReportStatuses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReportStatuses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserRole",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRole", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Parishes",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MunicipalityId = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Parishes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Parishes_Municipalities_MunicipalityId",
                        column: x => x.MunicipalityId,
                        principalTable: "Municipalities",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "PublicOrganizations",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PublicOrganizationTypeId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PublicOrganizations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PublicOrganizations_PublicOrganizationTypes_PublicOrganizationTypeId",
                        column: x => x.PublicOrganizationTypeId,
                        principalTable: "PublicOrganizationTypes",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Incidents",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Coordinates = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IncidentCategoryId = table.Column<int>(type: "int", nullable: true),
                    ResponsibleOrganizationId = table.Column<long>(type: "bigint", nullable: true),
                    IncidentStatusId = table.Column<int>(type: "int", nullable: true),
                    ConclusionDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Incidents", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Incidents_IncidentCategories_IncidentCategoryId",
                        column: x => x.IncidentCategoryId,
                        principalTable: "IncidentCategories",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Incidents_IncidentStatuses_IncidentStatusId",
                        column: x => x.IncidentStatusId,
                        principalTable: "IncidentStatuses",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Incidents_PublicOrganizations_ResponsibleOrganizationId",
                        column: x => x.ResponsibleOrganizationId,
                        principalTable: "PublicOrganizations",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    NIF = table.Column<long>(type: "bigint", nullable: false),
                    UserRoleId = table.Column<int>(type: "int", nullable: true),
                    PublicOrganizationId = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.NIF);
                    table.ForeignKey(
                        name: "FK_Users_PublicOrganizations_PublicOrganizationId",
                        column: x => x.PublicOrganizationId,
                        principalTable: "PublicOrganizations",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Users_UserRole_UserRoleId",
                        column: x => x.UserRoleId,
                        principalTable: "UserRole",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "IncidentMessages",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IncidentId = table.Column<long>(type: "bigint", nullable: false),
                    UserId = table.Column<long>(type: "bigint", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Message = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsPublic = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IncidentMessages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_IncidentMessages_Incidents_IncidentId",
                        column: x => x.IncidentId,
                        principalTable: "Incidents",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_IncidentMessages_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "NIF");
                });

            migrationBuilder.CreateTable(
                name: "Reports",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ReporterNIF = table.Column<long>(type: "bigint", nullable: true),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Coordinates = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IncidentCategoryId = table.Column<int>(type: "int", nullable: false),
                    ResponsibleOrganizationId = table.Column<long>(type: "bigint", nullable: false),
                    ReportStatusId = table.Column<int>(type: "int", nullable: false),
                    IsAnonymous = table.Column<bool>(type: "bit", nullable: false),
                    HasImages = table.Column<bool>(type: "bit", nullable: false),
                    ConclusionDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IncidentId = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reports", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Reports_IncidentCategories_IncidentCategoryId",
                        column: x => x.IncidentCategoryId,
                        principalTable: "IncidentCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Reports_Incidents_IncidentId",
                        column: x => x.IncidentId,
                        principalTable: "Incidents",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Reports_PublicOrganizations_ResponsibleOrganizationId",
                        column: x => x.ResponsibleOrganizationId,
                        principalTable: "PublicOrganizations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Reports_ReportStatuses_ReportStatusId",
                        column: x => x.ReportStatusId,
                        principalTable: "ReportStatuses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Reports_Users_ReporterNIF",
                        column: x => x.ReporterNIF,
                        principalTable: "Users",
                        principalColumn: "NIF");
                });

            migrationBuilder.InsertData(
                table: "IncidentCategories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Uncategorized" },
                    { 2, "Road" },
                    { 3, "SideWalk" },
                    { 4, "Square" },
                    { 5, "PlayGround" },
                    { 6, "Garden" },
                    { 7, "Other" }
                });

            migrationBuilder.InsertData(
                table: "IncidentStatuses",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Aknowledged" },
                    { 2, "InProgress" },
                    { 3, "Done" },
                    { 4, "Aborted" },
                    { 5, "Archived" },
                    { 6, "Affected" },
                    { 7, "NotAffected" }
                });

            migrationBuilder.InsertData(
                table: "PublicOrganizationTypes",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Municipality" },
                    { 2, "Parish" }
                });

            migrationBuilder.InsertData(
                table: "ReportStatuses",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Opened" },
                    { 2, "Taken" },
                    { 3, "Refused" },
                    { 4, "InProgress" },
                    { 5, "Done" },
                    { 6, "Canceled" },
                    { 7, "Archived" }
                });

            migrationBuilder.InsertData(
                table: "UserRole",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Reporter" },
                    { 2, "Manager" },
                    { 3, "Admin" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_IncidentMessages_IncidentId",
                table: "IncidentMessages",
                column: "IncidentId");

            migrationBuilder.CreateIndex(
                name: "IX_IncidentMessages_UserId",
                table: "IncidentMessages",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Incidents_IncidentCategoryId",
                table: "Incidents",
                column: "IncidentCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Incidents_IncidentStatusId",
                table: "Incidents",
                column: "IncidentStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Incidents_ResponsibleOrganizationId",
                table: "Incidents",
                column: "ResponsibleOrganizationId");

            migrationBuilder.CreateIndex(
                name: "IX_Parishes_MunicipalityId",
                table: "Parishes",
                column: "MunicipalityId");

            migrationBuilder.CreateIndex(
                name: "IX_PublicOrganizations_PublicOrganizationTypeId",
                table: "PublicOrganizations",
                column: "PublicOrganizationTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Reports_IncidentCategoryId",
                table: "Reports",
                column: "IncidentCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Reports_IncidentId",
                table: "Reports",
                column: "IncidentId");

            migrationBuilder.CreateIndex(
                name: "IX_Reports_ReporterNIF",
                table: "Reports",
                column: "ReporterNIF");

            migrationBuilder.CreateIndex(
                name: "IX_Reports_ReportStatusId",
                table: "Reports",
                column: "ReportStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Reports_ResponsibleOrganizationId",
                table: "Reports",
                column: "ResponsibleOrganizationId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_PublicOrganizationId",
                table: "Users",
                column: "PublicOrganizationId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_UserRoleId",
                table: "Users",
                column: "UserRoleId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "IncidentMessages");

            migrationBuilder.DropTable(
                name: "Parishes");

            migrationBuilder.DropTable(
                name: "Reports");

            migrationBuilder.DropTable(
                name: "Municipalities");

            migrationBuilder.DropTable(
                name: "Incidents");

            migrationBuilder.DropTable(
                name: "ReportStatuses");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "IncidentCategories");

            migrationBuilder.DropTable(
                name: "IncidentStatuses");

            migrationBuilder.DropTable(
                name: "PublicOrganizations");

            migrationBuilder.DropTable(
                name: "UserRole");

            migrationBuilder.DropTable(
                name: "PublicOrganizationTypes");
        }
    }
}
