using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Consultorio.Data;
using Consultorio.Repository.Interfaces;

namespace Consultorio.Repository
{

    public class BaseRepository : IBaseRepository
    {

        // PADRÃO COLOCAR _ EM ATRIBUTOS PRIVADOS
        private readonly ConsultorioContext _context;

        public BaseRepository(ConsultorioContext context)
        {
            _context = context;
        }


        public void Add<T>(T entity) where T : class
        {
            _context.Add(entity);
        }

        public void Delete<T>(T entity) where T : class
        {
            _context.Remove(entity);
        }

        public async Task<bool> SaveChangesAsync()
        {
            /* O METODO RETORNA 0 OU 1 
            SE TIVER SALVO ALGO RETORNA 1 == TRUE*/
            return await _context.SaveChangesAsync() > 0;
        }

        public void Update<T>(T entity) where T : class
        {
            _context.Update(entity);
        }
    }
}