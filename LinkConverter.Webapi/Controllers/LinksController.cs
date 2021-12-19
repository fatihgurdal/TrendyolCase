using LinkConverter.Domain.Enums;
using LinkConverter.Domain.Models.Request;
using LinkConverter.Domain.Models.Response;
using LinkConverter.Domain.Models.TestEntity;
using LinkConverter.Domain.Service;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using System;
using System.Collections.Generic;
using System.Linq;

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

        #region WebUrlToDeepLink
        /// <summary>
        /// Trendyol web url adresini deep linke çevirir
        /// </summary>
        /// <param name="service">Dependency injection tarafından kullanılır request için ihtiyaç yoktur</param>
        /// <param name="body">Dönüştürülecek url'in http body içerisinde Url ile gönderilen objedir.</param>
        /// <returns>Deep link döner</returns>
        [HttpPost]
        [ActionName("WebUrlToDeepLink")]
        public ActionResult<string> WebUrlToDeepLink([FromServices] ILinkConverterService service, [FromBody] WebUrlToDeepLinkRequest body)
        {
            return service.WebUrlToDeepLink(body.Url);
        }

        /// <summary>
        /// Trendyol web url adresini deep linke çevirir
        /// </summary>
        /// <param name="service">Dependency injection tarafından kullanılır request için ihtiyaç yoktur</param>
        /// <param name="weburl">Route ile çevrilecek olan web url</param>
        /// <returns>Deep link döner</returns>
        [HttpGet]
        [ActionName("WebUrlToDeepLink")]
        [Route("{weburl:length(25,2048)}")] //İş mantığında url max uzunluk limiti bilinmediği için tahmini bir verildi. Normalde host eden uygulma üzerinde illaki max bir limit verilir(MaxRequestLineSize vb.).
        public ActionResult<string> WebUrlToDeepLink([FromServices] ILinkConverterService service, [FromRoute] string weburl)
        {
            return service.WebUrlToDeepLink(weburl);
        }
        #endregion

        #region DeepLinkToWebUrl
        /// <summary>
        /// Deep linki Trendyol web url çevirir.
        /// </summary>
        /// <param name="service">Dependency injection tarafından kullanılır request için ihtiyaç yoktur</param>
        /// <param name="body">Dönüştürülecek deep linkin http body içerisinde Url ile gönderilen objedir</param>
        /// <returns>Trendyol web url döner</returns>
        [HttpPost]
        [ActionName("DeepLinkToWebUrl")]
        public ActionResult<string> DeepLinkToWebUrl([FromServices] ILinkConverterService service, [FromBody] WebUrlToDeepLinkRequest body)
        {
            return service.DeepLinkToWebUrl(body.Url);
        }
        /// <summary>
        /// Deep linki Trendyol web url çevirir
        /// </summary>
        /// <param name="service">Dependency injection tarafından kullanılır request için ihtiyaç yoktur</param>
        /// <param name="deeplink">Route ile çevrilecek olan deep link</param>
        /// <returns>Trendyol web url döner</returns>
        [HttpGet]
        [ActionName("DeepLinkToWebUrl")]
        [Route("{deeplink:length(25,2048)}")] //İş mantığında url max uzunluk limiti bilinmediği için tahmini bir verildi. Normalde host eden uygulma üzerinde illaki max bir limit verilir(MaxRequestLineSize vb.).
        public ActionResult<string> DeepLinkToWebUrl([FromServices] ILinkConverterService service, [FromRoute] string deeplink)
        {
            return service.DeepLinkToWebUrl(deeplink);
        }
        #endregion

        #region History
        /// <summary>
        /// Arayüzdende eklenen verilerin görüntülenmesi için eklenmiştir.
        /// </summary>
        /// <param name="service"></param>
        /// <returns></returns>
        [HttpGet]
        [ActionName("GetAllHistory")]
        public ActionResult<List<LinkConvertHistoryResponse>> GetAllHistory([FromServices] ILinkConverterService service)
        {
            return service.GetHistories().ToList();
        }
        #endregion
    }
}
