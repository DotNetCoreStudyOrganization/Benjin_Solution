namespace Data.Mssql.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class TestModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Test_Test",
                c => new
                {
                    Id = c.Guid(nullable: false, identity: true),
                    Title = c.String(),
                    RowVersion = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                })
                .PrimaryKey(t => t.Id);
        }

        public override void Down()
        {
            DropTable("dbo.Test_Test");
        }
    }
}
