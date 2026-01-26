using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace _4EPlatForm.Infrastrucure.Migrations
{
    /// <inheritdoc />
    public partial class UpdateRiskApproveCycle : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RiskApproveCycles_LKRiskRequests_LKRiskRequestId",
                table: "RiskApproveCycles");

            migrationBuilder.AlterColumn<int>(
                name: "LKRiskRequestId",
                table: "RiskApproveCycles",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<Guid>(
                name: "RiskApproveCycleId",
                table: "RemainRisks",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "RiskApproveCycleId",
                table: "RegulatoryControls",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "RiskApproveCycleId",
                table: "ProcessingPlans",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "RiskApproveCycleId",
                table: "InherentRisks",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "RiskApproveCycleId",
                table: "IdentifyRisks",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_RemainRisks_RiskApproveCycleId",
                table: "RemainRisks",
                column: "RiskApproveCycleId");

            migrationBuilder.CreateIndex(
                name: "IX_RegulatoryControls_RiskApproveCycleId",
                table: "RegulatoryControls",
                column: "RiskApproveCycleId");

            migrationBuilder.CreateIndex(
                name: "IX_ProcessingPlans_RiskApproveCycleId",
                table: "ProcessingPlans",
                column: "RiskApproveCycleId");

            migrationBuilder.CreateIndex(
                name: "IX_InherentRisks_RiskApproveCycleId",
                table: "InherentRisks",
                column: "RiskApproveCycleId");

            migrationBuilder.CreateIndex(
                name: "IX_IdentifyRisks_RiskApproveCycleId",
                table: "IdentifyRisks",
                column: "RiskApproveCycleId");

            migrationBuilder.AddForeignKey(
                name: "FK_IdentifyRisks_RiskApproveCycles_RiskApproveCycleId",
                table: "IdentifyRisks",
                column: "RiskApproveCycleId",
                principalTable: "RiskApproveCycles",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_InherentRisks_RiskApproveCycles_RiskApproveCycleId",
                table: "InherentRisks",
                column: "RiskApproveCycleId",
                principalTable: "RiskApproveCycles",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ProcessingPlans_RiskApproveCycles_RiskApproveCycleId",
                table: "ProcessingPlans",
                column: "RiskApproveCycleId",
                principalTable: "RiskApproveCycles",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_RegulatoryControls_RiskApproveCycles_RiskApproveCycleId",
                table: "RegulatoryControls",
                column: "RiskApproveCycleId",
                principalTable: "RiskApproveCycles",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_RemainRisks_RiskApproveCycles_RiskApproveCycleId",
                table: "RemainRisks",
                column: "RiskApproveCycleId",
                principalTable: "RiskApproveCycles",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_RiskApproveCycles_LKRiskRequests_LKRiskRequestId",
                table: "RiskApproveCycles",
                column: "LKRiskRequestId",
                principalTable: "LKRiskRequests",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_IdentifyRisks_RiskApproveCycles_RiskApproveCycleId",
                table: "IdentifyRisks");

            migrationBuilder.DropForeignKey(
                name: "FK_InherentRisks_RiskApproveCycles_RiskApproveCycleId",
                table: "InherentRisks");

            migrationBuilder.DropForeignKey(
                name: "FK_ProcessingPlans_RiskApproveCycles_RiskApproveCycleId",
                table: "ProcessingPlans");

            migrationBuilder.DropForeignKey(
                name: "FK_RegulatoryControls_RiskApproveCycles_RiskApproveCycleId",
                table: "RegulatoryControls");

            migrationBuilder.DropForeignKey(
                name: "FK_RemainRisks_RiskApproveCycles_RiskApproveCycleId",
                table: "RemainRisks");

            migrationBuilder.DropForeignKey(
                name: "FK_RiskApproveCycles_LKRiskRequests_LKRiskRequestId",
                table: "RiskApproveCycles");

            migrationBuilder.DropIndex(
                name: "IX_RemainRisks_RiskApproveCycleId",
                table: "RemainRisks");

            migrationBuilder.DropIndex(
                name: "IX_RegulatoryControls_RiskApproveCycleId",
                table: "RegulatoryControls");

            migrationBuilder.DropIndex(
                name: "IX_ProcessingPlans_RiskApproveCycleId",
                table: "ProcessingPlans");

            migrationBuilder.DropIndex(
                name: "IX_InherentRisks_RiskApproveCycleId",
                table: "InherentRisks");

            migrationBuilder.DropIndex(
                name: "IX_IdentifyRisks_RiskApproveCycleId",
                table: "IdentifyRisks");

            migrationBuilder.DropColumn(
                name: "RiskApproveCycleId",
                table: "RemainRisks");

            migrationBuilder.DropColumn(
                name: "RiskApproveCycleId",
                table: "RegulatoryControls");

            migrationBuilder.DropColumn(
                name: "RiskApproveCycleId",
                table: "ProcessingPlans");

            migrationBuilder.DropColumn(
                name: "RiskApproveCycleId",
                table: "InherentRisks");

            migrationBuilder.DropColumn(
                name: "RiskApproveCycleId",
                table: "IdentifyRisks");

            migrationBuilder.AlterColumn<int>(
                name: "LKRiskRequestId",
                table: "RiskApproveCycles",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_RiskApproveCycles_LKRiskRequests_LKRiskRequestId",
                table: "RiskApproveCycles",
                column: "LKRiskRequestId",
                principalTable: "LKRiskRequests",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
