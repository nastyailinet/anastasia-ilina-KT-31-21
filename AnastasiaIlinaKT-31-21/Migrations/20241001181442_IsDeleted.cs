using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AnastasiaIlinaKT_31_21.Migrations
{
    /// <inheritdoc />
    public partial class IsDeleted : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "c_group_is_deleted",
                table: "cd_group",
                type: "bool",
                nullable: false,
                defaultValue: false,
                comment: "Статус удаления");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "c_group_is_deleted",
                table: "cd_group");
        }
    }
}
