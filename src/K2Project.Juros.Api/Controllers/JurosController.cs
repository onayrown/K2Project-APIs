using K2Project.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace K2Project.Juros.Api.Controllers
{
    [Route("api/v1/[controller]/[action]")]
    [ApiController]
    public class JurosController : ControllerBase
    {
        private readonly IJurosService _jurosService;
        public JurosController(IJurosService jurosService)
        {
            _jurosService = jurosService;
        }

        // GET: api/<JurosController>
        [HttpGet]
        public async Task<IActionResult> CalculaJuros(decimal valorInicial, int meses)
        {
            try
            {
                return Ok(await _jurosService.ObterValorFinal(valorInicial, meses));
            }
            catch (Exception ex)
            {
                return new BadRequestObjectResult(ex.Message);
            }
        }
    }
}
