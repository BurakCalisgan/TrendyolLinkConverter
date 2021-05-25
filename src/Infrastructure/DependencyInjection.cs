using Infrastructure.Concrete.WebUrlToDeepLinkConverterManagers;
using Infrastructure.Abstract.WebUrlToDeepLinkConverterServices;
using Microsoft.Extensions.DependencyInjection;
using Infrastructure.Abstract.DeepLinkToWebUrlConverterServices;
using Infrastructure.Concrete.DeepLinkToWebUrlConverterManagers;

namespace Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            //For Web Url To DeepLink
            services.AddSingleton<IWebUrlToDeepLinkService, WebUrlToDeepLinkManager>();
            services.AddTransient<IWebUrlToDeepLinkConverterService, WebUrlProductDetailConverterManager>();
            services.AddTransient<IWebUrlToDeepLinkConverterService, WebUrlSearchConverterManager>();
            services.AddTransient<IWebUrlToDeepLinkConverterService, WebUrlOtherConverterManagers>();

            //For DeepLink To Web Url
            services.AddSingleton<IDeepLinkToWebUrlService, DeepLinkToWebUrlManager>();
            services.AddTransient<IDeepLinkToWebUrlConverterService, DeepLinkProductDetailConverterManager>();
            services.AddTransient<IDeepLinkToWebUrlConverterService, DeepLinkSearchConverterManager>();
            services.AddTransient<IDeepLinkToWebUrlConverterService, DeepLinkOtherConverterManager>();

            return services;
        }
    }
}
