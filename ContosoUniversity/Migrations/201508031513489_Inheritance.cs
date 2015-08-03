namespace ContosoUniversity.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Inheritance : DbMigration
    {
        public override void Up()
        {
            // Drop foreign keys and indexes that point to tables we're going to drop. 
            DropForeignKey("dbo.Enrollment", "StudentId", "dbo.Student"); 
            DropIndex("dbo.Enrollment", new[] { "StudentId" }); 
 
            RenameTable(name: "dbo.Instructor", newName: "Person"); 
            AddColumn("dbo.Person", "EnrollmentDate", c => c.DateTime()); 
            AddColumn("dbo.Person", "Discriminator", c => c.String(nullable: false, maxLength: 128, defaultValue: "Instructor")); 
            AlterColumn("dbo.Person", "HireDate", c => c.DateTime()); 
            AddColumn("dbo.Person", "OldId", c => c.Int(nullable: true)); 
 
            // Copy existing Student data into new Person table. 
            Sql("INSERT INTO dbo.Person (LastName, FirstName, HireDate, EnrollmentDate, Discriminator, OldId) SELECT LastName, FirstName, null AS HireDate, EnrollmentDate, 'Student' AS Discriminator, Id AS OldId FROM dbo.Student"); 
 
            // Fix up existing relationships to match new PK's. 
            Sql("UPDATE dbo.Enrollment SET StudentId = (SELECT Id FROM dbo.Person WHERE OldId = Enrollment.StudentId AND Discriminator = 'Student')"); 
 
            // Remove temporary key 
            DropColumn("dbo.Person", "OldId"); 
 
            DropTable("dbo.Student"); 
 
            // Re-create foreign keys and indexes pointing to new table. 
            AddForeignKey("dbo.Enrollment", "StudentId", "dbo.Person", "Id", cascadeDelete: true); 
            CreateIndex("dbo.Enrollment", "StudentId"); 
        }
        
        public override void Down()
        {
            // TODO: make appropriate changes for downgrade
            // In a production system you would make corresponding changes
            // to the Down method in case you ever had to use that to go back
            // to the previous database version. 
            // For this tutorial you won't be using the Down method.
            CreateTable(
                "dbo.Student",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        LastName = c.String(nullable: false, maxLength: 50),
                        FirstName = c.String(nullable: false, maxLength: 50),
                        EnrollmentDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AlterColumn("dbo.Person", "HireDate", c => c.DateTime(nullable: false));
            DropColumn("dbo.Person", "Discriminator");
            DropColumn("dbo.Person", "EnrollmentDate");
            RenameTable(name: "dbo.Person", newName: "Instructor");
        }
    }
}
