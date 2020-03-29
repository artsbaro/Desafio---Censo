CREATE TABLE [tblEtnias] (
    [Id] TINYINT identity(1,1) NOT NULL,
	[Nome] varchar(128) NOT NULL,
    CONSTRAINT [PK_Etnia] PRIMARY KEY ([Id]),
);