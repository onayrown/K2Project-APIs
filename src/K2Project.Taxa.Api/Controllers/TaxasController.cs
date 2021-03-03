using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace K2Project.Taxa.Api.Controllers
{
    [Route("[action]")]
    [ApiController]
    public class TaxasController : ControllerBase
    {
        private const decimal TAXA_JUROS = 0.01m;
        // GET: api/<TaxasController>
        [HttpGet]
        public decimal TaxaJuros()
        {
            return TAXA_JUROS;
        }        
    }
}
