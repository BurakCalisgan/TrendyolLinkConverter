using Infrastructure.Abstract.DeepLinkToWebUrlConverterServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Concrete.DeepLinkToWebUrlConverterManagers
{
    public class DeepLinkToWebUrlManager : IDeepLinkToWebUrlService
    {
        private readonly IEnumerable<IDeepLinkToWebUrlConverterService> _deepLinkConverter;

        public DeepLinkToWebUrlManager(IEnumerable<IDeepLinkToWebUrlConverterService> deepLinkConverter)
        {
            _deepLinkConverter = deepLinkConverter;
        }
        public string DeepLinkToWebUrl(string deeplink)
        {
            var converter = _deepLinkConverter.FirstOrDefault(c => c.CanConvert(deeplink));
            return converter.Convert(deeplink);
        }
    }
}