namespace Church.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialDatabase : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Departments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Status = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Members",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        MiddleName = c.String(),
                        CellPhone = c.String(),
                        HomePhone = c.String(),
                        Email = c.String(),
                        Address = c.String(),
                        City = c.String(),
                        PostalCode = c.String(),
                        Province = c.String(),
                        Gender = c.String(),
                        Status = c.Int(nullable: false),
                        Department_Id = c.Int(),
                        Profession_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Departments", t => t.Department_Id)
                .ForeignKey("dbo.Professions", t => t.Profession_Id)
                .Index(t => t.Department_Id)
                .Index(t => t.Profession_Id);
            
            CreateTable(
                "dbo.Professions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                        Status = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Transactions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Type = c.Int(nullable: false),
                        Amount = c.Double(nullable: false),
                        Date = c.DateTime(nullable: false),
                        EnvelopeNumber = c.String(),
                        Status = c.Int(nullable: false),
                        Counter_Id = c.Int(),
                        Member_Id = c.Int(),
                        Member_Id1 = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Members", t => t.Counter_Id)
                .ForeignKey("dbo.Members", t => t.Member_Id)
                .ForeignKey("dbo.Members", t => t.Member_Id1)
                .Index(t => t.Counter_Id)
                .Index(t => t.Member_Id)
                .Index(t => t.Member_Id1);
            
            CreateTable(
                "dbo.UserProfile",
                c => new
                    {
                        UserId = c.Int(nullable: false, identity: true),
                        UserName = c.String(),
                    })
                .PrimaryKey(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Transactions", "Member_Id1", "dbo.Members");
            DropForeignKey("dbo.Transactions", "Member_Id", "dbo.Members");
            DropForeignKey("dbo.Transactions", "Counter_Id", "dbo.Members");
            DropForeignKey("dbo.Members", "Profession_Id", "dbo.Professions");
            DropForeignKey("dbo.Members", "Department_Id", "dbo.Departments");
            DropIndex("dbo.Transactions", new[] { "Member_Id1" });
            DropIndex("dbo.Transactions", new[] { "Member_Id" });
            DropIndex("dbo.Transactions", new[] { "Counter_Id" });
            DropIndex("dbo.Members", new[] { "Profession_Id" });
            DropIndex("dbo.Members", new[] { "Department_Id" });
            DropTable("dbo.UserProfile");
            DropTable("dbo.Transactions");
            DropTable("dbo.Professions");
            DropTable("dbo.Members");
            DropTable("dbo.Departments");
        }
    }
}
