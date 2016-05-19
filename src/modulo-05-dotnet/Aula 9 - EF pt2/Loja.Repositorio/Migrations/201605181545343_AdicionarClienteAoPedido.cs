namespace Loja.Repositorio.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AdicionarClienteAoPedido : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Pedido", "Cliente_Id", c => c.Int());
            CreateIndex("dbo.Pedido", "Cliente_Id");
            AddForeignKey("dbo.Pedido", "Cliente_Id", "dbo.Cliente", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Pedido", "Cliente_Id", "dbo.Cliente");
            DropIndex("dbo.Pedido", new[] { "Cliente_Id" });
            DropColumn("dbo.Pedido", "Cliente_Id");
        }
    }
}
