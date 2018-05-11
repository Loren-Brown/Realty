using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Realty.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Property",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Bathrooms = table.Column<int>(nullable: false),
                    Bedrooms = table.Column<int>(nullable: false),
                    City = table.Column<string>(nullable: true),
                    DateListed = table.Column<DateTime>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    GarageSize = table.Column<string>(nullable: true),
                    LotSize = table.Column<int>(nullable: false),
                    Neighborhood = table.Column<string>(nullable: true),
                    SalesPrice = table.Column<float>(nullable: false),
                    SquareFeet = table.Column<int>(nullable: false),
                    State = table.Column<string>(nullable: true),
                    Street1 = table.Column<string>(nullable: true),
                    Street2 = table.Column<string>(nullable: true),
                    ZipCode = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Property", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Photo",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ImageData = table.Column<byte[]>(nullable: true),
                    PropertyID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Photo", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Photo_Property_PropertyID",
                        column: x => x.PropertyID,
                        principalTable: "Property",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Photo_PropertyID",
                table: "Photo",
                column: "PropertyID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Photo");

            migrationBuilder.DropTable(
                name: "Property");
        }
    }
}
