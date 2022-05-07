using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Consultorio.Migrations
{
    public partial class PacientesTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tb_consulta_Pacientes_id_paciente",
                table: "tb_consulta");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Pacientes",
                table: "Pacientes");

            migrationBuilder.RenameTable(
                name: "Pacientes",
                newName: "tb_paciente");

            migrationBuilder.RenameColumn(
                name: "Nome",
                table: "tb_paciente",
                newName: "nome");

            migrationBuilder.RenameColumn(
                name: "Email",
                table: "tb_paciente",
                newName: "email");

            migrationBuilder.RenameColumn(
                name: "Cpf",
                table: "tb_paciente",
                newName: "cpf");

            migrationBuilder.RenameColumn(
                name: "Celular",
                table: "tb_paciente",
                newName: "celular");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "tb_paciente",
                newName: "id");

            migrationBuilder.AlterColumn<string>(
                name: "nome",
                table: "tb_paciente",
                type: "varchar(100)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "email",
                table: "tb_paciente",
                type: "varchar(50)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "cpf",
                table: "tb_paciente",
                type: "varchar(11)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "celular",
                table: "tb_paciente",
                type: "varchar(100)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tb_paciente",
                table: "tb_paciente",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_tb_consulta_tb_paciente_id_paciente",
                table: "tb_consulta",
                column: "id_paciente",
                principalTable: "tb_paciente",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tb_consulta_tb_paciente_id_paciente",
                table: "tb_consulta");

            migrationBuilder.DropPrimaryKey(
                name: "PK_tb_paciente",
                table: "tb_paciente");

            migrationBuilder.RenameTable(
                name: "tb_paciente",
                newName: "Pacientes");

            migrationBuilder.RenameColumn(
                name: "nome",
                table: "Pacientes",
                newName: "Nome");

            migrationBuilder.RenameColumn(
                name: "email",
                table: "Pacientes",
                newName: "Email");

            migrationBuilder.RenameColumn(
                name: "cpf",
                table: "Pacientes",
                newName: "Cpf");

            migrationBuilder.RenameColumn(
                name: "celular",
                table: "Pacientes",
                newName: "Celular");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Pacientes",
                newName: "Id");

            migrationBuilder.AlterColumn<string>(
                name: "Nome",
                table: "Pacientes",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(100)");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Pacientes",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(50)");

            migrationBuilder.AlterColumn<string>(
                name: "Cpf",
                table: "Pacientes",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(11)");

            migrationBuilder.AlterColumn<string>(
                name: "Celular",
                table: "Pacientes",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(100)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Pacientes",
                table: "Pacientes",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_tb_consulta_Pacientes_id_paciente",
                table: "tb_consulta",
                column: "id_paciente",
                principalTable: "Pacientes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
