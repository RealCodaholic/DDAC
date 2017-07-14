namespace DDAC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DDAC_Migration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BookingContainers",
                c => new
                    {
                        BookingContainerID = c.Int(nullable: false, identity: true),
                        BookingID = c.Int(nullable: false),
                        ContainerID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.BookingContainerID)
                .ForeignKey("dbo.Bookings", t => t.BookingID, cascadeDelete: false)
                .ForeignKey("dbo.Containers", t => t.ContainerID, cascadeDelete: false)
                .Index(t => t.BookingID)
                .Index(t => t.ContainerID);
            
            CreateTable(
                "dbo.Bookings",
                c => new
                    {
                        BookingID = c.Int(nullable: false, identity: true),
                        TotalCost = c.Double(nullable: false),
                        DepartureTime = c.DateTime(nullable: false),
                        Source = c.Int(nullable: false),
                        Destination = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.BookingID)
                .ForeignKey("dbo.ShipDocks", t => t.Destination, cascadeDelete: false)
                .ForeignKey("dbo.ShipDocks", t => t.Source, cascadeDelete: false)
                .Index(t => t.Source)
                .Index(t => t.Destination);
            
            CreateTable(
                "dbo.ShipDocks",
                c => new
                    {
                        ShipDockID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Country = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.ShipDockID);
            
            CreateTable(
                "dbo.Containers",
                c => new
                    {
                        ContainerID = c.Int(nullable: false, identity: true),
                        TotalLoad = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.ContainerID);
            
            CreateTable(
                "dbo.Ships",
                c => new
                    {
                        ShipID = c.Int(nullable: false, identity: true),
                        MaximumLoad = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.ShipID);
            
            CreateTable(
                "dbo.UserTokenCaches",
                c => new
                    {
                        UserTokenCacheId = c.Int(nullable: false, identity: true),
                        webUserUniqueId = c.String(),
                        cacheBits = c.Binary(),
                        LastWrite = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.UserTokenCacheId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.BookingContainers", "ContainerID", "dbo.Containers");
            DropForeignKey("dbo.BookingContainers", "BookingID", "dbo.Bookings");
            DropForeignKey("dbo.Bookings", "Source", "dbo.ShipDocks");
            DropForeignKey("dbo.Bookings", "Destination", "dbo.ShipDocks");
            DropIndex("dbo.Bookings", new[] { "Destination" });
            DropIndex("dbo.Bookings", new[] { "Source" });
            DropIndex("dbo.BookingContainers", new[] { "ContainerID" });
            DropIndex("dbo.BookingContainers", new[] { "BookingID" });
            DropTable("dbo.UserTokenCaches");
            DropTable("dbo.Ships");
            DropTable("dbo.Containers");
            DropTable("dbo.ShipDocks");
            DropTable("dbo.Bookings");
            DropTable("dbo.BookingContainers");
        }
    }
}
