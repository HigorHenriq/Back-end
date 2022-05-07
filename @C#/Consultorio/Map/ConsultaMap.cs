using Consultorio.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace Consultorio.Map
{
    public class ConsultaMap : BaseMap<Consulta>
    {
        public ConsultaMap() : base("tb_consulta")
        { }

        public override void Configure(EntityTypeBuilder<Consulta> builder)
        {
            base.Configure(builder);

            // JÁ INICIA COM UM VALOR DEFINIDO
            builder.Property(x => x.Status).HasColumnName("status");
            // ADICIONA A PRECISÃO PARA PEGAR ATÉ OS CENTAVOS
            builder.Property(x => x.Preco).HasPrecision(7, 2).HasColumnName("preco");
            builder.Property(x => x.Preco).HasColumnName("preco");
            builder.Property(x => x.DataHorario).HasColumnName("data_horario").IsRequired();

            builder.Property(x => x.PacienteId).HasColumnName("id_paciente").IsRequired();
            builder.HasOne(x => x.Paciente).WithMany(x => x.Consultas).HasForeignKey(x => x.PacienteId);

            builder.Property(x => x.ProfissionalId).HasColumnName("id_profissional").IsRequired();
            builder.HasOne(x => x.Profissional).WithMany(x => x.Consultas).HasForeignKey(x => x.ProfissionalId);

            builder.Property(x => x.EspecialidadeId).HasColumnName("id_especialidade").IsRequired();
            builder.HasOne(x => x.Especialidade).WithMany(x => x.Consultas).HasForeignKey(x => x.EspecialidadeId);


            // SEMPRE QUE FOR GERADO UMA CONSULTA SERÁ NECESSARIO UM PACIENTE
            builder.Property(x => x.PacienteId).HasColumnName("id_paciente").IsRequired();

            // RELACIONAMENTO PARA O PACIENTE PODER TER UMA OU MAIS CONSULTAS
            builder.HasOne(x => x.Paciente).WithMany(x => x.Consultas).HasForeignKey(x => x.PacienteId);


            // SEMPRE QUE FOR GERADO UMA CONSULTA SERÁ NECESSARIO UM PROFISSIONAL
            builder.Property(x => x.ProfissionalId).HasColumnName("id_profissional").IsRequired();

            // RELACIONAMENTO PARA O PROFISSIONAL PODER TER UMA OU MAIS CONSULTAS
            builder.HasOne(x => x.Profissional).WithMany(x => x.Consultas).HasForeignKey(x => x.ProfissionalId);

            // SEMPRE QUE FOR GERADO UMA CONSULTA SERÁ NECESSARIO A SUA ESPECIALIDADE
            builder.Property(x => x.EspecialidadeId).HasColumnName("id_especialidade").IsRequired();

            // RELACIONAMENTO PARA A ESPECIALIDADE PODER TER UMA OU MAIS CONSULTAS
            builder.HasOne(x => x.Especialidade).WithMany(x => x.Consultas).HasForeignKey(x => x.EspecialidadeId);

        }
    }
}