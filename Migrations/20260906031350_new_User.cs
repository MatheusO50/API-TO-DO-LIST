using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace To_Do_List.Migrations
{
    /// <inheritdoc />
    public partial class new_User : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "hash",
                table: "Users");

            migrationBuilder.RenameColumn(
                name: "salt",
                table: "Users",
                newName: "Passwordhash");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Passwordhash",
                table: "Users",
                newName: "salt");

            migrationBuilder.AddColumn<string>(
                name: "hash",
                table: "Users",
                type: "text",
                nullable: false,
                defaultValue: "");
        }
    }
}
