namespace Data.Mssql.ModelConfigurations.TestConfigurations
{
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.ModelConfiguration;
    using Domain.Tests;

    class TestConfiguration : EntityTypeConfiguration<Test>
    {
        public TestConfiguration() : base()
        {
            HasKey(m => m.Id);
            Property(m => m.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(m => m.RowVersion).IsRowVersion();

            Property(m => m.Title);

            ToTable("Test_Test");
        }
    }
}
