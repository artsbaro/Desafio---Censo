CREATE PROCEDURE SProc_Etnia_Insert
(
	@Descricao varchar(128)
)
As

INSERT INTO [dbo].[tblEtnias]
           (Descricao)
     VALUES
           (@Descricao )

Select Id = SCOPE_IDENTITY()