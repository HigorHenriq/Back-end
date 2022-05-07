using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Consultorio.Migrations
{
    public partial class RelacionamentoProfissionaisEspecialidadesConsultas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EspecialidadeProfissional_Especialidade_EspecialidadesId",
                table: "EspecialidadeProfissional");

            migrationBuilder.DropForeignKey(
                name: "FK_EspecialidadeProfissional_Profissional_ProfissionaisId",
                table: "EspecialidadeProfissional");

            migrationBuilder.DropForeignKey(
                name: "FK_tb_consulta_Especialidade_id_especialidade",
                table: "tb_consulta");

            migrationBuilder.DropForeignKey(
                name: "FK_tb_consulta_Profissional_id_profissional",
                table: "tb_consulta");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Profissional",
                table: "Profissional");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Especialidade",
                table: "Especialidade");

            migrationBuilder.RenameTable(
                name: "Profissional",
                newName: "Profissionais");

            migrationBuilder.RenameTable(
                name: "Especialidade",
                newName: "Especialidades");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Profissionais",
                table: "Profissionais",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Especialidades",
                table: "Especialidades",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_EspecialidadeProfissional_Especialidades_EspecialidadesId",
                table: "EspecialidadeProfissional",
                column: "EspecialidadesId",
                principalTable: "Especialidades",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EspecialidadeProfissional_Profissionais_ProfissionaisId",
                table: "EspecialidadeProfissional",
                column: "ProfissionaisId",
                principalTable: "Profissionais",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EspecialidadeProfissional_Especialidades_EspecialidadesId",
                table: "EspecialidadeProfissional");

            migrationBuilder.DropForeignKey(
                name: "FK_EspecialidadeProfissional_Profissionais_ProfissionaisId",
                table: "EspecialidadeProfissional");

            migrationBuilder.DropForeignKey(
                name: "FK_tb_consulta_Especialidades_id_especialidade",
                table: "tb_consulta");

            migrationBuilder.DropForeignKey(
                name: "FK_tb_consulta_Profissionais_id_profissional",
                table: "tb_consulta");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Profissionais",
                table: "Profissionais");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Especialidades",
                table: "Especialidades");

            migrationBuilder.RenameTable(
                name: "Profissionais",
                newName: "Profissional");

            migrationBuilder.RenameTable(
                name: "Especialidades",
                newName: "Especialidade");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Profissional",
                table: "Profissional",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Especialidade",
                table: "Especialidade",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_EspecialidadeProfissional_Especialidade_EspecialidadesId",
                table: "EspecialidadeProfissional",
                column: "EspecialidadesId",
                principalTable: "Especialidade",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EspecialidadeProfissional_Profissional_ProfissionaisId",
                table: "EspecialidadeProfissional",
                column: "ProfissionaisId",
                principalTable: "Profissional",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_tb_consulta_Especialidade_id_especialidade",
                table: "tb_consulta",
                column: "id_especialidade",
                principalTable: "Especialidade",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_tb_consulta_Profissional_id_profissional",
                table: "tb_consulta",
                column: "id_profissional",
                principalTable: "Profissional",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
