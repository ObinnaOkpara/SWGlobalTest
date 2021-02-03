using Microsoft.EntityFrameworkCore.Migrations;

namespace SWGlobalTest.Migrations
{
    public partial class seedUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "02174cf0-9412-4cfe-afbf-59f706d72cff",
                columns: new[] { "ConcurrencyStamp", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "SecurityStamp" },
                values: new object[] { "4f09f6d8-7316-4e9b-bb3c-5536d0b795e4", "ADMIN@GMAIL.COM", "ADMIN@GMAIL.COM", "AQAAAAEAACcQAAAAEF0zEZbyyT3VISIvE2EbZ5+rOELiLRya2TWPf1nV3bPW/4yN4HdNY0PKHBy+DCX5ww==", "ed33abec-0ab4-42ef-b828-44c81002447c" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "02174cf0-9412-4cfe-afbf-59f706d72cff",
                columns: new[] { "ConcurrencyStamp", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "SecurityStamp" },
                values: new object[] { "2f410d77-2559-4193-af55-4d65ca039bd1", null, null, "AQAAAAEAACcQAAAAEJZJppuC2vFTSBgfkudwYIWcectUkX0utMFjPRCq7z7ytBG5+wcEFw10W9mduXr/ag==", "5021fee5-2600-4cc0-8523-0c31984aef48" });
        }
    }
}
