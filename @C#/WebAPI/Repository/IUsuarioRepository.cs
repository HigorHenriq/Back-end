using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Model;

namespace WebAPI.Repository
{
    public interface IUsuarioRepository
    {

        // É UTILIZADO DE FORMA ASSINCRONA PQ IRÁ NO BANCO DE DADOS E DEPOIS RETORNAR
        Task<IEnumerable<Usuario>> BuscarUsuarios();

        Task<Usuario> BuscaUsuarioPorID(int id);

        void AdicionaUsuario(Usuario novoUsuario);
        void AtualizarUsuario(Usuario updateUsuario);
        void RemoverUsuario(Usuario usuario);

        // METODO PARA SALVAR METODOS ASSINCRONOS
        Task<bool> SaveChangesAsync();
    }
}