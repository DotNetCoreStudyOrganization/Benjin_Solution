namespace WebApp.Controllers
{
    using System;
    using System.Web.Http;
    using Application.Tests;
    using Application.Tests.Models;

    [AllowAnonymous]
    public class TestController : ApiController
    {
        private readonly TestAppService appService;

        public TestController(TestAppService appService)
        {
            this.appService = appService;
        }

        [HttpGet]
        public IHttpActionResult Get(Guid id)
        {
            return Ok(appService.Get(id));
        }

        [HttpGet]
        public IHttpActionResult GetAll()
        {
            return Ok(appService.GetAll());
        }

        [HttpPost]
        public IHttpActionResult CreateOrUpdate(TestBindModel model)
        {
            return Ok(appService.CreateOrUpdate(model));
        }
    }
}
