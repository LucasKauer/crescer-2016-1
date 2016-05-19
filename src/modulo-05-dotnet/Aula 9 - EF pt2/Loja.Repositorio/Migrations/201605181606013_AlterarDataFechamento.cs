namespace Loja.Repositorio.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AlterarDataFechamento : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Pedido", "DataFechamento", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Pedido", "DataFechamento", c => c.DateTime(nullable: false));
        }
    }
}
