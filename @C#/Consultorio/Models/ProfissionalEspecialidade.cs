namespace Consultorio.Models
{
    // ENTIDADE PARA O RELACIONAMENTO ENTRE PROFISSIONAL E ESPECIALIDADE
    // RELAÇÃO FEITA LÁ EM PROFISSIONALMAP
    public class ProfissionalEspecialidade
    {
        public int ProfissionalId { get; set; }
        public Profissional Profissionais { get; set; }
        public int EspecialidadeId { get; set; }
        public Especialidade Especialidade { get; set; }
    }
}