using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MM_Roteiros.Migrations
{
    /// <inheritdoc />
    public partial class Indice : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_actor_last_name",
                table: "actor",
                column: "last_name");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_actor_last_name",
                table: "actor");
        }
    }
}
