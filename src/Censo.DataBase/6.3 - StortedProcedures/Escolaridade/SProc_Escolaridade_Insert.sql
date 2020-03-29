CREATE PROCEDURE SProc_Escolaridade_Insert
(
    @Id tinyint,
	@Nome varchar(128)
)
As

INSERT INTO [dbo].[tblEscolaridades]
           (    [Id],
                [Nome])
     VALUES
           (    @Id,
				@Nome )