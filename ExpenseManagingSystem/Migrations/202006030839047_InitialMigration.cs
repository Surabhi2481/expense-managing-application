namespace ExpenseManagingSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Expenses",
                c => new
                    {
                        expenseId = c.String(nullable: false, maxLength: 128),
                        userId = c.String(nullable: false, maxLength: 128),
                        expenseName = c.String(),
                        expenseType = c.Int(nullable: false),
                        expenseDate = c.DateTime(),
                        amount = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.expenseId)
                .ForeignKey("dbo.mainClasses", t => t.userId, cascadeDelete: true)
                .Index(t => t.userId);
            
            CreateTable(
                "dbo.mainClasses",
                c => new
                    {
                        userId = c.String(nullable: false, maxLength: 128),
                        name = c.String(),
                        dob = c.DateTime(),
                        gender = c.Int(nullable: false),
                        phone = c.String(),
                        email = c.String(),
                        password = c.String(),
                    })
                .PrimaryKey(t => t.userId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Expenses", "userId", "dbo.mainClasses");
            DropIndex("dbo.Expenses", new[] { "userId" });
            DropTable("dbo.mainClasses");
            DropTable("dbo.Expenses");
        }
    }
}
