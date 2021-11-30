namespace biblioteca.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class estadosclientes : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.EstadoClientes",
                c => new
                    {
                        idestadocliente = c.Int(nullable: false, identity: true),
                        descripcion = c.String(),
                    })
                .PrimaryKey(t => t.idestadocliente);
            
            AddColumn("dbo.cliente", "idestadocliente", c => c.Int());
            CreateIndex("dbo.cliente", "idestadocliente");
            AddForeignKey("dbo.cliente", "idestadocliente", "dbo.EstadoClientes", "idestadocliente");
            DropColumn("dbo.cliente", "estado");
        }
        
        public override void Down()
        {
            AddColumn("dbo.cliente", "estado", c => c.String(maxLength: 10, fixedLength: true));
            DropForeignKey("dbo.cliente", "idestadocliente", "dbo.EstadoClientes");
            DropIndex("dbo.cliente", new[] { "idestadocliente" });
            DropColumn("dbo.cliente", "idestadocliente");
            DropTable("dbo.EstadoClientes");
        }
    }
}
