using System.Collections.Generic;

namespace Consultorio.Models
{
    public class Especialidade : Base
    {
        public string Nome { get; set; }
        public bool Ativa { get; set; }

        // A ESPECIALIDADE PODE CONTER MAIS DE UM PROFISSIONAL NELA
        public List<Profissional> Profissionais { get; set; }

        // A ESPECIALIDADE PODER SER INSERIDA EM VARIAS CONSULTAS
        public List<Consulta> Consultas { get; set; }
    }
}