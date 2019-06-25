namespace Data.ModelConfigurations.AccountConfigurations
{
    using System.Data.Entity.ModelConfiguration;
    using Domain.UserAccounts.AppUsers;

    internal class AppUserConfigurations : EntityTypeConfiguration<AppUser>
    {
        public AppUserConfigurations() : base()
        {
            Property(m => m.Name).IsRequired().HasMaxLength(100);

            Property(m => m.Gender).IsRequired();
        }
    }
}
