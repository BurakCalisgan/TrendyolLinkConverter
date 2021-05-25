using Application.RequestResponseHistories.Commands;
using Application.UnitTests.Common;
using Domain.Enums;
using MediatR;
using Moq;
using System;
using Xunit;

namespace Application.UnitTests.RequestResponseHistories
{
    public class RequestResponseHistoryTests : TestBase
    {
        //For Mock
        private readonly IMediator _mediator;
        public RequestResponseHistoryTests()
        {
            //Mock
            _mediator = new Mock<IMediator>().Object;
        }

        //Mock Test Function
        [Fact]
        public async void RequestResponseHistoryTestForMock()
        {
            CreateRequestResponseHistoryCommand command = new()
            {
                RequestResponseHistory = new()
                {
                    Guid = System.Guid.NewGuid(),
                    Request = "https://www.trendyol.com/casio/saat-p-1925865?boutiqueId=439892&merchantId=105064",
                    Response = "ty://?Page=Product&ContentId=1925865&CampaignId=439892&MerchantId=105064",
                    ConverterType = ConverterTypeEnum.WebUrlToDeepLink
                }
            };
            var response = await _mediator.Send(command);
            Assert.Equal(Unit.Value,response);
        }

        //Test Function with Context
        [Fact]
        public async void RequestResponseHistoryTest()
        {
            CreateRequestResponseHistoryCommand command = new()
            {
                RequestResponseHistory = new()
                {
                    Guid = System.Guid.NewGuid(),
                    Request = "https://www.trendyol.com/casio/saat-p-1925865?boutiqueId=439892&merchantId=105064",
                    Response = "ty://?Page=Product&ContentId=1925865&CampaignId=439892&MerchantId=105064",
                    ConverterType = ConverterTypeEnum.WebUrlToDeepLink
                }
            };
            var response = await SendAsync(command);
            Assert.Equal(Unit.Value, response);
        }
    }
}
