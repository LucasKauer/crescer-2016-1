CREATE TABLE [Usuario]
(
	[Id] INT IDENTITY PRIMARY KEY,
	[Nome] VARCHAR(100) NOT NULL UNIQUE,
	[Email] VARCHAR(250) NOT NULL,
	[Senha] VARCHAR(100) NOT NULL
)

CREATE TABLE [Permissao]
(
	[Id] INT IDENTITY PRIMARY KEY,
	[Nome] VARCHAR(50) NOT NULL UNIQUE
)

CREATE TABLE [UsuarioPermissao]
(
	[Id] INT IDENTITY PRIMARY KEY,
	[IdUsuario] INT NOT NULL,
	[IdPermissao] INT NOT NULL,

	FOREIGN KEY ([IdUsuario]) REFERENCES Usuario(Id),
	FOREIGN KEY ([IdPermissao]) REFERENCES [Permissao](Id)
)