CREATE PROCEDURE SProc_Pessoa_Delete
(
	@Id uniqueidentifier
)
AS

	Delete 
	from	tblPessoas
	Where	Id = @Id