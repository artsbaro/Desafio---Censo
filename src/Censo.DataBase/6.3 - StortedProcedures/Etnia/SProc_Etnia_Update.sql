CREATE PROCEDURE SProc_Item_Update
(
    @Id tinyint,
	@Nome varchar(128)
)
As


UPDATE  tblEtnias   SET 
        Nome	= @Nome
WHERE   Id = @Id