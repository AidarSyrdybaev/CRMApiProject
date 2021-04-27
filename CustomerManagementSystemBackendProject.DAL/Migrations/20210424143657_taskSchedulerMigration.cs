using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace CustomerManagementSystemBackendProject.DAL.Migrations
{
    public partial class taskSchedulerMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ChosenLeads_AspNetUsers_UserId",
                table: "ChosenLeads");

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdateStatusDate",
                table: "Clients",
                type: "timestamp without time zone",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "ChosenLeads",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "Notifies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    IsArchive = table.Column<bool>(type: "boolean", nullable: false),
                    Date = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    Discriminator = table.Column<string>(type: "text", nullable: false),
                    ChosenLeadId = table.Column<int>(type: "integer", nullable: true),
                    LeadId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notifies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Notifies_ChosenLeads_ChosenLeadId",
                        column: x => x.ChosenLeadId,
                        principalTable: "ChosenLeads",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Notifies_Clients_LeadId",
                        column: x => x.LeadId,
                        principalTable: "Clients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Notifies_ChosenLeadId",
                table: "Notifies",
                column: "ChosenLeadId");

            migrationBuilder.CreateIndex(
                name: "IX_Notifies_LeadId",
                table: "Notifies",
                column: "LeadId");

            migrationBuilder.AddForeignKey(
                name: "FK_ChosenLeads_AspNetUsers_UserId",
                table: "ChosenLeads",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ChosenLeads_AspNetUsers_UserId",
                table: "ChosenLeads");

            migrationBuilder.DropTable(
                name: "Notifies");

            migrationBuilder.DropColumn(
                name: "UpdateStatusDate",
                table: "Clients");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "ChosenLeads",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddForeignKey(
                name: "FK_ChosenLeads_AspNetUsers_UserId",
                table: "ChosenLeads",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
