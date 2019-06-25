namespace Data.Mssql.Migrations
{
    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<Data.Mssql.MainDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = Infrastructure.HostConfigure.MssqlDbConfigure?.EnableAutoMigration == true;
        }

        protected override void Seed(Data.Mssql.MainDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.

            context.UseSeed();
        }
    }
}
