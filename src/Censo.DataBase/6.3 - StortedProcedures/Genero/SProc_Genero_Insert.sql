CREATE PROCEDURE SProc_Genero_Insert
(
    @Id tinyint,
	@Nome varchar(128)
)
As

INSERT INTO [dbo].[tblGeneros]
           (    [Id],
                [Nome])
     VALUES
           (    @Id,
				@Nome )