﻿CREATE TABLE [tblEscolaridades] (
    [Id] TINYINT identity(1,1) NOT NULL,
	[Nome] varchar(128) NOT NULL,
    CONSTRAINT [PK_Escolaridade] PRIMARY KEY ([Id]),
);