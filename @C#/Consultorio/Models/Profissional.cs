using System.Collections.Generic;

namespace Consultorio.Models
{
    public class Profissional : Base
    {
        public string Nome { get; set; }
        public bool Ativo { get; set; }

        // PROFISSIONAL PODE SER INCLUIDO EM VARIAS CONSULTAS
        public List<Consulta> Consultas { get; set; }

        // O PROFISSIONAL PODE TER VARIAS ESPECIALIDADES
        public List<Especialidade> Especialidades { get; set; }
    }
}