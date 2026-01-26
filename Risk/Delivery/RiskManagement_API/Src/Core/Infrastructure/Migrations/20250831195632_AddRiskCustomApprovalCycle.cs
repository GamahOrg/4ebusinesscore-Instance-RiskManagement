using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace _4EPlatForm.Infrastrucure.Migrations
{
    /// <inheritdoc />
    public partial class AddRiskCustomApprovalCycle : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "RiskCustomApprovalCycles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdentifyRiskId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LKRiskRequestId = table.Column<int>(type: "int", nullable: false),
                    RiskApproveCycleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    State = table.Column<int>(type: "int", nullable: false),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RiskCustomApprovalCycles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RiskCustomApprovalCycles_IdentifyRisks_IdentifyRiskId",
                        column: x => x.IdentifyRiskId,
                        principalTable: "IdentifyRisks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RiskCustomApprovalCycles_LKRiskRequests_LKRiskRequestId",
                        column: x => x.LKRiskRequestId,
                        principalTable: "LKRiskRequests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RiskCustomApprovalCycles_RiskApproveCycles_RiskApproveCycleId",
                        column: x => x.RiskApproveCycleId,
                        principalTable: "RiskApproveCycles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RiskCustomApprovalCycles_IdentifyRiskId",
                table: "RiskCustomApprovalCycles",
                column: "IdentifyRiskId");

            migrationBuilder.CreateIndex(
                name: "IX_RiskCustomApprovalCycles_LKRiskRequestId",
                table: "RiskCustomApprovalCycles",
                column: "LKRiskRequestId");

            migrationBuilder.CreateIndex(
                name: "IX_RiskCustomApprovalCycles_RiskApproveCycleId",
                table: "RiskCustomApprovalCycles",
                column: "RiskApproveCycleId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RiskCustomApprovalCycles");
        }
    }
}
