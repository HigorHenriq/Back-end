using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Consultorio.Migrations
{
    public partial class RelacionamentoManyToMany : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tb_consulta_Especialidades_id_especialidade",
                table: "tb_consulta");

            migrationBuilder.DropForeignKey(
                name: "FK_tb_consulta_Profissionais_id_profissional",
                table: "tb_consulta");

            migrationBuilder.DropTable(
                name: "EspecialidadeProfissional");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Profissionais",
                table: "Profissionais");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Especialidades",
                table: "Especialidades");

            migrationBuilder.RenameTable(
                name: "Profissionais",
                newName: "tb_profissional");

            migrationBuilder.RenameTable(
                name: "Especialidades",
                newName: "tb_especialidade");

            migrationBuilder.RenameColumn(
                name: "Nome",
                table: "tb_profissional",
                newName: "nome");

            migrationBuilder.RenameColumn(
                name: "Ativo",
                table: "tb_profissional",
                newName: "ativo");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "tb_profissional",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "Nome",
                table: "tb_especialidade",
                newName: "nome");

            migrationBuilder.RenameColumn(
                name: "Ativa",
                table: "tb_especialidade",
                newName: "ativa");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "tb_especialidade",
                newName: "id");

            migrationBuilder.AlterColumn<string>(
                name: "nome",
                table: "tb_profissional",
                type: "varchar(100)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tb_profissional",
                table: "tb_profissional",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tb_especialidade",
                table: "tb_especialidade",
                column: "id");

            migrationBuilder.CreateTable(
                name: "tb_especialidade_profissional",
                columns: table => new
                {
                    id_profissional = table.Column<int>(type: "integer", nullable: false),
                    id_especialidade = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_especialidade_profissional", x => new { x.id_especialidade, x.id_profissional });
                    table.ForeignKey(
                        name: "FK_tb_especialidade_profissional_tb_especialidade_id_especiali~",
                        column: x => x.id_especialidade,
                        principalTable: "tb_especialidade",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tb_especialidade_profissional_tb_profissional_id_profission~",
                        column: x => x.id_profissional,
                        principalTable: "tb_profissional",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tb_especialidade_profissional_id_profissional",
                table: "tb_especialidade_profissional",
                column: "id_profissional");

            migrationBuilder.AddForeignKey(
                name: "FK_tb_consulta_tb_especialidade_id_especialidade",
                table: "tb_consulta",
                column: "id_especialidade",
                principalTable: "tb_especialidade",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_tb_consulta_tb_profissional_id_profissional",
                table: "tb_consulta",
                column: "id_profissional",
                principalTable: "tb_profissional",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tb_consulta_tb_especialidade_id_especialidade",
                table: "tb_consulta");

            migrationBuilder.DropForeignKey(
                name: "FK_tb_consulta_tb_profissional_id_profissional",
                table: "tb_consulta");

            migrationBuilder.DropTable(
                name: "tb_especialidade_profissional");

            migrationBuilder.DropPrimaryKey(
                name: "PK_tb_profissional",
                table: "tb_profissional");

            migrationBuilder.DropPrimaryKey(
                name: "PK_tb_especialidade",
                table: "tb_especialidade");

            migrationBuilder.RenameTable(
                name: "tb_profissional",
                newName: "Profissionais");

            migrationBuilder.RenameTable(
                name: "tb_especialidade",
                newName: "Especialidades");

            migrationBuilder.RenameColumn(
                name: "nome",
                table: "Profissionais",
                newName: "Nome");

            migrationBuilder.RenameColumn(
                name: "ativo",
                table: "Profissionais",
                newName: "Ativo");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Profissionais",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "nome",
                table: "Especialidades",
                newName: "Nome");

            migrationBuilder.RenameColumn(
                name: "ativa",
                table: "Especialidades",
                newName: "Ativa");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Especialidades",
                newName: "Id");

            migrationBuilder.AlterColumn<string>(
                name: "Nome",
                table: "Profissionais",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(100)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Profissionais",
                table: "Profissionais",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Especialidades",
                table: "Especialidades",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "EspecialidadeProfissional",
                columns: table => new
                {
                    EspecialidadesId = table.Column<int>(type: "integer", nullable: false),
                    ProfissionaisId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EspecialidadeProfissional", x => new { x.EspecialidadesId, x.ProfissionaisId });
                    table.ForeignKey(
                        name: "FK_EspecialidadeProfissional_Especialidades_EspecialidadesId",
                        column: x => x.EspecialidadesId,
                        principalTable: "Especialidades",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EspecialidadeProfissional_Profissionais_ProfissionaisId",
                        column: x => x.ProfissionaisId,
                        principalTable: "Profissionais",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EspecialidadeProfissional_ProfissionaisId",
                table: "EspecialidadeProfissional",
                column: "ProfissionaisId");

            migrationBuilder.AddForeignKey(
                name: "FK_tb_consulta_Especialidades_id_especialidade",
                table: "tb_consulta",
                column: "id_especialidade",
                principalTable: "Especialidades",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_tb_consulta_Profissionais_id_profissional",
                table: "tb_consulta",
                column: "id_profissional",
                principalTable: "Profissionais",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
