using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Realty.Migrations
{
    public partial class Initial3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Photo_Property_PropertyID",
                table: "Photo");

            migrationBuilder.DropIndex(
                name: "IX_Photo_PropertyID",
                table: "Photo");

            migrationBuilder.RenameColumn(
                name: "PropertyID",
                table: "Photo",
                newName: "PropertyId");

            migrationBuilder.AlterColumn<int>(
                name: "PropertyId",
                table: "Photo",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PropertyId",
                table: "Photo",
                newName: "PropertyID");

            migrationBuilder.AlterColumn<int>(
                name: "PropertyID",
                table: "Photo",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.CreateIndex(
                name: "IX_Photo_PropertyID",
                table: "Photo",
                column: "PropertyID");

            migrationBuilder.AddForeignKey(
                name: "FK_Photo_Property_PropertyID",
                table: "Photo",
                column: "PropertyID",
                principalTable: "Property",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
