using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ftest.Migrations
{
    /// <inheritdoc />
    public partial class slom : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EtdProf_Etd_EtdId",
                table: "EtdProf");

            migrationBuilder.DropForeignKey(
                name: "FK_EtdProf_Prof_ProfId",
                table: "EtdProf");

            migrationBuilder.AddForeignKey(
                name: "FK_EtdProf_Etd_EtdId",
                table: "EtdProf",
                column: "EtdId",
                principalTable: "Etd",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_EtdProf_Prof_ProfId",
                table: "EtdProf",
                column: "ProfId",
                principalTable: "Prof",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EtdProf_Etd_EtdId",
                table: "EtdProf");

            migrationBuilder.DropForeignKey(
                name: "FK_EtdProf_Prof_ProfId",
                table: "EtdProf");

            migrationBuilder.AddForeignKey(
                name: "FK_EtdProf_Etd_EtdId",
                table: "EtdProf",
                column: "EtdId",
                principalTable: "Etd",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_EtdProf_Prof_ProfId",
                table: "EtdProf",
                column: "ProfId",
                principalTable: "Prof",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }
    }
}
