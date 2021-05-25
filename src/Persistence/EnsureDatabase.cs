using Domain.Entities;
using Domain.Enums;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence
{
    public static class EnsureDatabase
    {
        public static void Ensure()
        {
            var context = new TrendyolDbContext();
            context.Database.Migrate();

            if (!context.RequestResponseHistory.Any())
            {
                context.RequestResponseHistory.AddRange(
                    new RequestResponseHistory()
                    {
                        Guid = System.Guid.NewGuid(),
                        Request = "https://www.trendyol.com/casio/saat-p-1925865?boutiqueId=439892&merchantId=105064",
                        Response = "ty://?Page=Product&ContentId=1925865&CampaignId=439892&MerchantId=105064",
                        ConverterType = ConverterTypeEnum.WebUrlToDeepLink,
                        CreatedBy = "Trendyol",
                        CreatedDate = DateTime.Now,
                        UpdatedBy = "Trendyol",
                        UpdatedDate = DateTime.Now
                    },
                    new RequestResponseHistory()
                    {
                        Guid = System.Guid.NewGuid(),
                        Request = "ty://?Page=Product&ContentId=1925865&CampaignId=439892&MerchantId=105064",
                        Response = "https://www.trendyol.com/brand/name-p-1925865?boutiqueId=439892&merchantId=105064",
                        ConverterType = ConverterTypeEnum.DeepLinkToWebUrlLink,
                        CreatedBy = "Trendyol",
                        CreatedDate = DateTime.Now,
                        UpdatedBy = "Trendyol",
                        UpdatedDate = DateTime.Now
                    }
                );
                context.SaveChanges();
            }
        }
    }
}
