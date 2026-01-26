#nullable disable

namespace _4EPlatForm.Infrastrucure.Migrations
{
    /// <inheritdoc />
    public partial class CreateDB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cateories",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NameAr = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NameEn = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    State = table.Column<int>(type: "int", nullable: false),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cateories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Controls",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NameAr = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NameEn = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    State = table.Column<int>(type: "int", nullable: false),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Controls", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EffectOfTheEvents",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NameAr = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NameEn = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImpactNumber = table.Column<int>(type: "int", nullable: false),
                    EventColor = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    State = table.Column<int>(type: "int", nullable: false),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EffectOfTheEvents", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Impacts",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NameAr = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NameEn = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImpactNumber = table.Column<int>(type: "int", nullable: false),
                    ImpactColor = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    State = table.Column<int>(type: "int", nullable: false),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Impacts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ImplementationStatuses",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NameAr = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NameEn = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    State = table.Column<int>(type: "int", nullable: false),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ImplementationStatuses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LkRiskTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameAr = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NameEn = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    State = table.Column<int>(type: "int", nullable: false),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LkRiskTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProbabilityOfEffectivenes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NameAr = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NameEn = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImpactNumber = table.Column<int>(type: "int", nullable: false),
                    EffectColor = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    State = table.Column<int>(type: "int", nullable: false),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProbabilityOfEffectivenes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProbabilityOfOccurrences",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NameAr = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NameEn = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImpactNumber = table.Column<int>(type: "int", nullable: false),
                    ProbabilityColor = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    State = table.Column<int>(type: "int", nullable: false),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProbabilityOfOccurrences", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RiskCriterias",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NameAr = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NameEn = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FromNumber = table.Column<int>(type: "int", nullable: false),
                    ToNumber = table.Column<int>(type: "int", nullable: false),
                    CriteriaColor = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    State = table.Column<int>(type: "int", nullable: false),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RiskCriterias", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RiskUsers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OrgId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RiskUserType = table.Column<int>(type: "int", nullable: false),
                    State = table.Column<int>(type: "int", nullable: false),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RiskUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TypeTreatmentPlans",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NameAr = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NameEn = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    State = table.Column<int>(type: "int", nullable: false),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TypeTreatmentPlans", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SubCateories",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NameAr = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NameEn = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CateoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    State = table.Column<int>(type: "int", nullable: false),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubCateories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SubCateories_Cateories_CateoryId",
                        column: x => x.CateoryId,
                        principalTable: "Cateories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "IdentifyRisks",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Reason = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Effects = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdentifyRiskDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RiskStatus = table.Column<int>(type: "int", nullable: false),
                    SubCateoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OrgId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AmbassadorUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OwnerUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ResponsibleUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LkRiskTypeId = table.Column<int>(type: "int", nullable: false),
                    IsArchive = table.Column<bool>(type: "bit", nullable: false),
                    State = table.Column<int>(type: "int", nullable: false),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IdentifyRisks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_IdentifyRisks_LkRiskTypes_LkRiskTypeId",
                        column: x => x.LkRiskTypeId,
                        principalTable: "LkRiskTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_IdentifyRisks_SubCateories_SubCateoryId",
                        column: x => x.SubCateoryId,
                        principalTable: "SubCateories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "InherentRisks",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdentifyRiskId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ImpactId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProbabilityOfOccurrenceId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RiskCriteriaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    State = table.Column<int>(type: "int", nullable: false),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InherentRisks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InherentRisks_IdentifyRisks_IdentifyRiskId",
                        column: x => x.IdentifyRiskId,
                        principalTable: "IdentifyRisks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InherentRisks_Impacts_ImpactId",
                        column: x => x.ImpactId,
                        principalTable: "Impacts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InherentRisks_ProbabilityOfOccurrences_ProbabilityOfOccurrenceId",
                        column: x => x.ProbabilityOfOccurrenceId,
                        principalTable: "ProbabilityOfOccurrences",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InherentRisks_RiskCriterias_RiskCriteriaId",
                        column: x => x.RiskCriteriaId,
                        principalTable: "RiskCriterias",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProcessingPlans",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdentifyRiskId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TypeTreatmentPlanId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DateEndPlan = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImplementationStatusId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    State = table.Column<int>(type: "int", nullable: false),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProcessingPlans", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProcessingPlans_IdentifyRisks_IdentifyRiskId",
                        column: x => x.IdentifyRiskId,
                        principalTable: "IdentifyRisks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProcessingPlans_ImplementationStatuses_ImplementationStatusId",
                        column: x => x.ImplementationStatusId,
                        principalTable: "ImplementationStatuses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProcessingPlans_TypeTreatmentPlans_TypeTreatmentPlanId",
                        column: x => x.TypeTreatmentPlanId,
                        principalTable: "TypeTreatmentPlans",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RegulatoryControls",
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
                    table.PrimaryKey("PK_RegulatoryControls", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RegulatoryControls_Controls_ControlId",
                        column: x => x.ControlId,
                        principalTable: "Controls",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RegulatoryControls_EffectOfTheEvents_EffectOfTheEventId",
                        column: x => x.EffectOfTheEventId,
                        principalTable: "EffectOfTheEvents",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RegulatoryControls_IdentifyRisks_IdentifyRiskId",
                        column: x => x.IdentifyRiskId,
                        principalTable: "IdentifyRisks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RegulatoryControls_ProbabilityOfEffectivenes_ProbabilityOfEffectivenesId",
                        column: x => x.ProbabilityOfEffectivenesId,
                        principalTable: "ProbabilityOfEffectivenes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RemainRisks",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdentifyRiskId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ImpactId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProbabilityOfOccurrenceId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RiskCriteriaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    State = table.Column<int>(type: "int", nullable: false),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RemainRisks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RemainRisks_IdentifyRisks_IdentifyRiskId",
                        column: x => x.IdentifyRiskId,
                        principalTable: "IdentifyRisks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RemainRisks_Impacts_ImpactId",
                        column: x => x.ImpactId,
                        principalTable: "Impacts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RemainRisks_ProbabilityOfOccurrences_ProbabilityOfOccurrenceId",
                        column: x => x.ProbabilityOfOccurrenceId,
                        principalTable: "ProbabilityOfOccurrences",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RemainRisks_RiskCriterias_RiskCriteriaId",
                        column: x => x.RiskCriteriaId,
                        principalTable: "RiskCriterias",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RiskHistories",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RecordId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdentifyRiskId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    TableName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Action = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OldValue = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NewValue = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    State = table.Column<int>(type: "int", nullable: false),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RiskHistories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RiskHistories_IdentifyRisks_IdentifyRiskId",
                        column: x => x.IdentifyRiskId,
                        principalTable: "IdentifyRisks",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_IdentifyRisks_LkRiskTypeId",
                table: "IdentifyRisks",
                column: "LkRiskTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_IdentifyRisks_SubCateoryId",
                table: "IdentifyRisks",
                column: "SubCateoryId");

