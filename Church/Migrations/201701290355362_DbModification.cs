namespace Church.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DbModification : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Members", "FirstName", c => c.String(nullable: false));
            AlterColumn("dbo.Members", "LastName", c => c.String(nullable: false));
            AlterColumn("dbo.Members", "City", c => c.String(nullable: false));
            AlterColumn("dbo.Members", "Gender", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Members", "Gender", c => c.String());
            AlterColumn("dbo.Members", "City", c => c.String());
            AlterColumn("dbo.Members", "LastName", c => c.String());
            AlterColumn("dbo.Members", "FirstName", c => c.String());
        }
    }
}
