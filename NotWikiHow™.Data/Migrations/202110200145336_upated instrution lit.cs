namespace NotWikiHow_.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class upatedinstrutionlit : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Instruction", "Tutorial_TutorId", "dbo.Tutorial");
            DropIndex("dbo.Instruction", new[] { "Tutorial_TutorId" });
            DropTable("dbo.Instruction");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Instruction",
                c => new
                    {
                        InstructId = c.Int(nullable: false, identity: true),
                        Step = c.Int(nullable: false),
                        Title = c.String(),
                        Description = c.String(),
                        Tutorial_TutorId = c.Int(),
                    })
                .PrimaryKey(t => t.InstructId);
            
            CreateIndex("dbo.Instruction", "Tutorial_TutorId");
            AddForeignKey("dbo.Instruction", "Tutorial_TutorId", "dbo.Tutorial", "TutorId");
        }
    }
}
