using K2Project.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace K2Project.Juros.Api.Controllers
{
    [Route("[action]")]
    public class CodeController : Controller
    {
        private readonly IJurosService _jurosService;
        public CodeController(IJurosService jurosService)
        {
            _jurosService = jurosService;
        }

        // GET: api/<JurosController>
        [HttpGet]
        public ActionResult ShowMeTheCode()
        {
            try
            {
                return Ok(_jurosService.ObterCodigoFonte());
            }
            catch (Exception ex)
            {
                return new BadRequestObjectResult(ex.Message);
            }
        }
    }
}
