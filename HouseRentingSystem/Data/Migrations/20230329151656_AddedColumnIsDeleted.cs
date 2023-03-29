using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HouseRentingSystem.Migrations
{
    public partial class AddedColumnIsDeleted : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Houses",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d4350ce-d726-4fc8-83d9-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "30e5678a-ba36-44de-a738-cc7fc5e97774", "AQAAAAEAACcQAAAAEGuPH1qwFrM/omeMgEJXYKGEGn2VzI0bKyUnBprwjSCFp6dMOkfD/cTwlrVqyheSOg==", "21bd0408-01ef-4d8b-82aa-f56e490ab902" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d3d67150-8b92-432f-960f-8c212583822b", "AQAAAAEAACcQAAAAEMtrbNuu3FZ9/fxYAObBRgwZaKv1wq4X9flAp9UChucaV4bsTT0ZPpo/OcBWyxDq0g==", "9495d11e-2ef1-4c68-9f37-70e3cb5383e8" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dea12856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f175ff2a-b02d-484b-94da-588309b82e01", "AQAAAAEAACcQAAAAEO6k8BL++w+VEyMRqPu/iPyrm4yK9YsRDOyzudxWGO5ic37Ga4fzSk4plAQFMRK82Q==", "91bccebe-b022-4ef2-842d-c752d73e3fed" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Houses");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d4350ce-d726-4fc8-83d9-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "0166f546-f242-4eeb-8951-990724825083", "AQAAAAEAACcQAAAAEC1ndCLeK1nbH4U7ZJ+3uUraf6Ip4jTbhzurbSMVsLFDmZDs4WbNApq6fwLVReAu6g==", "ae671384-4039-4024-951f-8c50de30535b" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f4ea7262-afd6-4ac5-9602-18953e6a9755", "AQAAAAEAACcQAAAAEEO8HpvJrmXhylhIzTtZQ2AZojeEJLUHiBPLqdaWqafxe2s4so22Wapc349B5bU3DA==", "40dc006c-37de-4b08-8a10-ec897656b2e9" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dea12856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "72414659-06be-4510-b416-282347192982", "AQAAAAEAACcQAAAAENeQhtG/0xKwtIWA6CE720MjEA7Ih428HzAVdnDScezfii9fVEh6HRVRnG6RQU0YDg==", "c367f45c-4967-42ab-84b4-53b224223826" });
        }
    }
}
