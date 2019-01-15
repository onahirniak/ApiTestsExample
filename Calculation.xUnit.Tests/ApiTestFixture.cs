using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Calculation.Api;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Xunit;

namespace Calculation.xUnit.Tests
{
    public class ApiTestFixture : IAsyncLifetime
    {
        public HttpClient Client { get; set; }

        public ApiTestFixture()
        {
            var testServer = new TestServer(
                new WebHostBuilder()
                    .UseStartup<Startup>());

            Client = testServer.CreateClient();
        }

        public async Task InitializeAsync()
        {
            
        }

        public async Task DisposeAsync()
        {
        }
    }

    [CollectionDefinition("Api")]
    public class ApiCollection : ICollectionFixture<ApiTestFixture>
    {
    }
}
