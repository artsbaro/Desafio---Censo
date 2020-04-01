CREATE PROCEDURE [dbo].[SProc_Genero_GetById]  
(  
	@Id tinyint  
)  
As  
  
 SELECT 
		Id,
        Descricao
 FROM	dbo.tblGeneros (nolock) 
 Where	Id = @Id  
 