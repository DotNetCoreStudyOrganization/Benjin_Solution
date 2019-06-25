namespace WebApp.Controllers.Accounts
{
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Threading.Tasks;
    using System.Web.Http;
    using Application.Accounts;
    using Application.Accounts.Models;
    using Domain.UserAccounts.AppRoles;
    using Domain.UserAccounts.AppUsers;
    using Microsoft.Owin;

    [AllowAnonymous]
    public class AccountController: ApiController
    {
        private readonly AccountAppService appService;

        public AccountController(AccountAppService appService)
        {
            this.appService = appService;
        }

        private IOwinContext OwinContext => Request.GetOwinContext();

        [HttpPost]
        public async Task<IHttpActionResult> SignInAsync(
            UserSignInModel model)
        {
            var user = await appService.SignInAsync(OwinContext, model);

            return Ok(user.Id);
        }

        [HttpPost]
        public IHttpActionResult SignOut()
        {
            appService.SignOut(OwinContext);

            return Ok();
        }

        [HttpPost]
        public IHttpActionResult CreateOrUpdate(AppUser user, IEnumerable<AppRole> roles)
        {
            appService.CreateOrUpdate(user, roles);

            return Ok();
        }

        [HttpGet]
        public IHttpActionResult GetPagedList(int pageNumber, int pageSize, string search = default)
        {
            var pagedList = appService.GetPagedList(pageNumber, pageSize, search);

            Infrastructure.LogTools.Log4netHelper.Info(pagedList.Total);

            return Ok(pagedList);
        }
    }
}