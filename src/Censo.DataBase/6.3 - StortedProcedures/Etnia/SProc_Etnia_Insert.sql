CREATE PROCEDURE SProc_Etnia_Insert
(
    @Id tinyint,
	@Nome varchar(128)
)
As

INSERT INTO [dbo].[tblEtnias]
           (    [Id],
                [Nome])
     VALUES
           (    @Id,
				@Nome )