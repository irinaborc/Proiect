using Microsoft.EntityFrameworkCore.Migrations;

namespace Proiect.Migrations
{
    public partial class Producator : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ProducatorID",
                table: "Produs",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Producator",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NumeProducator = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Producator", x => x.ID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Produs_ProducatorID",
                table: "Produs",
                column: "ProducatorID");

            migrationBuilder.AddForeignKey(
                name: "FK_Produs_Producator_ProducatorID",
                table: "Produs",
                column: "ProducatorID",
                principalTable: "Producator",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Produs_Producator_ProducatorID",
                table: "Produs");

            migrationBuilder.DropTable(
                name: "Producator");

            migrationBuilder.DropIndex(
                name: "IX_Produs_ProducatorID",
                table: "Produs");

            migrationBuilder.DropColumn(
                name: "ProducatorID",
                table: "Produs");
        }
    }
}
