using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Consultorio.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Consultorio.Map
{
    public class ProfissionalMap : BaseMap<Profissional>
    {
        public ProfissionalMap() : base("tb_profissional")
        {
        }

        public override void Configure(EntityTypeBuilder<Profissional> builder)
        {
            base.Configure(builder);

            builder.Property(x => x.Nome).HasColumnName("nome").HasColumnType("varchar(100)").IsRequired();
            builder.Property(x => x.Ativo).HasColumnName("ativo");

            // CRIANDO A RELAÇÃO ENTRE PROFISSIONAL E ESPECIALIDADE
            builder.HasMany(x => x.Especialidades)
            .WithMany(x => x.Profissionais)
            // UTILIZAMOS A ENTIDADE QUE CRIAMOS LÁ NA MODELS PARA FAZER ESSE RELACIONAMENTO
            .UsingEntity<ProfissionalEspecialidade>(
                x => x.HasOne(p => p.Especialidade).WithMany().HasForeignKey(x => x.EspecialidadeId),
                x => x.HasOne(p => p.Profissionais).WithMany().HasForeignKey(x => x.ProfissionalId),

                x =>
                {
                    x.ToTable("tb_especialidade_profissional");

                    // CRIAMOS UM NOVO OBJETO ONDE A PRIMEIRA CHAVE É ESPECIALIDADEID E A SEGUNDO PROFISSIONAISID
                    // ELAS SERÃO NOSSAS CHAVES COMPOSTAS
                    x.HasKey(p => new { p.EspecialidadeId, p.ProfissionalId });

                    // DEFININDO O NOME PARA AS NOSSAS CCHAVES COMPOSTAS
                    x.Property(p => p.EspecialidadeId).HasColumnName("id_especialidade").IsRequired();
                    x.Property(p => p.ProfissionalId).HasColumnName("id_profissional").IsRequired();

                }
            );
        }
    }
}