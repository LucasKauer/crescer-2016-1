namespace LojaNinja.Repositorio.EF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    /*
     * Geramos esta Migration com o nome Inital a partir do comando Add-Migration "Initial".
     * Uma migration nada mais � que um processo de atualiza��o do banco, onde o entity framework
     * vai verificar nosso modelo atual (aquele que colocamos nos DbSets da classe ContextoDeDados)
     * e vai executar no banco de dados o que � necess�rio para deix�-lo atualizado.
     * 
     * Quando executarmos o comando Update-Database, o EF ir� ler todas as classes Migration, em ordem.
     * Para cada uma delas, ele ir� ver se ela j� foi executada no banco.
     * As que n�o foram, ser�o executadas.
     */
    public partial class Initial : DbMigration
    {
        /*
         * Este m�todo ser� executado no Update-Database
         */
        public override void Up()
        {
            /*
             * Este � um m�todo que criar� uma tabela
             */
            CreateTable(
                "dbo.Pedido", // <-- este � o nome da tabela a ser criada
                c => new
                    { // <-- neste objeto anonimo, temos as colunas da tabela.

                        /*
                         * Vamos explicar como funciona isto.
                         * Primeiro, temos o nome do campo, no caso, Id.
                         * Depois, definimos que o tipo de dados da coluna � um INT.
                         * Como par�metro do m�todo .Int, temos as configura��es da coluna, por exemplo:
                         *      nullable --> se aceita null ou n�o.
                         *      identity --> se o campo � auto-incremental.
                         *      
                         * Por padr�o, o EF identifica se o seu tipo do DbSet tem uma propriedade Id,
                         * se tiver, ele assume que � a chave prim�ria.
                         */
                        Id = c.Int(nullable: false, identity: true),
                        DataPedido = c.DateTime(nullable: false),
                        DataEntregaDesejada = c.DateTime(nullable: false),
                        NomeProduto = c.String(),
                        Valor = c.Decimal(nullable: false, precision: 18, scale: 2),
                        TipoPagamento = c.Int(nullable: false),
                        NomeCliente = c.String(),
                        Cidade = c.String(),
                        Estado = c.String(),
                        PedidoUrgente = c.Boolean(nullable: false),
                    })
                /*
                 * Aqui estamos definindo que a propriedade Id ser� a chave prim�ria.                 
                 */
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Permissao",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.Id)
                /*
                 * Criamos este �ndice para dizer que o campo Nome deve ser �nico.
                 * ATEN��O: o problema que tivemos em aula por n�o conseguir colocar como UNIQUE
                 * � que o campo nome n�o tinha MAXLENGTH. N�o � poss�vel aplicar UNIQUE em colunas
                 * com varchar(MAX).
                 */
                .Index(t => t.Nome, unique: true);
            
            CreateTable(
                "dbo.Usuario",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Email = c.String(maxLength: 250),
                        Senha = c.String(),
                        Nome = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Email, unique: true);

            /*
             * Esta tabela foi gerada automaticamente pelo EF porque ele identificou
             * que no tipo Usuario tem uma lista de Permissao e na Permissao tem uma
             * lista de Usuario, formando um N - N.
             */
            CreateTable(
                "dbo.UsuarioPermissao",
                c => new
                    {
                        /*
                         * Por padr�o, estas tabelas n�o possuem um Id,
                         * ent�o criamos um para ela (opcional).
                         * 
                         * Mas com isso, devemos mudar a condi��o PrimaryKey abaixo.
                         */
                        Id = c.Int(nullable: false, identity: true),
                        Usuario_Id = c.Int(nullable: false),
                        Permissao_Id = c.Int(nullable: false),
                    })
                /*
                 * Como criamos uma primary key, mudamos nossa estrategia aqui.
                 */
                //.PrimaryKey(t => new { t.Usuario_Id, t.Permissao_Id }) // <-- original
                .PrimaryKey(t => t.Id) // <-- novo
                .ForeignKey("dbo.Usuario", t => t.Usuario_Id, cascadeDelete: true)
                .ForeignKey("dbo.Permissao", t => t.Permissao_Id, cascadeDelete: true)
                .Index(t => t.Usuario_Id)
                .Index(t => t.Permissao_Id);

            /*
             * Nos decidimos que esse Migration, quando executado, deve tamb�m inserir um
             * usu�rio padr�o.
             * 
             * Para isso, criamos um SQL para isso.
             */
            Sql(@"INSERT INTO Usuario 
                        (Email
                        ,Senha
                        ,Nome) 
                    VALUES 
                        ('ben-hur@cwi.com.br'
                        ,'72f3f890e32827717f8a18c09b670394'
                        ,'Ben-hur')
                  GO");

            /*
             * O mesmo para permiss�es...
             */
            Sql(@"INSERT INTO [dbo].[Permissao]
			                ([Nome])
		                VALUES
			                ('COMUM'),
			                ('ADMIN')
                GO");

            /*
             * ... E para linkar usu�rios com permiss�es.
             */
            Sql(@"INSERT INTO [dbo].[UsuarioPermissao]
			                ([Usuario_Id]
			                ,[Permissao_Id])
		                VALUES
			                ((SELECT Id FROM Usuario WHERE Email = 'ben-hur@cwi.com.br'),
			                 (SELECT Id FROM Permissao WHERE Nome = 'ADMIN'))
                GO");

        }
        
        /*
         * Este m�todo ser� executado quando precisarmos fazer rollback do banco para
         * um migration espec�fico.
         */
        public override void Down()
        {
            DropForeignKey("dbo.UsuarioPermissao", "Permissao_Id", "dbo.Permissao");
            DropForeignKey("dbo.UsuarioPermissao", "Usuario_Id", "dbo.Usuario");
            DropIndex("dbo.UsuarioPermissao", new[] { "Permissao_Id" });
            DropIndex("dbo.UsuarioPermissao", new[] { "Usuario_Id" });
            DropTable("dbo.UsuarioPermissao");
            DropTable("dbo.Usuario");
            DropTable("dbo.Permissao");
            DropTable("dbo.Pedido");
        }
    }
}
