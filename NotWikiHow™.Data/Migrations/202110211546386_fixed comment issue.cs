namespace NotWikiHow_.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fixedcommentissue : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.Comment", "TutorId");
            AddForeignKey("dbo.Comment", "TutorId", "dbo.Tutorial", "TutorId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Comment", "TutorId", "dbo.Tutorial");
            DropIndex("dbo.Comment", new[] { "TutorId" });
        }
    }
}
