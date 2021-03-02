using System;
using System.Collections.Generic;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using K2Project.Domain.Interfaces.Repositories;
using K2Project.Domain.Entities;

namespace K2Project.Infra.Repositoies
{
    public class TaxaJurosRepository : ITaxaJurosRepository
    {

        private readonly IConfiguration _configuration;
        private readonly IHttpClientFactory _clientFactory;
        public TaxaJurosRepository(IConfiguration configuration, IHttpClientFactory client)
        {
            _configuration = configuration;
            _clientFactory = client;
        }
        private string GetAccountRepURL() => _configuration.GetSection("ExternalServices").GetSection("TaxaJurosAPI").Value;
        public async Task<Juros> ObterTaxaJurosAsync(decimal valorInicial, int meses)
        {
            var fullURL = GetAccountRepURL();
            var client = _clientFactory.CreateClient();

            var httpResponse = await client.GetAsync(fullURL);

            if (!httpResponse.IsSuccessStatusCode)
            {
                throw new Exception("Não foi possivel obter as Taxa de Juros do endpoint: " + fullURL);
            }

            var content = await httpResponse.Content.ReadAsStringAsync();
            var taxa = JsonConvert.DeserializeObject<decimal>(content);

            var juros = new Juros(valorInicial, meses, taxa);

            return juros;
        }        
    }
}
