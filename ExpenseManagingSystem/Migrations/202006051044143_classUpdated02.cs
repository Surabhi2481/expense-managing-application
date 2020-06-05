namespace ExpenseManagingSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class classUpdated02 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Expenses", "expenseDate", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Expenses", "expenseDate", c => c.DateTime(nullable: false));
        }
    }
}
