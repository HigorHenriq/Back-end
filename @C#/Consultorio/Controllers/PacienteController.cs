using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Consultorio.Repository;
using Consultorio.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Consultorio.Models;
using Consultorio.Models.Dtos;
using AutoMapper;
using Consultorio.Helpers;

namespace Consultorio.Controllers
{

    [Route("api/[controller]")]
    public class PacienteController : Controller
    {

        private readonly IPacienteRepository _repository;
        private readonly IMapper _mapper;

        public PacienteController(IPacienteRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;

        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {

            // O REPOSITORY VEM DA PACIENTEREPOSIOTYR QUE FIZEMOS A INJEÇÃO DE DEP
            var pacientes = await _repository.GetPacientesAsync();

            // INICIA UMA LISTA DE PACIENTEDTO VAZIA PARA DEPOIS ADD NELA
            List<PacienteDto> pacientesRetorno = new List<PacienteDto>();

            // FAZEMOS O LOOP PARA ADICIONAR AS INFORMAÇOES DOS PACIENTES NA NOSSA DT
            // NA DTO FICARÁ AS INFORMAÇÕES FILTRADAS
            foreach (var paciente in pacientes)
            {
                pacientesRetorno.Add(new PacienteDto { Id = paciente.Id, Nome = paciente.Nome });
            }

            return pacientesRetorno.Any()
            ? Ok(pacientesRetorno)
            : BadRequest("Paciente Não Encontrado");
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            // O REPOSITORY VEM DA PACIENTEREPOSIOTYR QUE FIZEMOS A INJEÇÃO DE DEP
            var paciente = await _repository.GetPacientesByIdAsync(id);

            // AS CONFIG AGORA VEM LÁ DA PASTA HELPERS
            // O MAPPER É INICIADO AGORA NO CONSTRUTOR
            // METODO AUTOMATICO PARA INSERIR OS METODOS NA DTO
            var pacienteDto = _mapper.Map<PacienteDetalhesDto>(paciente);

            // METODO MANUAL PARA INSERIR OS ATRIBUTOS NA DTO
            // var pacienteDto = new PacienteDetalhesDto
            // {
            //     Id = paciente.Id,
            //     Nome = paciente.Nome,
            //     Email = paciente.Email,
            //     Celular = paciente.Celular,
            //     Consultas = new List<Consulta>()
            // };

            return pacienteDto != null
            ? Ok(pacienteDto)
            : BadRequest("Paciente Não Encontrado");
        }

        [HttpPost]
        public async Task<IActionResult> Post(PacienteAdicionarDto paciente)
        {
            if (paciente == null)
            {
                return BadRequest("Dados Incorrentos");

            }

            var pacienteAdicionar = _mapper.Map<Paciente>(paciente);

            _repository.Add(pacienteAdicionar);

            return await _repository.SaveChangesAsync()
            ? Ok("Paciente Adicionado com sucesso!")
            : BadRequest("Erro ao salvar paciente");
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, PacienteAtualizarDto pacienteAtt)
        {
            if (id <= 0)
            {
                return BadRequest("Usuario não informado");
            }

            // BUSCAMOS O PACIENTE LÁ NO BANCO DE DADOS
            var pacienteBanco = await _repository.GetPacientesByIdAsync(id);

            var pacienteAtualizar = _mapper.Map(pacienteAtt, pacienteBanco);

            _repository.Update(pacienteAtualizar);

            return await _repository.SaveChangesAsync()
            ? Ok("Atualizado com sucesso")
            : BadRequest("Erro ao atualizar");
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (id <= 0) return BadRequest("Usuario Invalido");

            var pacienteExcluir = await _repository.GetPacientesByIdAsync(id);

            if (pacienteExcluir == null) return NotFound("Usuario não encontrado");

            _repository.Delete(pacienteExcluir);

            return await _repository.SaveChangesAsync()
            ? Ok("Paciente Deletado com sucesso!")
            : BadRequest("Erro ao deletar paciente");
        }
    }
}