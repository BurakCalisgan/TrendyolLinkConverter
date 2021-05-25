using Infrastructure.Abstract.WebUrlToDeepLinkConverterServices;
using Infrastructure.Constants;

namespace Infrastructure.Concrete.WebUrlToDeepLinkConverterManagers
{
    public class WebUrlSearchConverterManager : IWebUrlToDeepLinkConverterService
    {
        public bool CanConvert(string url)
        {
            if (url.Contains("sr?q="))
            {
                return true;
            }
            return false;
        }
        public string Convert(string url)
        {
            string param = url.Split(new string[] { "sr?q=" }, System.StringSplitOptions.RemoveEmptyEntries)[1];
            return $"{CommonConstants.SearchBaseDeepLink}{param}";
        }
    }
}
