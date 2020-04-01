CREATE PROCEDURE SProc_Escolaridade_Update
(
    @Id tinyint,
	@Descricao varchar(128)
)
As


UPDATE  tblEscolaridades   SET 
        Descricao	= @Descricao
WHERE   Id = @Id