using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Consultorio.Models;
using Consultorio.Models.Dtos;

namespace Consultorio.Helpers
{
    // EXTENDEMOS DA PROFILE QUE VEM DIRETO DO AUTOMAPPER
    public class ConsultorioProfile : Profile
    {

        public ConsultorioProfile()
        {
            // FAZENDO ASSIM ELE JÁ ADICIONA GLOBALMENTE NO NOSSO PROJETO
            CreateMap<Paciente, PacienteDetalhesDto>()
            // PARA IGNORAR ALGUM VALOR QUE VENHA NA REQUISIÇÃO, ELE IRÁ RETORNAR EMAIL = NULL
            .ForMember(dest => dest.Email, opt => opt.Ignore());


            CreateMap<Consulta, ConsultaDto>()
            // METODOS PARA TRAZER OS NOMES DA ESPECIALIDADE E DOS PROFISSIONAIS
            .ForMember(dest => dest.Especialidade, opt => opt.MapFrom(src => src.Especialidade.Nome))
            .ForMember(dest => dest.Profissional, opt => opt.MapFrom(src => src.Profissional.Nome));


            CreateMap<PacienteAdicionarDto, Paciente>();

            CreateMap<PacienteAtualizarDto, Paciente>()
            // CONFIGURAÇÃO PARA  RETORNAR OS ITENS JÁ EXISTENTES QUANDO FOR NULO
            .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
        }
    }
}