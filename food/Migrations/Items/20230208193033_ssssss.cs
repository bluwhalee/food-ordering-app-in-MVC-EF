using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace food.Migrations.Items
{
    /// <inheritdoc />
    public partial class ssssss : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ModifiedByuser",
                table: "Items",
                newName: "ModifiedByUser");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ModifiedByUser",
                table: "Items",
                newName: "ModifiedByuser");
        }
    }
}
