namespace Data.ModelConfigurations.AccountConfigurations
{
    using System.Data.Entity.ModelConfiguration;
    using Domain.UserAccounts.AppRoles;

    internal class AppRoleConfigurations : EntityTypeConfiguration<AppRole>
    {
        public AppRoleConfigurations() : base()
        {
            Property(m => m.Power).IsRequired();
        }
    }
}
