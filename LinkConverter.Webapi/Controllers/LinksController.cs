using LinkConverter.Domain.Models.Request;
using LinkConverter.Domain.Models.Response;
using LinkConverter.Domain.Service;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using System.Collections.Generic;
using System.Linq;

namespace LinkConverter.Webapi.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class LinksController : ControllerBase
    {
        #region WebUrlToDeepLink
        /// <summary>
        /// Trendyol web url adresini deep linke çevirir. Gönderilen web urllerin trendyol'a ait olduğuna dikkat edilmesi gerekir. Ürün detayı veya arama linkleri değilse yaptığı çeviri ana sayfa deep link olacaktır.
        /// </summary>
        /// <param name="service">Dependency injection tarafından kullanılır request için ihtiyaç yoktur</param>
        /// <param name="body">Dönüştürülecek url'in http body içerisinde Url ile gönderilen objedir.</param>
        /// <returns>Deep link döner. Örn: ty://?Page=Search&Query=kalem</returns>
        [HttpPost]
        [ActionName("WebUrlToDeepLink")]
        public ActionResult<string> WebUrlToDeepLink([FromServices] ILinkConverterService service, [FromBody] WebUrlToDeepLinkRequest body)
        {
            return service.WebUrlToDeepLink(body.Url);
        }

        /// <summary>
        /// Trendyol web url adresini deep linke çevirir. Gönderilen web urllerin trendyol'a ait olduğuna dikkat edilmesi gerekir. Ürün detayı veya arama linkleri değilse yaptığı çeviri ana sayfa deep link olacaktır. Diğer uçtan farklı olarak linki route'dan alır. İşlevsellik olarak farkları yoktur.
        /// </summary>
        /// <param name="service">Dependency injection tarafından kullanılır request için ihtiyaç yoktur</param>
        /// <param name="weburl">Route ile çevrilecek olan web url</param>
        /// <returns>Deep link döner. Örn: ty://?Page=Search&Query=kalem</returns>
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
        /// Deep linki Trendyol web url çevirir. Eğer ürün detayı veya arama değilse ana sayfaya olarak çeviri yapacaktır.
        /// </summary>
        /// <param name="service">Dependency injection tarafından kullanılır request için ihtiyaç yoktur</param>
        /// <param name="body">Dönüştürülecek deep linkin http body içerisinde Url ile gönderilen objedir</param>
        /// <returns>Trendyol web url döner. Örn: https://www.trendyol.com/brand/name-p-1925865</returns>
        [HttpPost]
        [ActionName("DeepLinkToWebUrl")]
        public ActionResult<string> DeepLinkToWebUrl([FromServices] ILinkConverterService service, [FromBody] WebUrlToDeepLinkRequest body)
        {
            return service.DeepLinkToWebUrl(body.Url);
        }
        /// <summary>
        /// Deep linki Trendyol web url çevirir. Eğer ürün detayı veya arama değilse ana sayfaya olarak çeviri yapacaktır. Diğer uçtan farklı olarak linki route'dan alır. İşlevsellik olarak farkları yoktur.
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
        /// Arayüzdende eklenen verilerin görüntülenmesi için eklenmiştir. Fazlalık olarak eklediğim için dönen verilere max limit eklenmemiştir. 
        /// </summary>
        /// <param name="service"></param>
        /// <returns></returns>
        [HttpGet]
        [ActionName("GetAllHistory")]
        public ActionResult<IEnumerable<LinkConvertHistoryResponse>> GetAllHistory([FromServices] ILinkConverterService service)
        {
            return Ok(service.GetHistories());
        }
        #endregion
    }
}
