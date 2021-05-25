using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Persistence;
using System.Threading.Tasks;
using WebApi;

namespace Application.UnitTests.Common
{
    public class TestBase
    {
        private static IConfigurationRoot _configuration;
        private static IServiceScopeFactory _scopeFactory;

        public TestBase()
        {
            var builder = new ConfigurationBuilder();
            _configuration = builder.Build();
            var startup = new Startup(_configuration);

            var services = new ServiceCollection();
            services.AddApplication();
            services.AddPersistence();
            startup.ConfigureServices(services);
            _scopeFactory = services.BuildServiceProvider().GetService<IServiceScopeFactory>();
        }

        public static async Task<TResponse> SendAsync<TResponse>(IRequest<TResponse> request)
        {
            using var scope = _scopeFactory.CreateScope();

            var mediator = scope.ServiceProvider.GetService<ISender>();

            return await mediator.Send(request);
        }
    }
}
