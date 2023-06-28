using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Repositories.Migrations
{
    /// <inheritdoc />
    public partial class FilmeMigrationInitial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "diretor",
                columns: table => new
                {
                    idDiretor = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nome = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_diretor", x => x.idDiretor);
                });

            migrationBuilder.CreateTable(
                name: "estilo",
                columns: table => new
                {
                    idEstilo = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    descricao = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_estilo", x => x.idEstilo);
                });

            migrationBuilder.CreateTable(
                name: "filme",
                columns: table => new
                {
                    idFilme = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nome = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    duracao = table.Column<int>(type: "int", nullable: false),
                    ano = table.Column<int>(type: "int", nullable: false),
                    EstiloId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_filme", x => x.idFilme);
                    table.ForeignKey(
                        name: "FK_filme_estilo_EstiloId",
                        column: x => x.EstiloId,
                        principalTable: "estilo",
                        principalColumn: "idEstilo",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Ator",
                columns: table => new
                {
                    idAtor = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nome = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    papel = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FilmeId = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ator", x => x.idAtor);
                    table.ForeignKey(
                        name: "FK_Ator_filme_FilmeId",
                        column: x => x.FilmeId,
                        principalTable: "filme",
                        principalColumn: "idFilme");
                });

            migrationBuilder.CreateTable(
                name: "DiretorFilme",
                columns: table => new
                {
                    DiretoresId = table.Column<long>(type: "bigint", nullable: false),
                    FilmesId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DiretorFilme", x => new { x.DiretoresId, x.FilmesId });
                    table.ForeignKey(
                        name: "FK_DiretorFilme_diretor_DiretoresId",
                        column: x => x.DiretoresId,
                        principalTable: "diretor",
                        principalColumn: "idDiretor",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DiretorFilme_filme_FilmesId",
                        column: x => x.FilmesId,
                        principalTable: "filme",
                        principalColumn: "idFilme",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Ator_FilmeId",
                table: "Ator",
                column: "FilmeId");

            migrationBuilder.CreateIndex(
                name: "IX_DiretorFilme_FilmesId",
                table: "DiretorFilme",
                column: "FilmesId");

            migrationBuilder.CreateIndex(
                name: "IX_filme_EstiloId",
                table: "filme",
                column: "EstiloId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Ator");

            migrationBuilder.DropTable(
                name: "DiretorFilme");

            migrationBuilder.DropTable(
                name: "diretor");

            migrationBuilder.DropTable(
                name: "filme");

            migrationBuilder.DropTable(
                name: "estilo");
        }
    }
}
