namespace Data.Mssql
{
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.ModelConfiguration.Conventions;
    using System.Linq;
    using Infrastructure;
    using Microsoft.AspNet.Identity.EntityFramework;

    internal class MainDbContext : IdentityDbContext
    {
        private static readonly string nameOrConnectionString;

        public MainDbContext() : base(nameOrConnectionString)
        {
            if (HostConfigure.MssqlDbConfigure.EnableAutoMigration)
            {
                Database.SetInitializer(new MigrateDatabaseToLatestVersion<MainDbContext, Migrations.Configuration>());
            }
        }

        static MainDbContext()
        {
            nameOrConnectionString = HostConfigure.MssqlDbConfigure?.ConnectionString;

            nameOrConnectionString = nameOrConnectionString ?? $"name=MainDbContext";
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingEntitySetNameConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();

            modelBuilder.UseDbMigration();

            base.OnModelCreating(modelBuilder);
        }

        public IReadOnlyCollection<string> Valid()
            => GetValidationErrors()
            .Where(m => m.IsValid == false)
            .SelectMany(m => m.ValidationErrors)
            .Select(m => $"{m.PropertyName}-{m.ErrorMessage}")
            .ToList()
            .AsReadOnly();
    }
}
