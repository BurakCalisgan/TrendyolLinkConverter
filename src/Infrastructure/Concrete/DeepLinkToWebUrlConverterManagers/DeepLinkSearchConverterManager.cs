using Infrastructure.Abstract.DeepLinkToWebUrlConverterServices;
using Infrastructure.Constants;
using System;
using System.Text;
using System.Text.RegularExpressions;

namespace Infrastructure.Concrete.DeepLinkToWebUrlConverterManagers
{
    public class DeepLinkSearchConverterManager : IDeepLinkToWebUrlConverterService
    {
        public bool CanConvert(string deeplink)
        {
            if (deeplink.Contains("=Search&Query="))
            {
                return true;
            }
            return false;
        }
        public string Convert(string deeplink)
        {
            StringBuilder url = new();
            string pattern = @"Search&Query=\S+";
            Regex rg = new(pattern);

            MatchCollection matchedAuthors = rg.Matches(deeplink);
            if (matchedAuthors != null && matchedAuthors.Count > 0)
            {
                string param = matchedAuthors[0].Value.Split(new char[] { '=' })[1];
                url.Append(CommonConstants.SearchBaseWebUrl).Append(param);
            }

            return url.ToString();
        }
    }
}
