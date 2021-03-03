using Docker.DotNet;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc.Testing;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace K2Project.Tests.IntegrationTests
{
    public class JurosControllerTests : IClassFixture<WebApplicationFactory<Juros.Api.Startup>> 
    {
        public HttpClient _client { get; }
        private readonly DockerClient _dockerClient;

        public JurosControllerTests(WebApplicationFactory<Juros.Api.Startup> fixture)
        {
            _client = fixture.CreateClient();
            _dockerClient = new DockerClientConfiguration(new Uri(DockerApiUri())).CreateClient();
        }

        [Fact]
        public async Task Juros_CalculaJuros_DeveRetornarBadRequest()
        {            
            var response = await _client.GetAsync("CalculaJuros?valorInicial=100&meses=5");            
            response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
        }

        private string DockerApiUri()
        {
            var isWindows = RuntimeInformation.IsOSPlatform(OSPlatform.Windows);

            if (isWindows)
            {
                return "npipe://./pipe/docker_engine";
            }

            var isLinux = RuntimeInformation.IsOSPlatform(OSPlatform.Linux);

            if (isLinux)
            {
                return "unix:/var/run/docker.sock";
            }

            throw new Exception("Was unable to determine what OS this is running on, does not appear to be Windows or Linux!?");
        }
    }
}
