using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Consultorio.Data;
using Consultorio.Models.Dtos;
using Consultorio.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Consultorio.Repository
{
    public class ProfissionalRepository : BaseRepository, IProfissionalRepository
    {
        private readonly ConsultorioContext _context;

        public ProfissionalRepository(ConsultorioContext context) : base(context)
        {
            this._context = context;
        }

        public async Task<IEnumerable<ProfissionalDto>> GetProfissionais()
        {

            var profissionais = await _context.Profissionais
              // FAZER MAPEAMENTO MAIS RAPIDO PQ É MENOS CAMPOS
              .Select(x => new ProfissionalDto { Id = x.Id, Nome = x.Nome, Ativo = x.Ativo }).ToListAsync();

            return profissionais;
        }

        public Task<IEnumerable<ProfissionalDto>> GetProfissionalById()
        {
            throw new NotImplementedException();
        }

        public Task<ProfissionalDetalhesDto> GetProfissionalById(int id)
        {
            throw new NotImplementedException();
        }
    }
}