namespace biblioteca.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class estadoclientes_relacion : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.cliente", "idestadocliente", c => c.Int(nullable: false));
            CreateIndex("dbo.cliente", "idestadocliente");
            AddForeignKey("dbo.cliente", "idestadocliente", "dbo.EstadoClientes", "idestadocliente", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.cliente", "idestadocliente", "dbo.EstadoClientes");
            DropIndex("dbo.cliente", new[] { "idestadocliente" });
            DropColumn("dbo.cliente", "idestadocliente");
        }
    }
}
