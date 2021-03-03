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
    public class TaxasControllerTests : IClassFixture<WebApplicationFactory<Taxa.Api.Startup>>
    {
        public HttpClient _client { get; }

        public TaxasControllerTests(WebApplicationFactory<Taxa.Api.Startup> fixture)
        {
            _client = fixture.CreateClient();
        }

        [Fact]
        public async Task Taxas_TaxasJuros_DeveRetornarOkResponse()
        {
            var response = await _client.GetAsync("taxajuros");
            response.EnsureSuccessStatusCode();
            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }

        [Fact]
        public async Task Taxas_TaxasJuros_DeveRetornarTaxa()
        {
            var response = await _client.GetAsync("taxajuros");
            response.StatusCode.Should().Be(HttpStatusCode.OK);

            var taxa = JsonConvert.DeserializeObject<decimal>
                (await response.Content.ReadAsStringAsync());
            taxa.Should().Be(0.01m);
        }
    }
}
