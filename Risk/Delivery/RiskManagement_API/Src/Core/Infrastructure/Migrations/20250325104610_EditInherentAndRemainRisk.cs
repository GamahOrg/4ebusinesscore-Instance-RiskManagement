#nullable disable

namespace _4EPlatForm.Infrastrucure.Migrations
{
    /// <inheritdoc />
    public partial class EditInherentAndRemainRisk : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsArchive",
                table: "IdentifyRisks");

            migrationBuilder.AddColumn<int>(
                name: "RemainRiskResult",
                table: "RemainRisks",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "InherentRiskResult",
                table: "InherentRisks",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RemainRiskResult",
                table: "RemainRisks");

            migrationBuilder.DropColumn(
                name: "InherentRiskResult",
                table: "InherentRisks");

            migrationBuilder.AddColumn<bool>(
                name: "IsArchive",
                table: "IdentifyRisks",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
