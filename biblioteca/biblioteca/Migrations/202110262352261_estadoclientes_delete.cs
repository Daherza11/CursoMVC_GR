namespace biblioteca.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class estadoclientes_delete : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.cliente", "idestadocliente", "dbo.EstadoClientes");
            DropIndex("dbo.cliente", new[] { "idestadocliente" });
            DropColumn("dbo.cliente", "idestadocliente");
        }
        
        public override void Down()
        {
            AddColumn("dbo.cliente", "idestadocliente", c => c.Int());
            CreateIndex("dbo.cliente", "idestadocliente");
            AddForeignKey("dbo.cliente", "idestadocliente", "dbo.EstadoClientes", "idestadocliente");
        }
    }
}