            migrationBuilder.CreateIndex(
                name: "IX_InherentRisks_IdentifyRiskId",
                table: "InherentRisks",
                column: "IdentifyRiskId");

            migrationBuilder.CreateIndex(
                name: "IX_InherentRisks_ImpactId",
                table: "InherentRisks",
                column: "ImpactId");

            migrationBuilder.CreateIndex(
                name: "IX_InherentRisks_ProbabilityOfOccurrenceId",
                table: "InherentRisks",
                column: "ProbabilityOfOccurrenceId");

            migrationBuilder.CreateIndex(
                name: "IX_InherentRisks_RiskCriteriaId",
                table: "InherentRisks",
                column: "RiskCriteriaId");

            migrationBuilder.CreateIndex(
                name: "IX_ProcessingPlans_IdentifyRiskId",
                table: "ProcessingPlans",
                column: "IdentifyRiskId");

            migrationBuilder.CreateIndex(
                name: "IX_ProcessingPlans_ImplementationStatusId",
                table: "ProcessingPlans",
                column: "ImplementationStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_ProcessingPlans_TypeTreatmentPlanId",
                table: "ProcessingPlans",
                column: "TypeTreatmentPlanId");

            migrationBuilder.CreateIndex(
                name: "IX_RegulatoryControls_ControlId",
                table: "RegulatoryControls",
                column: "ControlId");

            migrationBuilder.CreateIndex(
                name: "IX_RegulatoryControls_EffectOfTheEventId",
                table: "RegulatoryControls",
                column: "EffectOfTheEventId");

            migrationBuilder.CreateIndex(
                name: "IX_RegulatoryControls_IdentifyRiskId",
                table: "RegulatoryControls",
                column: "IdentifyRiskId");

            migrationBuilder.CreateIndex(
                name: "IX_RegulatoryControls_ProbabilityOfEffectivenesId",
                table: "RegulatoryControls",
                column: "ProbabilityOfEffectivenesId");

            migrationBuilder.CreateIndex(
                name: "IX_RemainRisks_IdentifyRiskId",
                table: "RemainRisks",
                column: "IdentifyRiskId");

            migrationBuilder.CreateIndex(
                name: "IX_RemainRisks_ImpactId",
                table: "RemainRisks",
                column: "ImpactId");

            migrationBuilder.CreateIndex(
                name: "IX_RemainRisks_ProbabilityOfOccurrenceId",
                table: "RemainRisks",
                column: "ProbabilityOfOccurrenceId");

            migrationBuilder.CreateIndex(
                name: "IX_RemainRisks_RiskCriteriaId",
                table: "RemainRisks",
                column: "RiskCriteriaId");

            migrationBuilder.CreateIndex(
                name: "IX_RiskHistories_IdentifyRiskId",
                table: "RiskHistories",
                column: "IdentifyRiskId");

            migrationBuilder.CreateIndex(
                name: "IX_SubCateories_CateoryId",
                table: "SubCateories",
                column: "CateoryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "InherentRisks");

            migrationBuilder.DropTable(
                name: "ProcessingPlans");

            migrationBuilder.DropTable(
                name: "RegulatoryControls");

            migrationBuilder.DropTable(
                name: "RemainRisks");

            migrationBuilder.DropTable(
                name: "RiskHistories");

            migrationBuilder.DropTable(
                name: "RiskUsers");

            migrationBuilder.DropTable(
                name: "ImplementationStatuses");

            migrationBuilder.DropTable(
                name: "TypeTreatmentPlans");

            migrationBuilder.DropTable(
                name: "Controls");

            migrationBuilder.DropTable(
                name: "EffectOfTheEvents");

            migrationBuilder.DropTable(
                name: "ProbabilityOfEffectivenes");

            migrationBuilder.DropTable(
                name: "Impacts");

            migrationBuilder.DropTable(
                name: "ProbabilityOfOccurrences");

            migrationBuilder.DropTable(
                name: "RiskCriterias");

            migrationBuilder.DropTable(
                name: "IdentifyRisks");

            migrationBuilder.DropTable(
                name: "LkRiskTypes");

            migrationBuilder.DropTable(
                name: "SubCateories");

            migrationBuilder.DropTable(
                name: "Cateories");
        }
    }
}
