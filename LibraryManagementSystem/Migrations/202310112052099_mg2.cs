namespace LibraryManagementSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mg2 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TblHobbies",
                c => new
                    {
                        HobbyId = c.Int(nullable: false, identity: true),
                        HobbyName = c.String(),
                    })
                .PrimaryKey(t => t.HobbyId);
            
            AddColumn("dbo.TblUsers", "Hobby", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.TblUsers", "Hobby");
            DropTable("dbo.TblHobbies");
        }
    }
}
