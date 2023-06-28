using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MM_Roteiros.Migrations
{
    /// <inheritdoc />
    public partial class Classificacao : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "rating",
                table: "film",
                type: "varchar(10)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "rating",
                table: "film");
        }
    }
}
