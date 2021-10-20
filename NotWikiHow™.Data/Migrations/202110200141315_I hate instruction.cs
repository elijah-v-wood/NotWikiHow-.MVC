namespace NotWikiHow_.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Ihateinstruction : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Instruction", "TutorId", "dbo.Tutorial");
            DropIndex("dbo.Instruction", new[] { "TutorId" });
            RenameColumn(table: "dbo.Instruction", name: "TutorId", newName: "Tutorial_TutorId");
            AlterColumn("dbo.Instruction", "Tutorial_TutorId", c => c.Int());
            CreateIndex("dbo.Instruction", "Tutorial_TutorId");
            AddForeignKey("dbo.Instruction", "Tutorial_TutorId", "dbo.Tutorial", "TutorId");
            DropColumn("dbo.Instruction", "ImageId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Instruction", "ImageId", c => c.Int(nullable: false));
            DropForeignKey("dbo.Instruction", "Tutorial_TutorId", "dbo.Tutorial");
            DropIndex("dbo.Instruction", new[] { "Tutorial_TutorId" });
            AlterColumn("dbo.Instruction", "Tutorial_TutorId", c => c.Int(nullable: false));
            RenameColumn(table: "dbo.Instruction", name: "Tutorial_TutorId", newName: "TutorId");
            CreateIndex("dbo.Instruction", "TutorId");
            AddForeignKey("dbo.Instruction", "TutorId", "dbo.Tutorial", "TutorId", cascadeDelete: true);
        }
    }
}
