using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace _4EPlatForm.Infrastrucure.Migrations
{
    /// <inheritdoc />
    public partial class RequestDataToTemps : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "ReportId",
                table: "RemainRiskTemps",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "RequestInstanceId",
                table: "RemainRiskTemps",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "RiskApproveCycleId",
                table: "RemainRiskTemps",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "ReportId",
                table: "RegulatoryControlTemps",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "RequestInstanceId",
                table: "RegulatoryControlTemps",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "RiskApproveCycleId",
                table: "RegulatoryControlTemps",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "ReportId",
                table: "ProcessingPlanTemps",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "RequestInstanceId",
                table: "ProcessingPlanTemps",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "RiskApproveCycleId",
                table: "ProcessingPlanTemps",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "ReportId",
                table: "InherentRiskTemps",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "RequestInstanceId",
                table: "InherentRiskTemps",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "RiskApproveCycleId",
                table: "InherentRiskTemps",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "ReportId",
                table: "IdentifyRiskTemps",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "RequestInstanceId",
                table: "IdentifyRiskTemps",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "RiskApproveCycleId",
                table: "IdentifyRiskTemps",
                type: "uniqueidentifier",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ReportId",
                table: "RemainRiskTemps");

            migrationBuilder.DropColumn(
                name: "RequestInstanceId",
                table: "RemainRiskTemps");

            migrationBuilder.DropColumn(
                name: "RiskApproveCycleId",
                table: "RemainRiskTemps");

            migrationBuilder.DropColumn(
                name: "ReportId",
                table: "RegulatoryControlTemps");

            migrationBuilder.DropColumn(
                name: "RequestInstanceId",
                table: "RegulatoryControlTemps");

            migrationBuilder.DropColumn(
                name: "RiskApproveCycleId",
                table: "RegulatoryControlTemps");

            migrationBuilder.DropColumn(
                name: "ReportId",
                table: "ProcessingPlanTemps");

            migrationBuilder.DropColumn(
                name: "RequestInstanceId",
                table: "ProcessingPlanTemps");

            migrationBuilder.DropColumn(
                name: "RiskApproveCycleId",
                table: "ProcessingPlanTemps");

            migrationBuilder.DropColumn(
                name: "ReportId",
                table: "InherentRiskTemps");

            migrationBuilder.DropColumn(
                name: "RequestInstanceId",
                table: "InherentRiskTemps");

            migrationBuilder.DropColumn(
                name: "RiskApproveCycleId",
                table: "InherentRiskTemps");

            migrationBuilder.DropColumn(
                name: "ReportId",
                table: "IdentifyRiskTemps");

            migrationBuilder.DropColumn(
                name: "RequestInstanceId",
                table: "IdentifyRiskTemps");

            migrationBuilder.DropColumn(
                name: "RiskApproveCycleId",
                table: "IdentifyRiskTemps");
        }
    }
}
