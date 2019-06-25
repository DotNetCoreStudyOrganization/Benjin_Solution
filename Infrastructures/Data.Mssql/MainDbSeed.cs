namespace Data.Mssql
{
    using System.Data.Entity.Migrations;
    using Domain.UserAccounts.AppRoles;
    using Domain.UserAccounts.AppUsers;
    using Microsoft.AspNet.Identity.EntityFramework;

    internal static class MainDbSeed
    {
        internal static void UseSeed(this MainDbContext context)
        {
            context.UseAccountSeed();
        }

        private static MainDbContext UseAccountSeed(this MainDbContext context)
        {
            context.Set<AppRole>().AddOrUpdate(
                m => m.Id,
                new AppRole
                {
                    Id = "A000A000-A000-A000-A000-A000A000A000A000",
                    Name = AppRole.NameEnum.管理员.ToString(),
                    Power = 1
                },
                new AppRole
                {
                    Id = "A001A000-A000-A000-A000-A000A000A000A000",
                    Name = AppRole.NameEnum.访客.ToString(),
                    Power = 10
                });

            context.Set<AppUser>().AddOrUpdate(
                m => m.Id,
                new AppUser
                {
                    Id = "A000A001-A000-A000-A000-A000A000A000A000",
                    UserName = "Admin",
                    Name = "管理员",
                    PasswordHash = "AInfLTnemG3NjTm7qFr+TsIaX6eMbuVzQpQVRamaiL90lLoH/HhKXSdiEsRn2CBFpw==",
                    SecurityStamp = "1e95dbe8-b817-4993-8dac-b04d2f06bd42"
                });

            context.Set<IdentityUserRole>().AddOrUpdate(
                m => m.UserId,
                new IdentityUserRole
                {
                    UserId = "A000A001-A000-A000-A000-A000A000A000A000",
                    RoleId = "A000A000-A000-A000-A000-A000A000A000A000"
                });

            return context;
        }
    }
}
