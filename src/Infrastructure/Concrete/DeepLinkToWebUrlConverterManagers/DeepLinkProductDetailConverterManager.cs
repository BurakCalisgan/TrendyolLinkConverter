using Infrastructure.Abstract.DeepLinkToWebUrlConverterServices;
using Infrastructure.Constants;
using System;
using System.Text;
using System.Text.RegularExpressions;

namespace Infrastructure.Concrete.DeepLinkToWebUrlConverterManagers
{
    public class DeepLinkProductDetailConverterManager : IDeepLinkToWebUrlConverterService
    {
        public bool CanConvert(string deeplink)
        {
            if (deeplink.Contains("ContentId="))
            {
                return true;
            }
            return false;
        }
        public string Convert(string deeplink)
        {
            StringBuilder url = new();

            string pattern = @"ContentId=\d+";
            Regex rg = new(pattern);

            MatchCollection matchedAuthors = rg.Matches(deeplink);
            if (matchedAuthors != null && matchedAuthors.Count > 0)
            {
                string contentId = matchedAuthors[0].Value.Split(new char[] { '=' })[1];
                url.Append(CommonConstants.ProductDetailPageBaseWebUrl).Append(contentId);
            }

            string boutiqueId = string.Empty;

            pattern = @"CampaignId=\d+";
            rg = new(pattern);
            matchedAuthors = rg.Matches(deeplink);
            if (matchedAuthors != null && matchedAuthors.Count > 0)
            {
                boutiqueId = matchedAuthors[0].Value.Split(new char[] { '=' })[1];
                url.Append("?boutiqueId=").Append(boutiqueId);
            }

            pattern = @"MerchantId=\d+";
            rg = new(pattern);
            matchedAuthors = rg.Matches(deeplink);
            if (matchedAuthors != null && matchedAuthors.Count > 0)
            {
                url.Append(string.IsNullOrEmpty(boutiqueId) ? "?merchantId=" : "&merchantId=");
                string merchantId = matchedAuthors[0].Value.Split(new char[] { '=' })[1];
                url.Append(merchantId);
            }

            return url.ToString();
        }
    }
}
