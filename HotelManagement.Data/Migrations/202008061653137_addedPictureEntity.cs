namespace HotelManagement.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedPictureEntity : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AccommodationPackagePictures",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        AccommodationPackageID = c.Int(nullable: false),
                        PictureID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Pictures", t => t.PictureID, cascadeDelete: true)
                .ForeignKey("dbo.AccommodationPackages", t => t.AccommodationPackageID, cascadeDelete: true)
                .Index(t => t.AccommodationPackageID)
                .Index(t => t.PictureID);
            
            CreateTable(
                "dbo.Pictures",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Url = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.AccommodationPictures",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        AccommodationID = c.Int(nullable: false),
                        PictureID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Pictures", t => t.PictureID, cascadeDelete: true)
                .ForeignKey("dbo.Accommodations", t => t.AccommodationID, cascadeDelete: true)
                .Index(t => t.AccommodationID)
                .Index(t => t.PictureID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AccommodationPictures", "AccommodationID", "dbo.Accommodations");
            DropForeignKey("dbo.AccommodationPictures", "PictureID", "dbo.Pictures");
            DropForeignKey("dbo.AccommodationPackagePictures", "AccommodationPackageID", "dbo.AccommodationPackages");
            DropForeignKey("dbo.AccommodationPackagePictures", "PictureID", "dbo.Pictures");
            DropIndex("dbo.AccommodationPictures", new[] { "PictureID" });
            DropIndex("dbo.AccommodationPictures", new[] { "AccommodationID" });
            DropIndex("dbo.AccommodationPackagePictures", new[] { "PictureID" });
            DropIndex("dbo.AccommodationPackagePictures", new[] { "AccommodationPackageID" });
            DropTable("dbo.AccommodationPictures");
            DropTable("dbo.Pictures");
            DropTable("dbo.AccommodationPackagePictures");
        }
    }
}
