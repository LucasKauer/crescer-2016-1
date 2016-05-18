
INSERT INTO [dbo].[Usuario]
           ([Nome]
           ,[Email]
           ,[Senha])
     VALUES
           ('Ben-hur'
           ,'ben-hur@cwi.com.br'
           ,'72f3f890e32827717f8a18c09b670394') -- Cwi123

GO

INSERT INTO [dbo].[Permissao]
			([Nome])
		VALUES
			('COMUM'),
			('ADMIN')
GO

INSERT INTO [dbo].[UsuarioPermissao]
			([IdUsuario]
			,[IdPermissao])
		VALUES
			((SELECT Id FROM Usuario WHERE Email = 'ben-hur@cwi.com.br'),
			 (SELECT Id FROM Permissao WHERE Nome = 'ADMIN'))
GO

