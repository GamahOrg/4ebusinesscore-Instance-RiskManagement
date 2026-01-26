using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace _4EPlatForm.Infrastrucure.Migrations
{
    /// <inheritdoc />
    public partial class addLKRiskRequest : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "RiskRequest",
                table: "RiskApproveCycles",
                newName: "LKRiskRequestId");

            migrationBuilder.CreateTable(
                name: "LKRiskRequests",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
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
                    table.PrimaryKey("PK_LKRiskRequests", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RiskApproveCycles_LKRiskRequestId",
                table: "RiskApproveCycles",
                column: "LKRiskRequestId");

            migrationBuilder.AddForeignKey(
                name: "FK_RiskApproveCycles_LKRiskRequests_LKRiskRequestId",
                table: "RiskApproveCycles",
                column: "LKRiskRequestId",
                principalTable: "LKRiskRequests",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RiskApproveCycles_LKRiskRequests_LKRiskRequestId",
                table: "RiskApproveCycles");

            migrationBuilder.DropTable(
                name: "LKRiskRequests");

            migrationBuilder.DropIndex(
                name: "IX_RiskApproveCycles_LKRiskRequestId",
                table: "RiskApproveCycles");

            migrationBuilder.RenameColumn(
                name: "LKRiskRequestId",
                table: "RiskApproveCycles",
                newName: "RiskRequest");
        }
    }
}
