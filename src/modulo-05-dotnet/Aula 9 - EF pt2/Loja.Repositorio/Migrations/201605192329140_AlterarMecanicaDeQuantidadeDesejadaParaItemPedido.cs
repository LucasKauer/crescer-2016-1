namespace Loja.Repositorio.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AlterarMecanicaDeQuantidadeDesejadaParaItemPedido : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ItemPedido", "QuantidadeDesejada", c => c.Int(nullable: false));

            Sql(@"UPDATE ItemPedido SET QuantidadeDesejada = Quantidade");

            DropColumn("dbo.ItemPedido", "Quantidade");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ItemPedido", "Quantidade", c => c.Int(nullable: false));

            Sql(@"UPDATE ItemPedido SET Quantidade = QuantidadeDesejada");

            DropColumn("dbo.ItemPedido", "QuantidadeDesejada");
        }
    }
}
