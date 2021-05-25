using Application.RequestResponseHistories.Commands;
using Application.RequestResponseHistories.Models;
using Application.RequestResponseHistories.Queries;
using Domain.Enums;
using Infrastructure.Abstract.DeepLinkToWebUrlConverterServices;
using Infrastructure.Abstract.WebUrlToDeepLinkConverterServices;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApi.Controllers
{
    [Route("api/[controller]s")]
    [ApiController]
    public class ConverterController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger<ConverterController> _logger;
        private readonly IWebUrlToDeepLinkService _webUrlToDeepLinkService;
        private readonly IDeepLinkToWebUrlService _deepLinkToWebUrlService;

        public ConverterController(ILogger<ConverterController> logger, IMediator mediator, IWebUrlToDeepLinkService webUrlToDeepLinkService, IDeepLinkToWebUrlService deepLinkToWebUrlService)
        {
            _logger = logger;
            _mediator = mediator;
            _webUrlToDeepLinkService = webUrlToDeepLinkService;
            _deepLinkToWebUrlService = deepLinkToWebUrlService;
        }

        [HttpGet("GetRequestResponseHistory")]
        public async Task<IActionResult> GetRequestResponseHistory([FromQuery] GetRequestResponseHistoriesQuery query)
        {
            _logger.LogInformation("GetRequestResponseHistory started.");
            _logger.LogInformation("GetRequestResponseHistory ended.");
            return Ok(await _mediator.Send(query));
        }

        [HttpGet("WebUrlToDeeplinkService")]
        public async Task<string> WebUrlToDeeplinkService(string url)
        {
            _logger.LogInformation("WebUrlToDeeplinkService started.");

            if (url == null)
            {
                await Task.CompletedTask;
                throw new ArgumentNullException(nameof(url));
            }

            string deeplink = _webUrlToDeepLinkService.WebUrlToDeepLink(url);
            await _mediator.Send(new CreateRequestResponseHistoryCommand
            {
                RequestResponseHistory = new RequestResponseHistoryDto
                {
                    Request = url,
                    Response = deeplink,
                    ConverterType = ConverterTypeEnum.WebUrlToDeepLink
                }
            });

            _logger.LogInformation("WebUrlToDeeplinkService ended.");

            return deeplink;
        }

        [HttpGet("DeeplinkToWebUrlService")]
        public async Task<string> DeeplinkToWebUrlService(string deeplink)
        {
            _logger.LogInformation("DeeplinkToWebUrlService started.");

            if (string.IsNullOrEmpty(deeplink))
            {
                await Task.CompletedTask;
                throw new ArgumentNullException(nameof(deeplink));
            }

            string webUrl = _deepLinkToWebUrlService.DeepLinkToWebUrl(deeplink);
            await _mediator.Send(new CreateRequestResponseHistoryCommand
            {
                RequestResponseHistory = new RequestResponseHistoryDto
                {
                    Request = deeplink,
                    Response = webUrl,
                    ConverterType = ConverterTypeEnum.WebUrlToDeepLink
                }
            });

            _logger.LogInformation("DeeplinkToWebUrlService ended.");

            return webUrl;
        }

    }
}
