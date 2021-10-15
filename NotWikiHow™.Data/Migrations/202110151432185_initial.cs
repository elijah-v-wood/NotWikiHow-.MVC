namespace NotWikiHow_.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Comment",
                c => new
                    {
                        CommentId = c.Int(nullable: false, identity: true),
                        TutorId = c.Int(nullable: false),
                        UserId = c.Guid(nullable: false),
                        Question = c.String(),
                        CreatedUTC = c.DateTimeOffset(nullable: false, precision: 7),
                        ModifiedUTC = c.DateTimeOffset(nullable: false, precision: 7),
                    })
                .PrimaryKey(t => t.CommentId);
            
            CreateTable(
                "dbo.Reply",
                c => new
                    {
                        ReplyId = c.Int(nullable: false, identity: true),
                        CommentId = c.Int(nullable: false),
                        UserId = c.Guid(nullable: false),
                        TutorId = c.Int(nullable: false),
                        Content = c.String(),
                        CreatedUTC = c.DateTimeOffset(nullable: false, precision: 7),
                        ModifiedUTC = c.DateTimeOffset(nullable: false, precision: 7),
                    })
                .PrimaryKey(t => t.ReplyId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Reply");
            DropTable("dbo.Comment");
        }
    }
}
