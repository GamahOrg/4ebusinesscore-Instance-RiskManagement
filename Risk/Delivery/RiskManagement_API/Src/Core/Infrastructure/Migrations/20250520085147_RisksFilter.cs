using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace _4EPlatForm.Infrastrucure.Migrations
{
    /// <inheritdoc />
    public partial class RisksFilter : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "RisksFilter",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AmbassadorOfDanger = table.Column<bool>(type: "bit", nullable: false),
                    Approvals = table.Column<bool>(type: "bit", nullable: false),
                    DangerAddress = table.Column<bool>(type: "bit", nullable: false),
                    DangerSymbol = table.Column<bool>(type: "bit", nullable: false),
                    DateOfDiscovery = table.Column<bool>(type: "bit", nullable: false),
                    InherentRiskLevel = table.Column<bool>(type: "bit", nullable: false),
                    MainCategory = table.Column<bool>(type: "bit", nullable: false),
                    OriginOfDanger = table.Column<bool>(type: "bit", nullable: false),
                    OwnerOfTheRisk = table.Column<bool>(type: "bit", nullable: false),
                    PlanExpiryDate = table.Column<bool>(type: "bit", nullable: false),
                    Procedures = table.Column<bool>(type: "bit", nullable: false),
                    ResidualRiskScore = table.Column<bool>(type: "bit", nullable: false),
                    SectorManagement = table.Column<bool>(type: "bit", nullable: false),
                    SubcategoryRisk = table.Column<bool>(type: "bit", nullable: false),
                    TreatmentPlanOwner = table.Column<bool>(type: "bit", nullable: false),
                    TreatmentPlanStatus = table.Column<bool>(type: "bit", nullable: false),
                    TreatmentPlanType = table.Column<bool>(type: "bit", nullable: false),
                    State = table.Column<int>(type: "int", nullable: false),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RisksFilter", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RisksFilter");
        }
    }
}
