using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Consultorio.Models
{
    public class Agendamento
    {
        // USANDO DATA ANNOTATIONS
        // [Key]
        public int Id { get; set; }

        // DATA ANNOTATION
        // [Required]
        public string NomePaciente { get; set; }

        public int Idade { get; set; }

        public DateTime Horario { get; set; }
    }
}