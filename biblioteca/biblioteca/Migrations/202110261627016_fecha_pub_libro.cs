namespace biblioteca.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fecha_pub_libro : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.libro", "fecha_pub", c => c.DateTime(nullable: false, storeType: "date"));
        }
        
        public override void Down()
        {
            DropColumn("dbo.libro", "fecha_pub");
        }
    }
}
