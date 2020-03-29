CREATE PROCEDURE [dbo].[SProc_Genero_GetByAll]  
As  
  
 SELECT 
		Id,
        Nome
 FROM	dbo.tblGeneros (nolock) 
 Order by Nome