using Infrastructure.Abstract.WebUrlToDeepLinkConverterServices;
using System.Collections.Generic;
using System.Linq;
namespace Infrastructure.Concrete.WebUrlToDeepLinkConverterManagers
{
    public class WebUrlToDeepLinkManager : IWebUrlToDeepLinkService
    {
        private readonly IEnumerable<IWebUrlToDeepLinkConverterService> _webUrlConverter;

        public WebUrlToDeepLinkManager(IEnumerable<IWebUrlToDeepLinkConverterService> webUrlConverter)
        {
            _webUrlConverter = webUrlConverter;
        }
        public string WebUrlToDeepLink(string url)
        {
            var converter = _webUrlConverter.FirstOrDefault(c => c.CanConvert(url));
            return converter.Convert(url);
        }

    }
}
