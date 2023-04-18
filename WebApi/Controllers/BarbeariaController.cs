using Domain.Interfaces;
using Entities.Entidades;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BarbeariaController : ControllerBase
    {
        private readonly IBarbearia _barbearia;

        public BarbeariaController(IBarbearia barbearia)
        {
            _barbearia = barbearia;
        }

        [HttpGet]
        public async Task<ActionResult<List<Barbearia>>> GetAll()
        {
            return await _barbearia.List();
        }

        [HttpGet("{id:int}", Name = "ObterBarbearia")]
        public async Task<ActionResult<Barbearia>> Get(int id)
        {
            Barbearia barbearia = await _barbearia.GetEntityById(id);

            if(barbearia == null)
                return BadRequest("Barbearia não encontrada");

            return Ok(barbearia);
        }

        [HttpGet("{nome}", Name = "ObterBarbeariaByNome")]
        public async Task<ActionResult<Barbearia>> GetBarbearia(string nome)
        {
            var barbearia = await _barbearia.GetBarbeariaByNome(nome);
            if (barbearia == null)
                return BadRequest("Barbearia não encontrada");

            return Ok(barbearia);
        }

        [HttpPost("IncluirBarbearia")]
        public async Task<IActionResult> Post([FromBody]Barbearia barbearia)
        {
            await _barbearia.Add(barbearia);
            return new CreatedAtRouteResult("ObterBarbearia",
                new { id = barbearia.BarbeariaId }, barbearia);
        }

        [HttpGet("{id:int}", Name = "ListaFuncionariosBarbearia")]
        public async Task<IActionResult> GetBarbeariaFuncionarios(int id)
        {
            return Ok();
        }
    }
}
