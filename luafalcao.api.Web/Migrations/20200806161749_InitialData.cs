using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace luafalcao.api.Web.Migrations
{
    public partial class InitialData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Artigo",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Titulo = table.Column<string>(nullable: true),
                    Descricao = table.Column<string>(nullable: true),
                    Thumbnail = table.Column<byte[]>(nullable: true),
                    DataPublicacao = table.Column<DateTime>(nullable: false),
                    Link = table.Column<string>(nullable: true),
                    Tags = table.Column<string>(nullable: true),
                    NumeroLikes = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Artigo", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Comentario",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Autor = table.Column<string>(nullable: true),
                    Descricao = table.Column<string>(nullable: true),
                    DataPublicacao = table.Column<DateTime>(nullable: false),
                    Email = table.Column<string>(nullable: true),
                    ArtigoId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comentario", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Comentario_Artigo_ArtigoId",
                        column: x => x.ArtigoId,
                        principalTable: "Artigo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Artigo",
                columns: new[] { "Id", "DataPublicacao", "Descricao", "Link", "NumeroLikes", "Tags", "Thumbnail", "Titulo" },
                values: new object[] { 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Chegou a vez do padrão de projetos Adapter! Vamos ver como usá-lo para tornar o nosso código mais flexível", null, 5, "Design PatternsC#Adapter", null, "Design Patterns #5: Adapter" });

            migrationBuilder.InsertData(
                table: "Artigo",
                columns: new[] { "Id", "DataPublicacao", "Descricao", "Link", "NumeroLikes", "Tags", "Thumbnail", "Titulo" },
                values: new object[] { 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Padrões de projeto são soluções flexíveis e reutilizáveis para problemas frequentes no dia a dia do programador...", null, 10, "Design PatternsC#Orientação a Objetos", null, "Padrões de Projeto e onde habitam" });

            migrationBuilder.InsertData(
                table: "Comentario",
                columns: new[] { "Id", "ArtigoId", "Autor", "DataPublicacao", "Descricao", "Email" },
                values: new object[] { 1, 1, "Jaina Proudmore", new DateTime(1, 1, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "Adorei o Artigo! Parabéns!", null });

            migrationBuilder.InsertData(
                table: "Comentario",
                columns: new[] { "Id", "ArtigoId", "Autor", "DataPublicacao", "Descricao", "Email" },
                values: new object[] { 2, 1, "Iena Hard", new DateTime(1, 1, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "Não concordo com o que você escreveu sobre o Adapter! Ele é mais complexo do que isso! Mas boa tentativa!!", null });

            migrationBuilder.InsertData(
                table: "Comentario",
                columns: new[] { "Id", "ArtigoId", "Autor", "DataPublicacao", "Descricao", "Email" },
                values: new object[] { 3, 2, "Tron", new DateTime(1, 1, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "Padrões de projeto são muito importantes!! Espero que no futuro mais programadores façam uso deles para criar soluções de valor!", null });

            migrationBuilder.CreateIndex(
                name: "IX_Comentario_ArtigoId",
                table: "Comentario",
                column: "ArtigoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Comentario");

            migrationBuilder.DropTable(
                name: "Artigo");
        }
    }
}
