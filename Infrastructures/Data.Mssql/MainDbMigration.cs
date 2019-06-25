namespace Data.Mssql
{
    using System.Data.Entity;
    using System.Data.Entity.ModelConfiguration.Configuration;
    using Data.ModelConfigurations.AccountConfigurations;
    using Data.Mssql.ModelConfigurations.TestConfigurations;

    internal static class MainDbMigration
    {
        internal static void UseDbMigration(this DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations
                .UseAccountDbMigration()
                .UseTestDbMigration();
        }

        private static ConfigurationRegistrar UseAccountDbMigration(this ConfigurationRegistrar config)
        {
            config.Add(new AppUserConfigurations());
            config.Add(new AppRoleConfigurations());

            return config;
        }

        private static ConfigurationRegistrar UseTestDbMigration(this ConfigurationRegistrar config)
        {
            config.Add(new TestConfiguration());

            return config;
        }
    }
}
