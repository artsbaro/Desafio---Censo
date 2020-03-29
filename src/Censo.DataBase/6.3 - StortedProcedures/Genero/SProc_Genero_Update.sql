CREATE PROCEDURE SProc_Genero_Update
(
    @Id tinyint,
	@Nome varchar(128)
)
As


UPDATE  tblGeneros   SET 
        Nome	= @Nome
WHERE   Id = @Id