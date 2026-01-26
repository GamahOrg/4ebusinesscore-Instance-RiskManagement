using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace _4EPlatForm.Infrastrucure.Migrations
{
    /// <inheritdoc />
    public partial class RiskTempTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "IdentifyRiskTemps",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdentifyRiskId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Reason = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Effects = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsCompleted = table.Column<bool>(type: "bit", nullable: true),
                    IdentifyRiskDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RiskStatus = table.Column<int>(type: "int", nullable: false),
                    SubCateoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OrgId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AmbassadorUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OwnerUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ResponsibleUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LkRiskTypeId = table.Column<int>(type: "int", nullable: false),
                    State = table.Column<int>(type: "int", nullable: false),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IdentifyRiskTemps", x => x.Id);
                    table.ForeignKey(
                        name: "FK_IdentifyRiskTemps_IdentifyRisks_IdentifyRiskId",
                        column: x => x.IdentifyRiskId,
                        principalTable: "IdentifyRisks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_IdentifyRiskTemps_LkRiskTypes_LkRiskTypeId",
                        column: x => x.LkRiskTypeId,
                        principalTable: "LkRiskTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_IdentifyRiskTemps_SubCateories_SubCateoryId",
                        column: x => x.SubCateoryId,
                        principalTable: "SubCateories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "InherentRiskTemps",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdentifyRiskId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ImpactId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProbabilityOfOccurrenceId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RiskCriteriaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    InherentRiskResult = table.Column<int>(type: "int", nullable: false),
                    State = table.Column<int>(type: "int", nullable: false),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InherentRiskTemps", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InherentRiskTemps_IdentifyRisks_IdentifyRiskId",
                        column: x => x.IdentifyRiskId,
                        principalTable: "IdentifyRisks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InherentRiskTemps_Impacts_ImpactId",
                        column: x => x.ImpactId,
                        principalTable: "Impacts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_InherentRiskTemps_ProbabilityOfOccurrences_ProbabilityOfOccurrenceId",
                        column: x => x.ProbabilityOfOccurrenceId,
                        principalTable: "ProbabilityOfOccurrences",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_InherentRiskTemps_RiskCriterias_RiskCriteriaId",
                        column: x => x.RiskCriteriaId,
                        principalTable: "RiskCriterias",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ProcessingPlanTemps",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdentifyRiskId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TypeTreatmentPlanId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DateEndPlan = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImplementationStatusId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    State = table.Column<int>(type: "int", nullable: false),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProcessingPlanTemps", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProcessingPlanTemps_IdentifyRisks_IdentifyRiskId",
                        column: x => x.IdentifyRiskId,
                        principalTable: "IdentifyRisks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProcessingPlanTemps_ImplementationStatuses_ImplementationStatusId",
                        column: x => x.ImplementationStatusId,
                        principalTable: "ImplementationStatuses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProcessingPlanTemps_TypeTreatmentPlans_TypeTreatmentPlanId",
                        column: x => x.TypeTreatmentPlanId,
                        principalTable: "TypeTreatmentPlans",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "RegulatoryControlTemps",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdentifyRiskId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ControlId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProbabilityOfEffectivenesId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EffectOfTheEventId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AppliedRegulatoryControls = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    State = table.Column<int>(type: "int", nullable: false),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RegulatoryControlTemps", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RegulatoryControlTemps_Controls_ControlId",
                        column: x => x.ControlId,
                        principalTable: "Controls",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RegulatoryControlTemps_EffectOfTheEvents_EffectOfTheEventId",
                        column: x => x.EffectOfTheEventId,
                        principalTable: "EffectOfTheEvents",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RegulatoryControlTemps_IdentifyRisks_IdentifyRiskId",
                        column: x => x.IdentifyRiskId,
                        principalTable: "IdentifyRisks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RegulatoryControlTemps_ProbabilityOfEffectivenes_ProbabilityOfEffectivenesId",
                        column: x => x.ProbabilityOfEffectivenesId,
                        principalTable: "ProbabilityOfEffectivenes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "RemainRiskTemps",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdentifyRiskId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ImpactId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProbabilityOfOccurrenceId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RiskCriteriaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RemainRiskResult = table.Column<int>(type: "int", nullable: false),
                    State = table.Column<int>(type: "int", nullable: false),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RemainRiskTemps", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RemainRiskTemps_IdentifyRisks_IdentifyRiskId",
                        column: x => x.IdentifyRiskId,
                        principalTable: "IdentifyRisks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RemainRiskTemps_Impacts_ImpactId",
                        column: x => x.ImpactId,
                        principalTable: "Impacts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RemainRiskTemps_ProbabilityOfOccurrences_ProbabilityOfOccurrenceId",
                        column: x => x.ProbabilityOfOccurrenceId,
                        principalTable: "ProbabilityOfOccurrences",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RemainRiskTemps_RiskCriterias_RiskCriteriaId",
                        column: x => x.RiskCriteriaId,
                        principalTable: "RiskCriterias",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_IdentifyRiskTemps_IdentifyRiskId",
                table: "IdentifyRiskTemps",
                column: "IdentifyRiskId");

            migrationBuilder.CreateIndex(
                name: "IX_IdentifyRiskTemps_LkRiskTypeId",
                table: "IdentifyRiskTemps",
                column: "LkRiskTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_IdentifyRiskTemps_SubCateoryId",
                table: "IdentifyRiskTemps",
                column: "SubCateoryId");

            migrationBuilder.CreateIndex(
                name: "IX_InherentRiskTemps_IdentifyRiskId",
                table: "InherentRiskTemps",
                column: "IdentifyRiskId");

            migrationBuilder.CreateIndex(
                name: "IX_InherentRiskTemps_ImpactId",
                table: "InherentRiskTemps",
                column: "ImpactId");

            migrationBuilder.CreateIndex(
                name: "IX_InherentRiskTemps_ProbabilityOfOccurrenceId",
                table: "InherentRiskTemps",
                column: "ProbabilityOfOccurrenceId");

            migrationBuilder.CreateIndex(
                name: "IX_InherentRiskTemps_RiskCriteriaId",
                table: "InherentRiskTemps",
                column: "RiskCriteriaId");

            migrationBuilder.CreateIndex(
                name: "IX_ProcessingPlanTemps_IdentifyRiskId",
                table: "ProcessingPlanTemps",
                column: "IdentifyRiskId");

            migrationBuilder.CreateIndex(
                name: "IX_ProcessingPlanTemps_ImplementationStatusId",
                table: "ProcessingPlanTemps",
                column: "ImplementationStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_ProcessingPlanTemps_TypeTreatmentPlanId",
                table: "ProcessingPlanTemps",
                column: "TypeTreatmentPlanId");

            migrationBuilder.CreateIndex(
                name: "IX_RegulatoryControlTemps_ControlId",
                table: "RegulatoryControlTemps",
                column: "ControlId");

            migrationBuilder.CreateIndex(
                name: "IX_RegulatoryControlTemps_EffectOfTheEventId",
                table: "RegulatoryControlTemps",
                column: "EffectOfTheEventId");

            migrationBuilder.CreateIndex(
                name: "IX_RegulatoryControlTemps_IdentifyRiskId",
                table: "RegulatoryControlTemps",
                column: "IdentifyRiskId");

            migrationBuilder.CreateIndex(
                name: "IX_RegulatoryControlTemps_ProbabilityOfEffectivenesId",
                table: "RegulatoryControlTemps",
                column: "ProbabilityOfEffectivenesId");

            migrationBuilder.CreateIndex(
                name: "IX_RemainRiskTemps_IdentifyRiskId",
                table: "RemainRiskTemps",
                column: "IdentifyRiskId");

            migrationBuilder.CreateIndex(
                name: "IX_RemainRiskTemps_ImpactId",
                table: "RemainRiskTemps",
                column: "ImpactId");

            migrationBuilder.CreateIndex(
                name: "IX_RemainRiskTemps_ProbabilityOfOccurrenceId",
                table: "RemainRiskTemps",
                column: "ProbabilityOfOccurrenceId");

            migrationBuilder.CreateIndex(
                name: "IX_RemainRiskTemps_RiskCriteriaId",
                table: "RemainRiskTemps",
                column: "RiskCriteriaId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "IdentifyRiskTemps");

            migrationBuilder.DropTable(
                name: "InherentRiskTemps");

            migrationBuilder.DropTable(
                name: "ProcessingPlanTemps");

            migrationBuilder.DropTable(
                name: "RegulatoryControlTemps");

            migrationBuilder.DropTable(
                name: "RemainRiskTemps");
        }
    }
}
