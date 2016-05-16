namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MyFirstTime3 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Answers", "Question_Id", "dbo.Questions");
            DropForeignKey("dbo.Questions", "Category_Id", "dbo.QuestionCategories");
            DropForeignKey("dbo.Exams", "Category_Id", "dbo.QuestionCategories");
            DropForeignKey("dbo.Exams", "Subject_Id", "dbo.Subjects");
            DropForeignKey("dbo.Subjects", "AssignedTeacher_Id", "dbo.Teachers");
            DropForeignKey("dbo.Subjects", "Category_Id", "dbo.StudentCategories");
            DropForeignKey("dbo.Students", "Category_Id", "dbo.StudentCategories");
            DropIndex("dbo.Answers", new[] { "Question_Id" });
            DropIndex("dbo.Questions", new[] { "Category_Id" });
            DropIndex("dbo.Exams", new[] { "Category_Id" });
            DropIndex("dbo.Exams", new[] { "Subject_Id" });
            DropIndex("dbo.Subjects", new[] { "AssignedTeacher_Id" });
            DropIndex("dbo.Subjects", new[] { "Category_Id" });
            DropIndex("dbo.Students", new[] { "Category_Id" });
            AlterColumn("dbo.Answers", "Question_Id", c => c.Long(nullable: false));
            AlterColumn("dbo.Questions", "Task", c => c.String(nullable: false));
            AlterColumn("dbo.Questions", "Category_Id", c => c.Long(nullable: false));
            AlterColumn("dbo.QuestionCategories", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.Exams", "Category_Id", c => c.Long(nullable: false));
            AlterColumn("dbo.Exams", "Subject_Id", c => c.Long(nullable: false));
            AlterColumn("dbo.Subjects", "AssignedTeacher_Id", c => c.Long(nullable: false));
            AlterColumn("dbo.Subjects", "Category_Id", c => c.Long(nullable: false));
            AlterColumn("dbo.StudentCategories", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.Students", "Category_Id", c => c.Long(nullable: false));
            CreateIndex("dbo.Answers", "Question_Id");
            CreateIndex("dbo.Questions", "Category_Id");
            CreateIndex("dbo.Exams", "Category_Id");
            CreateIndex("dbo.Exams", "Subject_Id");
            CreateIndex("dbo.Subjects", "AssignedTeacher_Id");
            CreateIndex("dbo.Subjects", "Category_Id");
            CreateIndex("dbo.Students", "Category_Id");
            AddForeignKey("dbo.Answers", "Question_Id", "dbo.Questions", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Questions", "Category_Id", "dbo.QuestionCategories", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Exams", "Category_Id", "dbo.QuestionCategories", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Exams", "Subject_Id", "dbo.Subjects", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Subjects", "AssignedTeacher_Id", "dbo.Teachers", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Subjects", "Category_Id", "dbo.StudentCategories", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Students", "Category_Id", "dbo.StudentCategories", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Students", "Category_Id", "dbo.StudentCategories");
            DropForeignKey("dbo.Subjects", "Category_Id", "dbo.StudentCategories");
            DropForeignKey("dbo.Subjects", "AssignedTeacher_Id", "dbo.Teachers");
            DropForeignKey("dbo.Exams", "Subject_Id", "dbo.Subjects");
            DropForeignKey("dbo.Exams", "Category_Id", "dbo.QuestionCategories");
            DropForeignKey("dbo.Questions", "Category_Id", "dbo.QuestionCategories");
            DropForeignKey("dbo.Answers", "Question_Id", "dbo.Questions");
            DropIndex("dbo.Students", new[] { "Category_Id" });
            DropIndex("dbo.Subjects", new[] { "Category_Id" });
            DropIndex("dbo.Subjects", new[] { "AssignedTeacher_Id" });
            DropIndex("dbo.Exams", new[] { "Subject_Id" });
            DropIndex("dbo.Exams", new[] { "Category_Id" });
            DropIndex("dbo.Questions", new[] { "Category_Id" });
            DropIndex("dbo.Answers", new[] { "Question_Id" });
            AlterColumn("dbo.Students", "Category_Id", c => c.Long());
            AlterColumn("dbo.StudentCategories", "Name", c => c.String());
            AlterColumn("dbo.Subjects", "Category_Id", c => c.Long());
            AlterColumn("dbo.Subjects", "AssignedTeacher_Id", c => c.Long());
            AlterColumn("dbo.Exams", "Subject_Id", c => c.Long());
            AlterColumn("dbo.Exams", "Category_Id", c => c.Long());
            AlterColumn("dbo.QuestionCategories", "Name", c => c.String());
            AlterColumn("dbo.Questions", "Category_Id", c => c.Long());
            AlterColumn("dbo.Questions", "Task", c => c.String());
            AlterColumn("dbo.Answers", "Question_Id", c => c.Long());
            CreateIndex("dbo.Students", "Category_Id");
            CreateIndex("dbo.Subjects", "Category_Id");
            CreateIndex("dbo.Subjects", "AssignedTeacher_Id");
            CreateIndex("dbo.Exams", "Subject_Id");
            CreateIndex("dbo.Exams", "Category_Id");
            CreateIndex("dbo.Questions", "Category_Id");
            CreateIndex("dbo.Answers", "Question_Id");
            AddForeignKey("dbo.Students", "Category_Id", "dbo.StudentCategories", "Id");
            AddForeignKey("dbo.Subjects", "Category_Id", "dbo.StudentCategories", "Id");
            AddForeignKey("dbo.Subjects", "AssignedTeacher_Id", "dbo.Teachers", "Id");
            AddForeignKey("dbo.Exams", "Subject_Id", "dbo.Subjects", "Id");
            AddForeignKey("dbo.Exams", "Category_Id", "dbo.QuestionCategories", "Id");
            AddForeignKey("dbo.Questions", "Category_Id", "dbo.QuestionCategories", "Id");
            AddForeignKey("dbo.Answers", "Question_Id", "dbo.Questions", "Id");
        }
    }
}
