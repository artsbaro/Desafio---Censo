CREATE PROCEDURE [dbo].[SProc_Escolaridade_GetById]  
(  
	@Id tinyint  
)  
As  
  
 SELECT 
		E.Id,
        E.Nome
 FROM	dbo.tblEscolaridades E(nolock) 
 Where	E.Id = @Id  
 