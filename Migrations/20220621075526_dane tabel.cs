using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace kolos2proba2.Migrations
{
    public partial class danetabel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "MemberNickName",
                table: "Member",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20);

            migrationBuilder.InsertData(
                table: "Organization",
                columns: new[] { "OrganizationID", "OrganizationDomain", "OrganizationName" },
                values: new object[] { 1, "pjwstk.edu.pl", "pjatk" });

            migrationBuilder.InsertData(
                table: "Member",
                columns: new[] { "MemberID", "MemberName", "MemberNickName", "MemberSurname", "OrganizationID" },
                values: new object[] { 1, "Jan", null, "Pawel", 1 });

            migrationBuilder.InsertData(
                table: "Team",
                columns: new[] { "TeamID", "OrganizationID", "TeamDescription", "TeamName" },
                values: new object[] { 1, 1, "wieczna meka", "24c" });

            migrationBuilder.InsertData(
                table: "File",
                columns: new[] { "FileID", "TeamID", "FileExtension", "FileName", "FileSize" },
                values: new object[] { 1, 1, ".jpg", "kolos2", 500 });

            migrationBuilder.InsertData(
                table: "Membership",
                columns: new[] { "MemberID", "TeamID", "MembershipDate" },
                values: new object[] { 1, 1, new DateTime(2019, 9, 9, 0, 0, 0, 0, DateTimeKind.Unspecified) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "File",
                keyColumns: new[] { "FileID", "TeamID" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "Membership",
                keyColumns: new[] { "MemberID", "TeamID" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "Member",
                keyColumn: "MemberID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Team",
                keyColumn: "TeamID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Organization",
                keyColumn: "OrganizationID",
                keyValue: 1);

            migrationBuilder.AlterColumn<string>(
                name: "MemberNickName",
                table: "Member",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20,
                oldNullable: true);
        }
    }
}
