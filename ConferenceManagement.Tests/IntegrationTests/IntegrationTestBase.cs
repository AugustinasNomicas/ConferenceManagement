using ConferenceManagement.Data;
using ConferenceManagement.Data.Repositories;
using ConferenceManagement.Web;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace ConferenceManagement.Tests.IntegrationTests
{
    public class IntegrationTestBase
    {
        protected ConferenceDbContext ConferenceDbContext;
        protected IServiceProvider ServiceProvider;

        public IntegrationTestBase()
        {
            var services = new ServiceCollection();

            var startup = new Startup(null);

            startup.ConfigureServices(services);

            ServiceProvider = services.BuildServiceProvider();
        }
    }
}
