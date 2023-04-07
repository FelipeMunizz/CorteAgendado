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
        public async Task<ActionResult<List<Barbearia>>> Get()
        {
            return await _barbearia.List();
        }
    }
}
