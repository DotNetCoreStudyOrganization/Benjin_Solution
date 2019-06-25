namespace Domain.UserAccounts
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Domain.BaseModels;
    using Domain.UserAccounts.AppRoles;
    using Domain.UserAccounts.AppUsers;
    using Microsoft.AspNet.Identity;
    using Microsoft.Owin;
    using X.PagedList;

    public class AccountService : IService
    {
        public AccountService(
            AppRoleMananger roleMananger,
            AppUserMananger userMananger)
        {
            RoleMananger = roleMananger;
            UserMananger = userMananger;
        }

        public AppRoleMananger RoleMananger { get; set; }

        public AppUserMananger UserMananger { get; set; }

        public async Task<AppUser> SignInAsync(
            IOwinContext owinContext,
            string userName,
            string userPwd,
            TimeSpan timeSpan,
            string authenticationType = DefaultAuthenticationTypes.ApplicationCookie)
        {
            var user = UserMananger.Find(userName, userPwd);

            if (user == default)
            {
                return await Task.FromResult(default(AppUser));
            }

            await UserMananger.SignInAsync(owinContext, user, timeSpan, authenticationType);

            return user;
        }

        public void SignOut(IOwinContext owinContext)
        {
            var authenticationManager = owinContext.Authentication;

            authenticationManager.SignOut();
        }

        public void CreateOrUpdate(AppUser user, IEnumerable<AppRole> roles)
        {
            var isExist = UserMananger.Users.Any(m => m.Id == user.Id);

            if (isExist)
            {
                var oldRoleIds = user.Roles.Select(m => m.RoleId).ToList();

                var oldRoles = RoleMananger.Roles.Where(m => oldRoleIds.Contains(m.Id));

                UserMananger.RemoveFromRoles(user.Id, oldRoles.Select(m => m.Name).ToArray());

                UserMananger.Create(user, AppUser.DefaultPassword);
            }
            else
            {
                UserMananger.Update(user);
            }

            UserMananger.AddToRoles(user.Id, roles.Select(m => m.Name).ToArray());
        }

        public IPagedList<AppUser> GetPagedList(int pageNumber, int pageSize, string search = default)
        {
            search = search?.Trim() ?? string.Empty;

            var users = UserMananger.Users.Where(m => m.Name.Contains(search));

            return users.ToPagedList(pageNumber, pageSize);
        }
    }
}
