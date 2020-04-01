CREATE PROCEDURE SProc_Escolaridade_Insert
(
	@Descricao varchar(128)
)
As

INSERT INTO [dbo].[tblEscolaridades]
           (    Descricao)
     VALUES
           (    @Descricao )

Select Id = SCOPE_IDENTITY()