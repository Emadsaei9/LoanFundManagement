using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LoanFundManagement.Migrations
{
    /// <inheritdoc />
    public partial class UpdatePersonAndTvamRelations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Tvams",
                columns: table => new
                {
                    KeyVam = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    VamNumber = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    RowPerson = table.Column<int>(type: "INTEGER", nullable: false),
                    VamAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    VamDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    NumberVam = table.Column<int>(type: "INTEGER", nullable: false),
                    Zamenid = table.Column<int>(type: "INTEGER", nullable: true),
                    Zamenname = table.Column<string>(type: "TEXT", nullable: false),
                    Paytype = table.Column<string>(type: "TEXT", nullable: false),
                    CHkserial = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tvams", x => x.KeyVam);
                    table.ForeignKey(
                        name: "FK_Tvams_Persons_RowPerson",
                        column: x => x.RowPerson,
                        principalTable: "Persons",
                        principalColumn: "PersonId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Tvams_Persons_Zamenid",
                        column: x => x.Zamenid,
                        principalTable: "Persons",
                        principalColumn: "PersonId",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tvams_RowPerson",
                table: "Tvams",
                column: "RowPerson");

            migrationBuilder.CreateIndex(
                name: "IX_Tvams_Zamenid",
                table: "Tvams",
                column: "Zamenid");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tvams");
        }
    }
}
