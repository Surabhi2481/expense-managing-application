namespace ExpenseManagingSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatedDataAnnotations : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Expenses", "expenseName", c => c.String(nullable: false));
            AlterColumn("dbo.Expenses", "expenseDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Expenses", "amount", c => c.String(nullable: false));
            AlterColumn("dbo.mainClasses", "name", c => c.String(nullable: false));
            AlterColumn("dbo.mainClasses", "phone", c => c.String(nullable: false));
            AlterColumn("dbo.mainClasses", "email", c => c.String(nullable: false));
            AlterColumn("dbo.mainClasses", "password", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.mainClasses", "password", c => c.String());
            AlterColumn("dbo.mainClasses", "email", c => c.String());
            AlterColumn("dbo.mainClasses", "phone", c => c.String());
            AlterColumn("dbo.mainClasses", "name", c => c.String());
            AlterColumn("dbo.Expenses", "amount", c => c.Int(nullable: false));
            AlterColumn("dbo.Expenses", "expenseDate", c => c.DateTime());
            AlterColumn("dbo.Expenses", "expenseName", c => c.String());
        }
    }
}
