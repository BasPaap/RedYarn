using Bas.RedYarn.WebApp.Services;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;
using System.Net.Http;


namespace Bas.RedYarn.WebApp.Tests.Helpers
{
    static class TestServerHelper
    {
        public static HttpClient GetTestClient(IDataService dataService)
        {
            var webHostBuilder = new WebHostBuilder()
                .UseStartup<Startup>()
                .UseEnvironment("development")
                .ConfigureAppConfiguration((builderContext, config) =>
                {
                    var hostingEnvironment = builderContext.HostingEnvironment;
                    config.AddInMemoryCollection(new Dictionary<string, string> { { "ConnectionStrings:RedYarnDatabase", "Data Source=redyarn.db" } });
                })
                .ConfigureServices(s => s.AddTransient<IDataService, IDataService>(serviceProvider => dataService));

            var testServer = new TestServer(webHostBuilder);

            return testServer.CreateClient();
        }
    }
}
