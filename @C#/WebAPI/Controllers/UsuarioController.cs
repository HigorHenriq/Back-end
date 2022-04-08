using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WebAPI.Model;
using WebAPI.Repository;



namespace WebAPI.Controllers
{
    // [controlelr] = AO NOME QUE FOI DADO DA CONTROLLER ENTÃO O ACESSO SERÁ api/Usuario
    [Route("api/[controller]")]

    // : DOIS PONTOS = HERDA COISAS DA OUTRA CLASSE É TIPO O EXTENDS
    public class UsuarioController : Controller
    {

        // METODO ESTATICO PARA PODER TER ACESSO A LISTA DE USUARIOS
        // private static List<Usuario> Usuarios()
        // {
        //     return new List<Usuario>{
        //         new Usuario {
        //             Id = 1,
        //             Nome = "Teste",
        //             DataNascimento = "1994-01-21T00:26:17.469Z"
        //         }
        //     };
        // }

        // PUXAR E EFETUAR A INJEÇÃO DE DEPENDENCIA
        private readonly IUsuarioRepository _userRepo;

        // hot key = ctor para criar um construtor

        public UsuarioController(IUsuarioRepository repository)
        {
            _userRepo = repository;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {

            var usuarios = await _userRepo.BuscarUsuarios();

            // RETORNA UMA RESPONSE OK
            // E O BODY SERÁ A LISTA DE USUARIOS
            // CASO TENHA QUALQUER USUARIO RETORNA O BODY COM ELES SE N, RETORNA APENBAS NOTFOUND
            return usuarios.Any()
            ? Ok(usuarios)
            : NoContent();
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {

            var usuario = await _userRepo.BuscaUsuarioPorID(id);

            // RETORNA UMA RESPONSE OK
            // E O BODY SERÁ A LISTA DE USUARIOS
            // CASO O USUARIO SEJA DIFERENTE DE NULO
            return usuario != null
            ? Ok(usuario)
            : NotFound("Usuario não encontrado");
        }

        [HttpPost]

        public async Task<IActionResult> Post(Usuario novoUsuario)
        {

            // METODO COM USUARIO ESTATICO
            // ARMAZENAMOS A LISTA DE USUARIOS EM UMA VARIAVEL
            // var usuarios = Usuarios();

            // ADICIONAMOS LÁ NA LISTA O NOVOUSUARIO QUE ESTÁ VINDO DO PARAMETRO
            // usuarios.Add(novoUsuario);

            // E O REPSONSE SERÁ A LISTA COMPLETA DE USUARIOS
            // return Ok(usuarios);

            // METODO A PARTIR DA REPOSITORY

            _userRepo.AdicionaUsuario(novoUsuario);

            return await _userRepo.SaveChangesAsync()
            ? Ok("Usuario Adicionado Com Sucesso!")
            : BadRequest("Erro ao salvar usuario!");
        }

        [HttpPut("{id}")]

        public async Task<IActionResult> Put(int id, Usuario updatedUsuario)
        {

            var usuario = await _userRepo.BuscaUsuarioPorID(id);

            if (usuario == null)
            {
                return NotFound("Não encontrado");
            }


            // VERIFICA SE FOI PASSADO ALGUM NOME NO UPDATE, CASO NÃO CONTINUA O MESMO
            usuario.Nome = updatedUsuario.Nome ?? usuario.Nome;
            // VERIFICA SE NÃO FOI PASSADO ALGUM Data Nascimento NO UPDATE CONTINUA O MESMO, SE NÃO RECEBE A NOVA
            usuario.DataNascimento = updatedUsuario.DataNascimento != new DateTime()
            ? updatedUsuario.DataNascimento : usuario.DataNascimento;

            _userRepo.AtualizarUsuario(usuario);

            return await _userRepo.SaveChangesAsync()
            ? Ok("Usuario Atualizado Com Sucesso!")
            : BadRequest("Erro ao atualizar usuario!");
        }

        [HttpDelete("{id}")]

        public async Task<IActionResult> Deletar(int id)
        {
            var usuario = await _userRepo.BuscaUsuarioPorID(id);

            if (usuario == null)
            {
                return NotFound("Não encontrado");
            }

            _userRepo.RemoverUsuario(usuario);

            return await _userRepo.SaveChangesAsync()
            ? Ok("Usuario Removido Com Sucesso!")
            : BadRequest("Erro ao remover usuario!");
        }

    }
}