using Microsoft.EntityFrameworkCore.Migrations;

namespace CustomerManagementSystemBackendProject.DAL.Migrations
{
    public partial class fisrtmigra1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsArchive",
                table: "Teachers",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsArchive",
                table: "StudentGroups",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsArchive",
                table: "StudentComments",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsArchive",
                table: "Payments",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsArchive",
                table: "LeadStatuses",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsArchive",
                table: "leadFailureStatuses",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsArchive",
                table: "LeadComments",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsArchive",
                table: "Histories",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsArchive",
                table: "Groups",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsArchive",
                table: "ForgotPaswwordKeys",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsArchive",
                table: "Courses",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsArchive",
                table: "Clients",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsArchive",
                table: "Cities",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsArchive",
                table: "ChosenLeads",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsArchive",
                table: "AspNetUsers",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsArchive",
                table: "AspNetRoles",
                type: "boolean",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsArchive",
                table: "Teachers");

            migrationBuilder.DropColumn(
                name: "IsArchive",
                table: "StudentGroups");

            migrationBuilder.DropColumn(
                name: "IsArchive",
                table: "StudentComments");

            migrationBuilder.DropColumn(
                name: "IsArchive",
                table: "Payments");

            migrationBuilder.DropColumn(
                name: "IsArchive",
                table: "LeadStatuses");

            migrationBuilder.DropColumn(
                name: "IsArchive",
                table: "leadFailureStatuses");

            migrationBuilder.DropColumn(
                name: "IsArchive",
                table: "LeadComments");

            migrationBuilder.DropColumn(
                name: "IsArchive",
                table: "Histories");

            migrationBuilder.DropColumn(
                name: "IsArchive",
                table: "Groups");

            migrationBuilder.DropColumn(
                name: "IsArchive",
                table: "ForgotPaswwordKeys");

            migrationBuilder.DropColumn(
                name: "IsArchive",
                table: "Courses");

            migrationBuilder.DropColumn(
                name: "IsArchive",
                table: "Clients");

            migrationBuilder.DropColumn(
                name: "IsArchive",
                table: "Cities");

            migrationBuilder.DropColumn(
                name: "IsArchive",
                table: "ChosenLeads");

            migrationBuilder.DropColumn(
                name: "IsArchive",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "IsArchive",
                table: "AspNetRoles");
        }
    }
}
