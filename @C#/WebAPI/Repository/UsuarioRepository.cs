using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Model;
using WebAPI.Data;
using Microsoft.EntityFrameworkCore;

namespace WebAPI.Repository
{
    // EXTENDEMOS PARA A NOSSA INTERFACE PARA IMPLEMENTAR SEUS METODOS
    public class UsuarioRepository : IUsuarioRepository
    {

        // PUXAR E EFETUAR A INJEÇÃO DE DEPENDENCIA
        private readonly UsuarioContext _context;

        public UsuarioRepository(UsuarioContext context)
        {
            this._context = context;
        }

        public async Task<IEnumerable<Usuario>> BuscarUsuarios()
        {
            return await _context.Usuarios.ToListAsync();
        }

        public async Task<Usuario> BuscaUsuarioPorID(int id)
        {
            return await _context.Usuarios.Where(user => user.Id == id).FirstOrDefaultAsync();
        }

        public void AdicionaUsuario(Usuario novoUsuario)
        {
            _context.Add(novoUsuario);
        }

        public void AtualizarUsuario(Usuario updateUsuario)
        {
            _context.Update(updateUsuario);
        }

        public void RemoverUsuario(Usuario usuario)
        {
            _context.Remove(usuario);
        }

        public async Task<bool> SaveChangesAsync()
        {
            /* O METODO RETORNA 0 OU 1 
            SE FOR SIM SALVA = TRUE(1)
            SE NÃO SALVAR = FALSE(0)*/
            return await _context.SaveChangesAsync() > 0;
        }
    }
}