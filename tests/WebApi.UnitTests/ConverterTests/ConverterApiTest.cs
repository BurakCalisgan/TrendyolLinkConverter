using Infrastructure.Abstract.DeepLinkToWebUrlConverterServices;
using Infrastructure.Abstract.WebUrlToDeepLinkConverterServices;
using Infrastructure.Concrete.DeepLinkToWebUrlConverterManagers;
using Infrastructure.Concrete.WebUrlToDeepLinkConverterManagers;
using MediatR;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebApi.Controllers;
using Xunit;

namespace WebApi.UnitTests.ConverterTests
{
    public class ConverterApiTest
    {
        private readonly ILogger<ConverterController> _logger;
        private readonly IMediator _mediator; 
        private readonly IEnumerable<IWebUrlToDeepLinkConverterService> _webUrlToDeepLinkConverterServiceList;
        private readonly IEnumerable<IDeepLinkToWebUrlConverterService> _deepLinkToWebUrlConverterServiceList;
        private readonly IWebUrlToDeepLinkService _webUrlToDeepLinkService;
        private readonly IDeepLinkToWebUrlService _deepLinkToWebUrlService;
        public ConverterApiTest()
        {
            _logger = new Mock<ILogger<ConverterController>>().Object;
            _mediator = new Mock<IMediator>().Object;
            _webUrlToDeepLinkConverterServiceList = new List<IWebUrlToDeepLinkConverterService>()
            {
                new WebUrlProductDetailConverterManager(),
                new WebUrlSearchConverterManager(),
                new WebUrlOtherConverterManagers(),
            };
            _webUrlToDeepLinkService = new WebUrlToDeepLinkManager(_webUrlToDeepLinkConverterServiceList);

            _deepLinkToWebUrlConverterServiceList = new List<IDeepLinkToWebUrlConverterService>()
            {
                new DeepLinkProductDetailConverterManager(),
                new DeepLinkSearchConverterManager(),
                new DeepLinkOtherConverterManager(),
            };
            _deepLinkToWebUrlService = new DeepLinkToWebUrlManager(_deepLinkToWebUrlConverterServiceList);


        }

        [Fact]
        public async Task WebUrlToDeepLinkTest()
        {
            string url = "https://www.trendyol.com/casio/saat-p-1925865?boutiqueId=439892&merchantId=105064";
            string expected = "ty://?Page=Product&ContentId=1925865&CampaignId=439892&MerchantId=105064";
            ConverterController converterController = new(_logger, _mediator, _webUrlToDeepLinkService, _deepLinkToWebUrlService);
            var result = await converterController.WebUrlToDeeplinkService(url);
            Assert.Equal(expected, result);
        }

        [Fact]
        public async void DeeplinkToWebUrlTest()
        {
            string deepLink = "ty://?Page=Product&ContentId=1925865&CampaignId=439892&MerchantId=105064";
            string expected = "https://www.trendyol.com/brand/name-p-1925865?boutiqueId=439892&merchantId=105064";
            ConverterController converterController = new(_logger, _mediator, _webUrlToDeepLinkService, _deepLinkToWebUrlService);
            var result = await converterController.DeeplinkToWebUrlService(deepLink);
            Assert.Equal(expected, result);
        }
    }
}

