namespace Domain.UserAccounts.AppRoles
{
    using Microsoft.AspNet.Identity;

    public class AppRoleMananger : RoleManager<AppRole>
    {
        public AppRoleMananger(IRoleStore<AppRole, string> store) : base(store)
        {
        }
    }
}
