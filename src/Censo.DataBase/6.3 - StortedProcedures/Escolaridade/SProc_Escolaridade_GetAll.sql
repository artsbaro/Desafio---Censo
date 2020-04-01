CREATE PROCEDURE [dbo].[SProc_Escolaridade_GetAll]  
As  
  
 SELECT 
		E.Id,
        E.Descricao
 FROM	dbo.tblEscolaridades E(nolock) 
 Order by E.Descricao