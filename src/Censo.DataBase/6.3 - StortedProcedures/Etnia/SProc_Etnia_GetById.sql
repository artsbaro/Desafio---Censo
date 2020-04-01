CREATE PROCEDURE [dbo].[SProc_Etnia_GetById]  
(  
	@Id tinyint  
)  
As  
  
 SELECT 
		E.Id,
        E.Descricao
 FROM	dbo.tblEtnias E(nolock) 
 Where	E.Id = @Id  
 