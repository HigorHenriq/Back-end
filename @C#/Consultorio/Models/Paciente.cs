using System.Collections.Generic;

namespace Consultorio.Models
{
    public class Paciente : Base
    {
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Celular { get; set; }
        public string Cpf { get; set; }

        // UM PACIENTE PODE TER 1 OU MAIS CONSULTAS
        public List<Consulta> Consultas { get; set; }
    }
}