using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Consultorio.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Consultorio.Controllers
{
    [Route("api/[controller]")]
    public class ProfissionalController : Controller
    {
        private readonly IProfissionalRepository _repository;

        public ProfissionalController(IProfissionalRepository repository)
        {
            this._repository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> GetProfissionais()
        {
            var profissionais = await _repository.GetProfissionais();

            return profissionais.Any()
            ? Ok(profissionais)
            : NotFound("Pacientes não encontrados");
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProfissionalById(int id)
        {

            if (id <= 0) return BadRequest("Profissional não encontrado");

            var profissional = await _repository.GetProfissionais();

            return profissional.Any()
            ? Ok(profissional)
            : NotFound("Pacientes não encontrados");
        }

    }
}