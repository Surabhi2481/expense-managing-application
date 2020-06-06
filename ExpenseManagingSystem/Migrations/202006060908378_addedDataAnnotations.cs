namespace ExpenseManagingSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedDataAnnotations : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Expenses", "expenseName", c => c.String(nullable: false, maxLength: 25));
            AlterColumn("dbo.mainClasses", "name", c => c.String(nullable: false, maxLength: 50));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.mainClasses", "name", c => c.String(nullable: false));
            AlterColumn("dbo.Expenses", "expenseName", c => c.String(nullable: false));
        }
    }
}
