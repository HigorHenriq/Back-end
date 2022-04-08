using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebAPI.Model;

namespace WebAPI.Data
{
    public class UsuarioContext : DbContext
    {

        // CONTRUTOR FEITO E TEM Q SER PASSADO O TIPO DO CONTEXT, Q NO CASO É A NOSSA PROPRIA CLASSE
        public UsuarioContext(DbContextOptions<UsuarioContext> options) 
        : base(options)
        {

        }

        // DbSet IRÁ CRIAR A TABELA DE USUARIO.MODEL NO NOSSO BANCO DE DADOS
        public DbSet<Model.Usuario> Usuarios { get; set; }


        /* UTILIZAMOS O FLUENTAPI PARA SOBRESCREVER AS CONFIGURAÇÕES
         E PERSONALIZAR O BANCO DE DADOS QUANDO ESTIVER RODANDO AS MIGRATIONS 
         PARA ALTERAÇÃO */
        protected override void OnModelCreating(ModelBuilder modelBd)
        {
            var usuarioEnt = modelBd.Entity<Usuario>();

            // MODIFICANDO O NOME DA TABELA
            usuarioEnt.ToTable("tb_usuario");

            // DEFINIMOS QUE A TABELA TEM UM ID
            usuarioEnt.HasKey(user => user.Id);

            // x = Propriedade de usuario

            // IRÁ PEGAR O ID E DAR UM NOME A SUA COLUNA E GERAR SEU VALOR AUTOMATICAMENTE
            usuarioEnt.Property(x => x.Id).HasColumnName("id").ValueGeneratedOnAdd();

            // O CAMPO NOME SERÁ NECESSARIO
            usuarioEnt.Property(x => x.Nome).HasColumnName("nome").IsRequired();

            // 
            usuarioEnt.Property(x => x.Nome).HasColumnName("data_nascimento");

        }
    }
}