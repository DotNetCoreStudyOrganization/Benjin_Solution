namespace Domain.UserAccounts.AppUsers
{
    using System;
    using System.Security.Principal;
    using System.Threading.Tasks;
    using Microsoft.AspNet.Identity;
    using Microsoft.Owin;
    using Microsoft.Owin.Security;

    public class AppUserMananger : UserManager<AppUser>
    {
        public AppUserMananger(IUserStore<AppUser> store) : base(store)
        {
            // 配置用户名的验证逻辑
            UserValidator = new UserValidator<AppUser>(this)
            {
                AllowOnlyAlphanumericUserNames = true,
                RequireUniqueEmail = false
            };

            // 配置密码的验证逻辑
            PasswordValidator = new PasswordValidator
            {
                RequiredLength = 6,
                RequireNonLetterOrDigit = false,
                RequireDigit = true,
                RequireLowercase = true,
                RequireUppercase = false
            };

            UserTokenProvider = new EmailTokenProvider<AppUser>();
        }

        protected IPrincipal CurrentPrincipal { get; private set; }

        public void InitCurrentPrincipal(IPrincipal principal)
        {
            if (CurrentPrincipal == null)
            {
                return;
            }

            CurrentPrincipal = principal;
        }

        public async Task<AppUser> GetCurrentAppUserAsync()
        {
            var userId = CurrentPrincipal?.Identity?.GetUserId();

            var user = await FindByIdAsync(userId ?? string.Empty);

            return user;
        }

        public async Task SignInAsync(
            IOwinContext owinContext, 
            AppUser user, 
            TimeSpan timeSpan,
            string authenticationType = DefaultAuthenticationTypes.ApplicationCookie)
        {
            var authenticationManager = owinContext.Authentication;

            authenticationManager.SignOut();

            authenticationManager.SignIn(
                new AuthenticationProperties
                {
                    IsPersistent = true,
                    IssuedUtc = DateTime.Now,
                    ExpiresUtc = DateTime.Now.Add(timeSpan)
                },
                await CreateIdentityAsync(user, authenticationType));
        }

        public void SignOut(IOwinContext owinContext)
        {
            var authenticationManager = owinContext.Authentication;

            authenticationManager.SignOut();
        }
    }
}
