using Infrastructure.Abstract.WebUrlToDeepLinkConverterServices;
using Infrastructure.Constants;
using System;
using System.Text;

namespace Infrastructure.Concrete.WebUrlToDeepLinkConverterManagers
{
    public class WebUrlProductDetailConverterManager : IWebUrlToDeepLinkConverterService
    {
        private const StringSplitOptions EmptyEntry = StringSplitOptions.RemoveEmptyEntries;

        public bool CanConvert(string url)
        {
            if (url.Contains("-p-"))
            {
                return true;
            }
            return false;
        }
        public string Convert(string url)
        {
            StringBuilder deeplink = new();

            string contentId = url.Split(new string[] { "-p-" }, EmptyEntry)[1];
            if (contentId.Contains("?"))
            {
                contentId = contentId.Split(new char[] { '?' })[0];
            }
            deeplink.Append(CommonConstants.ProductDetailPageBaseDeepLink).Append(contentId);

            if (url.Contains("boutiqueId="))
            {
                deeplink.Append("&CampaignId=");

                string boutiqueId = url.Split(new string[] { "boutiqueId=" }, EmptyEntry)[1];
                if (boutiqueId.Contains("&"))
                {
                    boutiqueId = boutiqueId.Split(new char[] { '&' })[0];
                }
                deeplink.Append(boutiqueId);
            }

            if (url.Contains("merchantId="))
            {
                string merchantId = url.Split(new string[] { "merchantId=" }, EmptyEntry)[1];
                deeplink.Append("&MerchantId=").Append(merchantId);
            }

            return deeplink.ToString();
        }
    }
}
