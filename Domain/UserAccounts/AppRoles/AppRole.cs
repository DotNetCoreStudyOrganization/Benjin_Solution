namespace Domain.UserAccounts.AppRoles
{
    using System;
    using Microsoft.AspNet.Identity.EntityFramework;

    public class AppRole : IdentityRole
    {
        public enum NameEnum
        {
            管理员,
            访客
        }

        public int Power { get; set; }

        public NameEnum? GetNameEnum(string name)
        {
            name = name?.Trim() ?? string.Empty;

            if (name.Length > 0 && Enum.TryParse(name, true, out NameEnum roleEnum))
            {
                return roleEnum;
            }

            return null;
        }
    }
}
