using Microsoft.EntityFrameworkCore.Migrations;

namespace CustomerManagementSystemBackendProject.DAL.Migrations
{
    public partial class historymigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ForgotPasswordKeyId",
                table: "Histories",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ForgotPaswwordKeyId",
                table: "Histories",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "GroupId",
                table: "Histories",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "LeadId",
                table: "Histories",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PaymentId",
                table: "Histories",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "StudentGroupId",
                table: "Histories",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "StudentId",
                table: "Histories",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TeacherId",
                table: "Histories",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Histories_ForgotPaswwordKeyId",
                table: "Histories",
                column: "ForgotPaswwordKeyId");

            migrationBuilder.CreateIndex(
                name: "IX_Histories_GroupId",
                table: "Histories",
                column: "GroupId");

            migrationBuilder.CreateIndex(
                name: "IX_Histories_LeadId",
                table: "Histories",
                column: "LeadId");

            migrationBuilder.CreateIndex(
                name: "IX_Histories_PaymentId",
                table: "Histories",
                column: "PaymentId");

            migrationBuilder.CreateIndex(
                name: "IX_Histories_StudentGroupId",
                table: "Histories",
                column: "StudentGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_Histories_StudentId",
                table: "Histories",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_Histories_TeacherId",
                table: "Histories",
                column: "TeacherId");

            migrationBuilder.AddForeignKey(
                name: "FK_Histories_Clients_LeadId",
                table: "Histories",
                column: "LeadId",
                principalTable: "Clients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Histories_Clients_StudentId",
                table: "Histories",
                column: "StudentId",
                principalTable: "Clients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Histories_ForgotPaswwordKeys_ForgotPaswwordKeyId",
                table: "Histories",
                column: "ForgotPaswwordKeyId",
                principalTable: "ForgotPaswwordKeys",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Histories_Groups_GroupId",
                table: "Histories",
                column: "GroupId",
                principalTable: "Groups",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Histories_Payments_PaymentId",
                table: "Histories",
                column: "PaymentId",
                principalTable: "Payments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Histories_StudentGroups_StudentGroupId",
                table: "Histories",
                column: "StudentGroupId",
                principalTable: "StudentGroups",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Histories_Teachers_TeacherId",
                table: "Histories",
                column: "TeacherId",
                principalTable: "Teachers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Histories_Clients_LeadId",
                table: "Histories");

            migrationBuilder.DropForeignKey(
                name: "FK_Histories_Clients_StudentId",
                table: "Histories");

            migrationBuilder.DropForeignKey(
                name: "FK_Histories_ForgotPaswwordKeys_ForgotPaswwordKeyId",
                table: "Histories");

            migrationBuilder.DropForeignKey(
                name: "FK_Histories_Groups_GroupId",
                table: "Histories");

            migrationBuilder.DropForeignKey(
                name: "FK_Histories_Payments_PaymentId",
                table: "Histories");

            migrationBuilder.DropForeignKey(
                name: "FK_Histories_StudentGroups_StudentGroupId",
                table: "Histories");

            migrationBuilder.DropForeignKey(
                name: "FK_Histories_Teachers_TeacherId",
                table: "Histories");

            migrationBuilder.DropIndex(
                name: "IX_Histories_ForgotPaswwordKeyId",
                table: "Histories");

            migrationBuilder.DropIndex(
                name: "IX_Histories_GroupId",
                table: "Histories");

            migrationBuilder.DropIndex(
                name: "IX_Histories_LeadId",
                table: "Histories");

            migrationBuilder.DropIndex(
                name: "IX_Histories_PaymentId",
                table: "Histories");

            migrationBuilder.DropIndex(
                name: "IX_Histories_StudentGroupId",
                table: "Histories");

            migrationBuilder.DropIndex(
                name: "IX_Histories_StudentId",
                table: "Histories");

            migrationBuilder.DropIndex(
                name: "IX_Histories_TeacherId",
                table: "Histories");

            migrationBuilder.DropColumn(
                name: "ForgotPasswordKeyId",
                table: "Histories");

            migrationBuilder.DropColumn(
                name: "ForgotPaswwordKeyId",
                table: "Histories");

            migrationBuilder.DropColumn(
                name: "GroupId",
                table: "Histories");

            migrationBuilder.DropColumn(
                name: "LeadId",
                table: "Histories");

            migrationBuilder.DropColumn(
                name: "PaymentId",
                table: "Histories");

            migrationBuilder.DropColumn(
                name: "StudentGroupId",
                table: "Histories");

            migrationBuilder.DropColumn(
                name: "StudentId",
                table: "Histories");

            migrationBuilder.DropColumn(
                name: "TeacherId",
                table: "Histories");
        }
    }
}
