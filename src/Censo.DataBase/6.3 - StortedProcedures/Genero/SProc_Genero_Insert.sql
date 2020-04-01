CREATE PROCEDURE SProc_Genero_Insert
(
	@Descricao varchar(128)
)
As

INSERT INTO [dbo].[tblGeneros]
           ([Descricao])
     VALUES
           (@Descricao )

Select Id = SCOPE_IDENTITY()