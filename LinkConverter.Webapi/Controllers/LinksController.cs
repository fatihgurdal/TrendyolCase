using LinkConverter.Domain.Models.TestEntity;
using LinkConverter.Domain.Service;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using System;

namespace LinkConverter.Webapi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
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
    }
}
