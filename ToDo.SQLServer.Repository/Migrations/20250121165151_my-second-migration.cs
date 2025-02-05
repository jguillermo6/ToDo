using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ToDo.SQLServer.Repository.Migrations
{
    /// <inheritdoc />
    public partial class mysecondmigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TaskItem_UserCalendars_UserCalendarId",
                table: "TaskItem");

            migrationBuilder.AlterColumn<int>(
                name: "UserCalendarId",
                table: "TaskItem",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_TaskItem_UserCalendars_UserCalendarId",
                table: "TaskItem",
                column: "UserCalendarId",
                principalTable: "UserCalendars",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TaskItem_UserCalendars_UserCalendarId",
                table: "TaskItem");

            migrationBuilder.AlterColumn<int>(
                name: "UserCalendarId",
                table: "TaskItem",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_TaskItem_UserCalendars_UserCalendarId",
                table: "TaskItem",
                column: "UserCalendarId",
                principalTable: "UserCalendars",
                principalColumn: "Id");
        }
    }
}
