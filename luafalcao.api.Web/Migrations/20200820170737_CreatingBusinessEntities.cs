using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace luafalcao.api.Web.Migrations
{
    public partial class CreatingBusinessEntities : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5c72faf9-1d5a-4673-a0be-94d72d4badf0");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "86264df8-83d0-4b65-8079-8254cb75f5f8");

            migrationBuilder.CreateTable(
                name: "Funcionario",
                columns: table => new
                {
                    FuncionarioId = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nome = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    UsuarioId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Funcionario", x => x.FuncionarioId);
                    table.ForeignKey(
                        name: "FK_Funcionario_AspNetUsers_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Recursos",
                columns: table => new
                {
                    RecursoId = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nome = table.Column<string>(nullable: true),
                    NumeroDeVotos = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Recursos", x => x.RecursoId);
                });

            migrationBuilder.CreateTable(
                name: "Votacao",
                columns: table => new
                {
                    VotacaoId = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    DataHora = table.Column<DateTime>(nullable: false),
                    Comentario = table.Column<string>(nullable: true),
                    FuncionarioId = table.Column<int>(nullable: false),
                    RecursoId = table.Column<int>(nullable: false),
                    RecursoId1 = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Votacao", x => x.VotacaoId);
                    table.ForeignKey(
                        name: "FK_Votacao_Funcionario_FuncionarioId",
                        column: x => x.FuncionarioId,
                        principalTable: "Funcionario",
                        principalColumn: "FuncionarioId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Votacao_Recursos_RecursoId",
                        column: x => x.RecursoId,
                        principalTable: "Recursos",
                        principalColumn: "RecursoId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Votacao_Recursos_RecursoId1",
                        column: x => x.RecursoId1,
                        principalTable: "Recursos",
                        principalColumn: "RecursoId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "48cd903a-4de1-4e6b-be80-18e4ee068dc9", "4ce8e062-8276-4460-8b0a-99de3fe8b448", "Administrador", "ADMINISTRADOR" },
                    { "c05ff7ba-d902-4408-8343-238749c14e4b", "5f852c4a-f5d4-4958-91af-9d248b3a8967", "Comum", "Comum" }
                });

            migrationBuilder.InsertData(
                table: "Funcionario",
                columns: new[] { "FuncionarioId", "Email", "Nome", "UsuarioId" },
                values: new object[] { 1, "superadmin@email.com", "Luã Falcão", "9e203a7a-55ac-4186-9a2b-2e0961235316" });

            migrationBuilder.InsertData(
                table: "Recursos",
                columns: new[] { "RecursoId", "Nome", "NumeroDeVotos" },
                values: new object[,]
                {
                    { 1, "Push Notifications", 1 },
                    { 2, "Pagamento usando cartão de crédito e boleto bancário", 0 },
                    { 3, "Leitura de código de barras para realizar compras", 0 }
                });

            migrationBuilder.InsertData(
                table: "Votacao",
                columns: new[] { "VotacaoId", "Comentario", "DataHora", "FuncionarioId", "RecursoId", "RecursoId1" },
                values: new object[] { 1, "Este recurso é importante para o cliente", new DateTime(2020, 8, 20, 14, 7, 36, 918, DateTimeKind.Local).AddTicks(9042), 1, 1, null });

            migrationBuilder.CreateIndex(
                name: "IX_Funcionario_UsuarioId",
                table: "Funcionario",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Votacao_FuncionarioId",
                table: "Votacao",
                column: "FuncionarioId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Votacao_RecursoId",
                table: "Votacao",
                column: "RecursoId");

            migrationBuilder.CreateIndex(
                name: "IX_Votacao_RecursoId1",
                table: "Votacao",
                column: "RecursoId1");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Votacao");

            migrationBuilder.DropTable(
                name: "Funcionario");

            migrationBuilder.DropTable(
                name: "Recursos");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "48cd903a-4de1-4e6b-be80-18e4ee068dc9");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c05ff7ba-d902-4408-8343-238749c14e4b");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "5c72faf9-1d5a-4673-a0be-94d72d4badf0", "90a11652-caea-4baa-9eaf-255b30e97fba", "Administrador", "ADMINISTRADOR" },
                    { "86264df8-83d0-4b65-8079-8254cb75f5f8", "c2bcad75-dd4d-4d81-9388-0f9a8a25adeb", "Comum", "Comum" }
                });
        }
    }
}
