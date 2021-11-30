namespace biblioteca.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class titulo_required : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.libro", "titulo", c => c.String(nullable: false, maxLength: 50, unicode: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.libro", "titulo", c => c.String(maxLength: 50, unicode: false));
        }
    }
}
