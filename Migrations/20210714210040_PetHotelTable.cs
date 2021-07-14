using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace dotnet_bakery.Migrations
{
    public partial class PetHotelTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PetHotel",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    checkedInAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    name = table.Column<string>(type: "text", nullable: false),
                    petOwnerid = table.Column<int>(type: "integer", nullable: false),
                    breed = table.Column<string>(type: "text", nullable: false),
                    petCount = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PetHotel", x => x.id);
                    table.ForeignKey(
                        name: "FK_PetHotel_PetOwners_petOwnerid",
                        column: x => x.petOwnerid,
                        principalTable: "PetOwners",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PetHotel_petOwnerid",
                table: "PetHotel",
                column: "petOwnerid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PetHotel");
        }
    }
}
