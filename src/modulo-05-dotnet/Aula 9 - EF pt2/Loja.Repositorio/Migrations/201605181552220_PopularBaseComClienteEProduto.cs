namespace Loja.Repositorio.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopularBaseComClienteEProduto : DbMigration
    {
        public override void Up()
        {
            Sql(@"INSERT INTO [dbo].[Cliente]
                           ([Email]
                           ,[Nome]
                           ,[Senha])
                     VALUES
                           ('conan@bol.com'
                           ,'Conan o Barbaro'
                           ,'123')");

            Sql(@"INSERT INTO [dbo].[Produto]
                           ([Nome]
                           ,[Valor]
                           ,[QuantidadeEstoque])
                     VALUES
                           ('Cinturão de Força'
                           ,100.90
                           ,4)");

            Sql(@"INSERT INTO [dbo].[Produto]
                           ([Nome]
                           ,[Valor]
                           ,[QuantidadeEstoque])
                     VALUES
                           ('Espada'
                           ,85
                           ,12)");
        }
        
        public override void Down()
        {
        }
    }
}
