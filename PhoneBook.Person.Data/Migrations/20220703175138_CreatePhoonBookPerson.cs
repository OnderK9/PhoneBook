using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PhoneBook.Person.Data.Migrations
{
    public partial class CreatePhoonBookPerson : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "dbContactType",
                columns: table => new
                {
                    UUID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dbContactType", x => x.UUID);
                });

            migrationBuilder.CreateTable(
                name: "dbPerson",
                columns: table => new
                {
                    UUID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Surname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Company = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dbPerson", x => x.UUID);
                });

            migrationBuilder.CreateTable(
                name: "dbContact",
                columns: table => new
                {
                    UUID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    dbPersonUUID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    dbContactTypeUUID = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dbContact", x => x.UUID);
                    table.ForeignKey(
                        name: "FK_dbContact_dbContactType_dbContactTypeUUID",
                        column: x => x.dbContactTypeUUID,
                        principalTable: "dbContactType",
                        principalColumn: "UUID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_dbContact_dbPerson_dbPersonUUID",
                        column: x => x.dbPersonUUID,
                        principalTable: "dbPerson",
                        principalColumn: "UUID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "dbContactType",
                columns: new[] { "UUID", "Name" },
                values: new object[] { new Guid("914008df-087f-48e9-a71d-54df19d99b6c"), "Telefon" });

            migrationBuilder.InsertData(
                table: "dbContactType",
                columns: new[] { "UUID", "Name" },
                values: new object[] { new Guid("7f567c2f-b5b2-49d6-a896-e26fb97bf157"), "Email" });

            migrationBuilder.InsertData(
                table: "dbContactType",
                columns: new[] { "UUID", "Name" },
                values: new object[] { new Guid("09b56555-eda1-428b-9fc4-465bf2c63502"), "Location" });

            migrationBuilder.CreateIndex(
                name: "IX_dbContact_dbContactTypeUUID",
                table: "dbContact",
                column: "dbContactTypeUUID");

            migrationBuilder.CreateIndex(
                name: "IX_dbContact_dbPersonUUID",
                table: "dbContact",
                column: "dbPersonUUID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "dbContact");

            migrationBuilder.DropTable(
                name: "dbContactType");

            migrationBuilder.DropTable(
                name: "dbPerson");
        }
    }
}
