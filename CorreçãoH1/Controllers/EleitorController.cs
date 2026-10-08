using CorreçãoH1.Interfaces;
using CorreçãoH1.Models;
using Microsoft.AspNetCore.Mvc;

namespace CorreçãoH1.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EleitorController : ControllerBase
    {
        private readonly IEleitorRepository _repository;

        public EleitorController(IEleitorRepository repository)
        {
            _repository = repository;
        }

        // 1. Cadastrar eleitor - POST
        [HttpPost]
        public IActionResult CadastrarEleitor(Eleitor eleitor)
        {
            bool cadastrado = _repository.CadastrarEleitor(eleitor);

            if (!cadastrado)
            {
                return BadRequest(new
                {
                    mensagem = "Já existe um eleitor cadastrado com esse CPF."
                });
            }

            return Created("", new
            {
                mensagem = "Eleitor cadastrado com sucesso.",
                eleitor
            });
        }

        // 2. Listar eleitores - GET
        [HttpGet]
        public IActionResult ListarEleitores()
        {
            return Ok(_repository.ListarEleitores());
        }

        // 3. Registrar ausência - POST
        [HttpPost("justificativas")]
        public IActionResult RegistrarJustificativa(
            Justificativa justificativa)
        {
            bool eleitorExiste = _repository
                .ListarEleitores()
                .Any(e => e.CPF == justificativa.CPF);

            if (!eleitorExiste)
            {
                return NotFound(new
                {
                    mensagem = "Eleitor não encontrado. A justificativa não pode ser registrada."
                });
            }

            bool registrada = _repository
                .RegistrarJustificativa(justificativa);

            if (!registrada)
            {
                return BadRequest(new
                {
                    mensagem = "Esse eleitor já possui uma justificativa registrada para esse turno."
                });
            }

            return Ok(new
            {
                mensagem = "Justificativa registrada com sucesso."
            });
        }

        // 4. Consultar justificativas - GET
        [HttpGet("justificativas")]
        public IActionResult ListarJustificativas()
        {
            return Ok(_repository.ListarJustificativas());
        }
    }
}