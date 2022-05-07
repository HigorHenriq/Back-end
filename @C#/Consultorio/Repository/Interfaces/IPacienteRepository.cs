using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Consultorio.Models;
using Consultorio.Models.Dtos;

namespace Consultorio.Repository.Interfaces
{
    public interface IPacienteRepository : IBaseRepository
    {

        // POR PADRÃO É RECOMENDADO BOTAR ASYNC NO FINAL DOS METODOS ASSINCRONOS
        // SEMPRE DEVE SER COMO TASK
        Task<IEnumerable<PacienteDto>> GetPacientesAsync();

        Task<Paciente> GetPacientesByIdAsync(int id);
    }
}