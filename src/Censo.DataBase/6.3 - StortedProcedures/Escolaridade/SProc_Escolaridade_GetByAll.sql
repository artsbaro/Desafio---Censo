CREATE PROCEDURE [dbo].[SProc_Escolaridade_GetByAll]  
As  
  
 SELECT 
		E.Id,
        E.Nome
 FROM	dbo.tblEscolaridades E(nolock) 
 Order by E.Nome