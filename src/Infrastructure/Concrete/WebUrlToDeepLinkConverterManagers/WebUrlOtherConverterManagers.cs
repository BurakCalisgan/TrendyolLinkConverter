using Infrastructure.Abstract.WebUrlToDeepLinkConverterServices;
using Infrastructure.Constants;

namespace Infrastructure.Concrete.WebUrlToDeepLinkConverterManagers
{
    public class WebUrlOtherConverterManagers : IWebUrlToDeepLinkConverterService
    {
        public bool CanConvert(string url)
        {
            return true;
        }
        public string Convert(string url)
        {
            return CommonConstants.OtherDeepLink;
        }
    }
}
