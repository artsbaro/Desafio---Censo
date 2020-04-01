CREATE PROCEDURE SProc_Etnia_Update
(
    @Id tinyint,
	@Descricao varchar(128)
)
As


UPDATE  tblEtnias   SET 
        Descricao	= @Descricao
WHERE   Id = @Id