using LinkConverter.Domain.Enums;
using LinkConverter.Domain.Models.Request;
using LinkConverter.Domain.Models.TestEntity;
using LinkConverter.Domain.Service;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using System;

namespace LinkConverter.Webapi.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class LinksController : ControllerBase
    {
        #region Test

        [ActionName("AddTest")]
        [HttpPost]
        public ActionResult<int> AddTest([FromServices] ITestService service,
            [FromBody] AddTestRequest body)
        {
            return service.Add(body.Name, body.Age);
        }
        [ActionName("GetTests")]
        [HttpGet]
        public ActionResult<string> GetTests([FromServices] ITestService service)
        {
            return service.GetAll();
        }

        [ActionName("CustomThrow")]
        [HttpGet]
        public ActionResult<string> CustomThrow([FromQuery] ErrorType type)
        {
            switch (type)
            {
                case ErrorType.Critical:
                    throw new System.Exception("Custom System Exception");
                case ErrorType.Validation:
                    throw new Domain.Exception.BadRequestException("Custom BadRequestException");
                case ErrorType.Warning:
                    throw new Domain.Exception.NotFoundExcepiton("Custom BadRequestException");
                case ErrorType.Info:
                    throw new Domain.Exception.BadRequestException("Custom BadRequestException");
                default:
                    throw new Domain.Exception.BadRequestException("Custom BadRequestException");
            }
        }
        #endregion

        [HttpPost]
        [ActionName("WebUrlToDeepLink")]
        public ActionResult<string> WebUrlToDeepLink([FromServices] ILinkConverterService service, [FromBody] WebUrlToDeepLinkRequest body)
        {
            return service.WebUrlToDeepLink(body.Url);
        }

        [HttpGet]
        [ActionName("WebUrlToDeepLink")]
        [Route("{weburl:length(25,2048)}")] //İş mantığında url max uzunluk limiti bilinmediği için tahmini bir verildi. Normalde host eden uygulma üzerinde illaki max bir limit verilir(MaxRequestLineSize vb.).
        public ActionResult<string> WebUrlToDeepLink([FromServices] ILinkConverterService service, [FromRoute] string weburl)
        {
            return service.WebUrlToDeepLink(weburl);
        }

        [HttpPost]
        [ActionName("DeepLinkToWebUrl")]
        public ActionResult<string> DeepLinkToWebUrl([FromServices] ILinkConverterService service, [FromBody] WebUrlToDeepLinkRequest body)
        {
            return service.DeepLinkToWebUrl(body.Url);
        }

        [HttpGet]
        [ActionName("DeepLinkToWebUrl")]
        [Route("{deeplink:length(25,2048)}")] //İş mantığında url max uzunluk limiti bilinmediği için tahmini bir verildi. Normalde host eden uygulma üzerinde illaki max bir limit verilir(MaxRequestLineSize vb.).
        public ActionResult<string> DeepLinkToWebUrl([FromServices] ILinkConverterService service, [FromRoute] string deeplink)
        {
            return service.DeepLinkToWebUrl(deeplink);
        }
    }
}
