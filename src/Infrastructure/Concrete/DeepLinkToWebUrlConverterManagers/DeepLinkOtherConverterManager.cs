using Infrastructure.Abstract.DeepLinkToWebUrlConverterServices;
using Infrastructure.Constants;

namespace Infrastructure.Concrete.DeepLinkToWebUrlConverterManagers
{
    public class DeepLinkOtherConverterManager : IDeepLinkToWebUrlConverterService
    {
        public bool CanConvert(string deeplink)
        {
            return true;
        }
        public string Convert(string deeplink)
        {
            return CommonConstants.OtherWebUrl;
        }
    }
}
