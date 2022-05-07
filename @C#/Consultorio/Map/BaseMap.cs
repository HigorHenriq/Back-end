using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Consultorio.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Consultorio.Map
{
    // BOTA A CLASS ENTRE <T> PARA TORNALA GENERICA
    // E PODER SOBRESCREVER ELA EM OUTRAS CLASSE
    public class BaseMap<T> : IEntityTypeConfiguration<T> where T : Base
        // BASE É Á ENTIDADE LÁ DE MODELS
    {

        // PADRÃO COLOCAR _ EM ATRIBUTOS PRIVADOS
        private readonly string _tableName;

        public BaseMap(string tableName)
        {
            _tableName = tableName;
        }

        // VIRTUAL PARA PODER DAR OVERRIDE NESSE METODO EM OUTRAS CLASSES
        public virtual void Configure(EntityTypeBuilder<T> builder)
        {
            // SE O NOME DA TABELA NÃO VIER VAZIA CRIA ELA
            if (!string.IsNullOrEmpty(_tableName))
            {
                builder.ToTable(_tableName);
            }

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasColumnName("id").ValueGeneratedOnAdd();
        }
    }
}