using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace fiap.Migrations
{
    /// <inheritdoc />
    public partial class AddremovedFlagToInstruments : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Removed",
                table: "Instrumentos",
                type: "bit",
                nullable: false,
                defaultValue: false);

        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Removed",
                table: "Instrumentos");
        }
    }
}
