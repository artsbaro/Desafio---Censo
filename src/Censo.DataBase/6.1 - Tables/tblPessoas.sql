CREATE TABLE [tblPessoas] (
    [Id] uniqueidentifier NOT NULL,
    [Nome] varchar(100) NOT NULL DEFAULT '',
    [SobreNome] varchar(100) NOT NULL DEFAULT '',
    [MaeId] uniqueidentifier NULL,
    [PaiId] uniqueidentifier NULL,
    [GeneroId] tinyint NULL,
    [EtniaId] tinyint NULL,
    [EscolaridadeId] tinyint NULL,
	[DataCadastro] datetime NOT NULL,
    CONSTRAINT [PK_Pessoa] PRIMARY KEY ([Id]), 
    CONSTRAINT [FK_tblPessoas_tblEtnias] FOREIGN KEY ([EtniaId]) REFERENCES [tblEtnias]([Id]),
    CONSTRAINT [FK_tblPessoas_tblGeneros] FOREIGN KEY ([GeneroId]) REFERENCES [tblGeneros]([Id]),
    CONSTRAINT [FK_tblPessoas_tblEscolaridades] FOREIGN KEY ([EscolaridadeId]) REFERENCES [tblEscolaridades]([Id])
);
GO


CREATE INDEX [NC_tblPessoas_Tipos] ON [dbo].[tblPessoas] ([GeneroId], [EtniaId], [EscolaridadeId])
