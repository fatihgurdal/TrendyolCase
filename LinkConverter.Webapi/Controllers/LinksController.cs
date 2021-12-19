using LinkConverter.Domain.Enums;
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
    }
}
