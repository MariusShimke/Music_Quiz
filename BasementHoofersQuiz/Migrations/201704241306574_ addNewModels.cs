namespace BasementHoofersQuiz.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addNewModels : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AttemptModels",
                c => new
                    {
                        attemptId = c.Int(nullable: false, identity: true),
                        quizId = c.Int(nullable: false),
                        UserId = c.String(),
                        quizResult = c.String(),
                    })
                .PrimaryKey(t => t.attemptId);
            
            CreateTable(
                "dbo.QuizModels",
                c => new
                    {
                        quizId = c.Int(nullable: false, identity: true),
                        quizTitle = c.String(),
                        quizDescription = c.String(),
                    })
                .PrimaryKey(t => t.quizId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.QuizModels");
            DropTable("dbo.AttemptModels");
        }
    }
}
