using K2Project.Domain.Interfaces.Repositories;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace K2Project.Infra.Repositoies
{
    public class CodeRepository : ICodeRepository
    {
        private readonly IConfiguration _configuration;
        public CodeRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string ObterCodigoFonte() => _configuration.GetSection("ExternalServices").GetSection("MyGitHubUrl").Value;
    }
}
