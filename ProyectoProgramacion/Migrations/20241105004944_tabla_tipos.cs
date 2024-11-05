using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProyectoProgramacion.Migrations
{
    /// <inheritdoc />
    public partial class tabla_tipos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "membresia",
                table: "Membresias");

            migrationBuilder.AddColumn<int>(
                name: "TiposMembresia",
                table: "Membresias",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "membresiaID_Membresia",
                table: "Membresias",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "TiposMembresia",
                columns: table => new
                {
                    ID_Membresia = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tipo = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TiposMembresia", x => x.ID_Membresia);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Membresias_membresiaID_Membresia",
                table: "Membresias",
                column: "membresiaID_Membresia");

            migrationBuilder.AddForeignKey(
                name: "FK_Membresias_TiposMembresia_membresiaID_Membresia",
                table: "Membresias",
                column: "membresiaID_Membresia",
                principalTable: "TiposMembresia",
                principalColumn: "ID_Membresia");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Membresias_TiposMembresia_membresiaID_Membresia",
                table: "Membresias");

            migrationBuilder.DropTable(
                name: "TiposMembresia");

            migrationBuilder.DropIndex(
                name: "IX_Membresias_membresiaID_Membresia",
                table: "Membresias");

            migrationBuilder.DropColumn(
                name: "TiposMembresia",
                table: "Membresias");

            migrationBuilder.DropColumn(
                name: "membresiaID_Membresia",
                table: "Membresias");

            migrationBuilder.AddColumn<string>(
                name: "membresia",
                table: "Membresias",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
