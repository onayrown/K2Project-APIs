using FluentAssertions;
using Microsoft.AspNetCore.Mvc.Testing;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace K2Project.Tests.IntegrationTests
{
    public class JurosControllerTests : IClassFixture<WebApplicationFactory<Juros.Api.Startup>>
    {
        public HttpClient _client { get; }

        public JurosControllerTests(WebApplicationFactory<Juros.Api.Startup> fixture)
        {
            _client = fixture.CreateClient();
        }

        [Fact]
        public async Task Juros_DeveRetornar_OkResponse()
        {
            var response = await _client.GetAsync("api/v1/Juros/CalculaJuros?valorInicial=100&meses=5");
            response.EnsureSuccessStatusCode();
            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }

        [Fact]
        public async Task Juros_DeveRetornar_ValorFinal()
        {
            var response = await _client.GetAsync("api/v1/Juros/CalculaJuros?valorInicial=100&meses=5");
            response.StatusCode.Should().Be(HttpStatusCode.OK);

            var juros = JsonConvert.DeserializeObject<string>
                (await response.Content.ReadAsStringAsync());
            juros.Should().Be("105.10");
        }
    }
}
