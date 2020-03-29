CREATE PROCEDURE SProc_Escolaridade_Update
(
    @Id tinyint,
	@Nome varchar(128)
)
As


UPDATE  tblEscolaridades   SET 
        Nome	= @Nome
WHERE   Id = @Id