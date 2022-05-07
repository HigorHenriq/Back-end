using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Consultorio.Data;
using Consultorio.Models;
using Consultorio.Models.Dtos;
using Consultorio.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Consultorio.Repository
{
    public class PacienteRepository : BaseRepository, IPacienteRepository
    {

        // PADRÃO COLOCAR _ EM ATRIBUTOS PRIVADOS
        private readonly ConsultorioContext _context;

        public PacienteRepository(ConsultorioContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<PacienteDto>> GetPacientesAsync()
        {
            // PARA O INCLUDE FUNCIONAR É NECESSARIO INSTALAR O MICROSOFT.MVC.NEWTONSOFTJSON PELO NUGET
            // APÓS LÁ NA PROGRAM EM ADDCONTROLLERS, ADICIONAR O ADDNEWTONSOFTJSON
            // O INCLUDE IRÁ TRAZER JUNTO AS CONSULTAS QUE O PACIENTE TEM MARCADAS
            // É O MESMO PROCESSO QUE FAZER JOIN NO SQL
            // var pacientes = await _context.Pacientes.Include(x => x.Consultas).ToListAsync();

            // METODO PARA RETORNAR OS DADOS MAIS FILTRADOS LÁ DA NOSSA DTO
            var pacientes = await _context.Pacientes.Select(x => new PacienteDto { Id = x.Id, Nome = x.Nome }).ToListAsync();

            return pacientes;
        }

        public async Task<Paciente> GetPacientesByIdAsync(int id)
        {
            var paciente = await _context.Pacientes.Include(x => x.Consultas)
            .ThenInclude(x => x.Especialidade)
            .ThenInclude(x => x.Profissionais)
            .Where(x => x.Id == id).FirstOrDefaultAsync();

            return paciente;
        }
    }
}