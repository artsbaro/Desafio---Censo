CREATE PROCEDURE [dbo].[SProc_Item_GetByAll]  
As  
  
 SELECT 
		E.Id,
        E.Nome
 FROM	dbo.tblEtnias E(nolock) 
 Order by E.Nome