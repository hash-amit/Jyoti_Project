namespace LibraryManagementSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangedDataOfHobby : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.TblUsers", "Hobby", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.TblUsers", "Hobby", c => c.Int(nullable: false));
        }
    }
}
