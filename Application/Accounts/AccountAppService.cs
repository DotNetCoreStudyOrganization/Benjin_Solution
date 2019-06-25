namespace Application.Accounts
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Application.Accounts.Models;
    using Application.BaseModels;
    using Domain.UserAccounts;
    using Domain.UserAccounts.AppRoles;
    using Domain.UserAccounts.AppUsers;
    using Infrastructure.Models;
    using Microsoft.Owin;

    public class AccountAppService : IAppService
    {
        private readonly AccountService service;

        public AccountAppService(AccountService service)
        {
            this.service = service;
        }

        public Task<AppUser> SignInAsync(
            IOwinContext owinContext,
            UserSignInModel model)
        {
            model.Valid();

            var timeSpan = TimeSpan.FromHours(8);

            return service.SignInAsync(owinContext, model.UserName, model.UserPwd, timeSpan);
        }

        public void SignOut(IOwinContext owinContext)
        {
            service.SignOut(owinContext);
        }

        public void CreateOrUpdate(AppUser user, IEnumerable<AppRole> roles)
        {
            service.CreateOrUpdate(user, roles);
        }

        public PagedListModel<UserPagedModel> GetPagedList(int pageNumber, int pageSize, string search = default)
        {
            var pagedList = service.GetPagedList(pageNumber, pageSize, search);

            return UserPagedModel.CreatePagedList(pagedList);
        }
    }
}
