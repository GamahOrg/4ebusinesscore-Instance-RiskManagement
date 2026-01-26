using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace _4EPlatForm.Infrastrucure.Migrations
{
    /// <inheritdoc />
    public partial class WorkFlowCycle : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "ReportId",
                table: "RemainRisks",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "RequestInstanceId",
                table: "RemainRisks",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RequestStatus",
                table: "RemainRisks",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "ReportId",
                table: "RegulatoryControls",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "RequestInstanceId",
                table: "RegulatoryControls",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RequestStatus",
                table: "RegulatoryControls",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "ReportId",
                table: "ProcessingPlans",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "RequestInstanceId",
                table: "ProcessingPlans",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RequestStatus",
                table: "ProcessingPlans",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "ReportId",
                table: "InherentRisks",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "RequestInstanceId",
                table: "InherentRisks",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RequestStatus",
                table: "InherentRisks",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "ReportId",
                table: "IdentifyRisks",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "RequestInstanceId",
                table: "IdentifyRisks",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RequestStatus",
                table: "IdentifyRisks",
                type: "int",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ReportId",
                table: "RemainRisks");

            migrationBuilder.DropColumn(
                name: "RequestInstanceId",
                table: "RemainRisks");

            migrationBuilder.DropColumn(
                name: "RequestStatus",
                table: "RemainRisks");

            migrationBuilder.DropColumn(
                name: "ReportId",
                table: "RegulatoryControls");

            migrationBuilder.DropColumn(
                name: "RequestInstanceId",
                table: "RegulatoryControls");

            migrationBuilder.DropColumn(
                name: "RequestStatus",
                table: "RegulatoryControls");

            migrationBuilder.DropColumn(
                name: "ReportId",
                table: "ProcessingPlans");

            migrationBuilder.DropColumn(
                name: "RequestInstanceId",
                table: "ProcessingPlans");

            migrationBuilder.DropColumn(
                name: "RequestStatus",
                table: "ProcessingPlans");

            migrationBuilder.DropColumn(
                name: "ReportId",
                table: "InherentRisks");

            migrationBuilder.DropColumn(
                name: "RequestInstanceId",
                table: "InherentRisks");

            migrationBuilder.DropColumn(
                name: "RequestStatus",
                table: "InherentRisks");

            migrationBuilder.DropColumn(
                name: "ReportId",
                table: "IdentifyRisks");

            migrationBuilder.DropColumn(
                name: "RequestInstanceId",
                table: "IdentifyRisks");

            migrationBuilder.DropColumn(
                name: "RequestStatus",
                table: "IdentifyRisks");
        }
    }
}
