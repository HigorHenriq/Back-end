using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Consultorio.Models;

namespace Consultorio.Data
{
    // DB CONTEXT PARA CONEXÃO COM BANCO DE DADOS
    public class ConsultorioContext : DbContext
    {

        public ConsultorioContext(DbContextOptions<ConsultorioContext> options) : base(options)
        {

        }

        public DbSet<Consulta> Consultas { get; set; }
        public DbSet<Especialidade> Especialidades { get; set; }
        public DbSet<Paciente> Pacientes { get; set; }
        public DbSet<Profissional> Profissionais { get; set; }


        // public DbSet<Models.Agendamento> Agendamentos { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            // AS PROPRIEDADES DE EDIÇÃO DO BH FICA NA PASTA MAP
            base.OnModelCreating(modelBuilder);

            // CRIA A CONFIGURAÇÃO PARA PEGAR O ASSEMBLY LÁ NA PROGRAM
            modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);

            // METODO PARA ALTERAR PASSO-A-PASSO AS PROPRIEDADES NO BANCO DE DADOS

            // var agendamento = modelBuilder.Entity<Agendamento>();

            // agendamento.ToTable("tb_agendamento");

            // agendamento.HasKey(x => x.Id);
            // agendamento.Property(x => x.Idade).HasColumnType("integer").HasColumnName("idade");
            // agendamento.Property(x => x.NomePaciente).HasColumnName("nome_paciente").HasColumnType("varchar(100)").IsRequired();
            // agendamento.Property(x => x.Horario).HasColumnName("horario").IsRequired();

        }

    }
}