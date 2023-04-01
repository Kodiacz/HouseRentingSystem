using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HouseRentingSystem.Services.Migrations
{
    public partial class AddedAdmin : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d4350ce-d726-4fc8-83d9-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "3d448403-fdb6-4c1b-b81a-c3949e9b7e76", "AQAAAAEAACcQAAAAEIsg+VGalP8xL514Yz3NZOK0YRjiKhoa9wDiZnEDq3CW/kK8aqxz2A2wsdBMmSCG9A==", "55e5a731-6f5c-4451-ae00-446c4e0279d2" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "9abba108-c1ff-4912-8b31-0dbde0152573", "AQAAAAEAACcQAAAAEFke3Upau1+FE5qYYq8Cv/XTir5o2J0FHoD/+w7wHB35lQX7HlRnq56iFmpgfhoEqA==", "0ca95ab0-b946-4fe1-8f37-67d6bd9534db" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dea12856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "1d20f0cb-550f-49c3-be09-14d15f206dd4", "AQAAAAEAACcQAAAAEAX56TRVDDF6cjqL2n3e4UomfUWax8NLeSXsGYyT2RinYsQafoRFXWP1sD5E7gb5aQ==", "efc47acb-f4ed-4cbe-a5f5-d7c3504364c9" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "IsActive", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "bcb4f072-ecca-43c9-ab26-c060c6f364e4", 0, "ed229f5e-39fb-40ff-ba1a-662077eb9ebc", "admin@mail.com", false, "Great", true, "Admin", false, null, "admin@mail.com", "admin@mail.com", "AQAAAAEAACcQAAAAEO5kQ0D2dLvfwMZmwBD9mhJs4cibUa9k4q5Kfq1rY4uITHnsNJbgYJ72eBZ/mgDcZw==", null, false, "44aa7788-5ebb-436a-b354-9fd535403eba", false, "admin@mail.com" });

            migrationBuilder.InsertData(
                table: "Agents",
                columns: new[] { "Id", "PhoneNumber", "UserId" },
                values: new object[] { 5, "+359123456789", "bcb4f072-ecca-43c9-ab26-c060c6f364e4" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Agents",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "bcb4f072-ecca-43c9-ab26-c060c6f364e4");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d4350ce-d726-4fc8-83d9-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d4429064-87f9-4194-845e-7d2a9a93e966", "AQAAAAEAACcQAAAAEP6IQeI/M2wP0sKo1n2Thgr++43PE7aNGsR+cDG21XMXTZ1OdTen7T0lfRIRWgqL7A==", "f4677df5-f81d-4297-a8b5-323d651df7b7" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a138cfa9-28a9-4ebf-8687-957087bddb20", "AQAAAAEAACcQAAAAEEYHpglKQ+4ttt9+WMAlVziOT4CY+wrmlaY6eBOQYbnjDF+aIxBRtxZuI24FFlJCRw==", "d223f228-4987-4049-b051-10b7fba2139c" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dea12856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "995bc8f8-90af-4141-9421-6da02503560e", "AQAAAAEAACcQAAAAEKa5I/KMhe8SX92rsjRwR9zKfNfPX0HgQJ6Xfe09VardglQTPKf5JHC+igDiWn/zsQ==", "0eb8cb66-c71a-4e1b-92b0-643a904bcbb0" });
        }
    }
}
