namespace Church.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddEnvelopeNumberToMember : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Members", "EnvelopeNumber", c => c.String());
            DropColumn("dbo.Transactions", "EnvelopeNumber");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Transactions", "EnvelopeNumber", c => c.String());
            DropColumn("dbo.Members", "EnvelopeNumber");
        }
    }
}
