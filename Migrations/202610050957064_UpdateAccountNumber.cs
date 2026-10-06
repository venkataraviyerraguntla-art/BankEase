namespace BankEase.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateAccountNumber : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Accounts", "AccountNumber", c => c.String(nullable: false, maxLength: 10));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Accounts", "AccountNumber", c => c.String());
        }
    }
}
