namespace Loja.Repositorio.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AlterandoValoresDeItemPedido : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ItemPedido", "ValorDoProdutoNaVenda", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            DropColumn("dbo.ItemPedido", "ValorVenda");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ItemPedido", "ValorVenda", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            DropColumn("dbo.ItemPedido", "ValorDoProdutoNaVenda");
        }
    }
}
