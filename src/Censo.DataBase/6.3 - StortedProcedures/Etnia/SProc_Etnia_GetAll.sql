CREATE PROCEDURE [dbo].[SProc_Etnia_GetAll]  
As  
  
 SELECT 
		E.Id,
        E.Descricao
 FROM	dbo.tblEtnias E(nolock) 
 Order by E.Descricao