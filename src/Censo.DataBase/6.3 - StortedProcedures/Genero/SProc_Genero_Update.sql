CREATE PROCEDURE SProc_Genero_Update
(
    @Id tinyint,
	@Descricao varchar(128)
)
As


UPDATE  tblGeneros   SET 
        Descricao = @Descricao
WHERE   Id = @Id