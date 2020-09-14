using Account.Domain;
using Account.Services.LancamentoService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Account.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    [AllowAnonymous]
    public class LancamentoController : ControllerBase
    {
        private ILancamentoService _lancamentoService { get; set; }

        public LancamentoController(ILancamentoService lancamentoService)
        {
            _lancamentoService = lancamentoService;
        }

        [HttpPost]
        public IActionResult Post([FromBody] Operacao operacao)
        {
            var result = _lancamentoService.Lancar(operacao);

            if (!result.Success)
            {
                return BadRequest(result.Message);
            }

            return Ok();
        }
    }
}