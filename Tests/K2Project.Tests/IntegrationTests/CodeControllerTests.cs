using FluentAssertions;
using Microsoft.AspNetCore.Mvc.Testing;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace K2Project.Tests.IntegrationTests
{
    public class CodeControllerTests : IClassFixture<WebApplicationFactory<Juros.Api.Startup>>
    {
        public HttpClient _client { get; }

        public CodeControllerTests(WebApplicationFactory<Juros.Api.Startup> fixture)
        {
            _client = fixture.CreateClient();
        }

        [Fact]
        public async Task Code_ShowMeTheCode_DeveRetornarOkResponse()
        {
            var response = await _client.GetAsync("ShowMeTheCode");
            response.EnsureSuccessStatusCode();
            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }

        [Fact]
        public async Task Code_ShowMeTheCode_DeveRetornarCodeUrl()
        {
            var response = await _client.GetAsync("ShowMeTheCode");
            response.StatusCode.Should().Be(HttpStatusCode.OK);            

            var code = await response.Content.ReadAsStringAsync();
            code.Should().Be("https://github.com/onayrown/K2Project-APIs");
        }
    }
}
