using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HouseRentingSystem.Migrations
{
    public partial class FirstLastNameRequired : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                table: "AspNetUsers",
                type: "nvarchar(15)",
                maxLength: 15,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(15)",
                oldMaxLength: 15,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                table: "AspNetUsers",
                type: "nvarchar(12)",
                maxLength: 12,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(12)",
                oldMaxLength: 12,
                oldNullable: true);

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                table: "AspNetUsers",
                type: "nvarchar(15)",
                maxLength: 15,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(15)",
                oldMaxLength: 15);

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                table: "AspNetUsers",
                type: "nvarchar(12)",
                maxLength: 12,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(12)",
                oldMaxLength: 12);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d4350ce-d726-4fc8-83d9-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "458c7edc-7d4d-4776-991d-71749c28ed51", "AQAAAAEAACcQAAAAEJuX+OcDP7fT803j7oaY3Ez3nyvwdPACo2qqkTadCb7d6FCFjCbhjiaTyfsZIU3dbg==", "614f3ce9-c485-492c-98cc-80f37332cc09" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d8e1993f-412b-4cf5-81c6-14123f926f61", "AQAAAAEAACcQAAAAEAZbvCRHBscCWj0kKbkJEFMKM8jX7jKCvf+Cn8kpfHjO537SDmHFgG4DSetOeNf7hQ==", "0e42020a-5b94-418c-a598-c66ba6b9cf5f" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dea12856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "bebcad84-6f9e-4cdc-ba95-86b022a28373", "AQAAAAEAACcQAAAAEHcwpaRCOv0MIRdtrx0aGBdlgh5kuMWlwUBzIIOX1x2QWDkRtyMH83tkHdVPFHDe/Q==", "5186cca7-5bda-4c2a-9d01-ed5425ff4cba" });
        }
    }
}
