CREATE PROCEDURE [dbo].[SProc_Genero_GetById]  
(  
	@Id tinyint  
)  
As  
  
 SELECT 
		Id,
        Nome
 FROM	dbo.tblGeneros (nolock) 
 Where	Id = @Id  
 