using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Consultorio.Models;
using Consultorio.Services;

namespace Consultorio.Controllers
{
    [Route("api/[controller]")]
    public class AgendamentoController : Controller
    {
        // METODO UTILIZADO COM INFORMAÇÕES MOCKADAS
        //     private readonly IEmailService _emailService;
        //     List<Agendamento> agendamentos = new List<Agendamento>();

        //     // Construtor
        //     public AgendamentoController(IEmailService emailService)
        //     {
        //         agendamentos.Add(new Agendamento
        //         {
        //             Id = 1,
        //             NomePaciente = "Claudin",
        //             Horario = new DateTime(2021, 03, 15)
        //         });
        //         this._emailService = emailService;
        //     }

        //     [HttpGet]
        //     public IActionResult Get()
        //     {
        //         return Ok(agendamentos);
        //     }


        //     [HttpGet("{id}")]
        //     public IActionResult GetById(int id)
        //     {
        //         var agendamentoSelecionado = agendamentos.FirstOrDefault(agenda => agenda.Id == id);

        //         return agendamentoSelecionado != null
        //         ? Ok(agendamentos)
        //         : BadRequest("Não encontrado");
        //     }

        //     [HttpPost]
        //     public IActionResult Post()
        //     {
        //         var pacienteAgendado = true;



        //         if (pacienteAgendado)
        //         {
        //             _emailService.EnviarEmail("cleitoRasta@gmail.com");
        //         }

        //         return Ok();
        //     }


        // METODO REAL


        public AgendamentoController()
        {

        }
    }
}