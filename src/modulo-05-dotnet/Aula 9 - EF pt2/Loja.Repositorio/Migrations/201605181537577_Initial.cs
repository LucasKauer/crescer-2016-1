namespace Loja.Repositorio.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Cliente",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Email = c.String(maxLength: 250),
                        Nome = c.String(maxLength: 100),
                        Senha = c.String(maxLength: 200),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Email, unique: true);
            
            CreateTable(
                "dbo.ItemPedido",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ValorVenda = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Quantidade = c.Int(nullable: false),
                        Produto_Id = c.Int(),
                        Pedido_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Produto", t => t.Produto_Id)
                .ForeignKey("dbo.Pedido", t => t.Pedido_Id)
                .Index(t => t.Produto_Id)
                .Index(t => t.Pedido_Id);
            
            CreateTable(
                "dbo.Produto",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(maxLength: 100),
                        Valor = c.Decimal(nullable: false, precision: 18, scale: 2),
                        QuantidadeEstoque = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Nome, unique: true);
            
            CreateTable(
                "dbo.Pedido",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DataAbertura = c.DateTime(nullable: false),
                        DataFechamento = c.DateTime(nullable: false),
                        StatusPedido = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ItemPedido", "Pedido_Id", "dbo.Pedido");
            DropForeignKey("dbo.ItemPedido", "Produto_Id", "dbo.Produto");
            DropIndex("dbo.ItemPedido", new[] { "Pedido_Id" });
            DropIndex("dbo.ItemPedido", new[] { "Produto_Id" });
            DropTable("dbo.Pedido");
            DropTable("dbo.Produto");
            DropTable("dbo.ItemPedido");
            DropTable("dbo.Cliente");
        }
    }
}
