CREATE PROCEDURE [dbo].[SProc_Genero_GetAll]  
As  
  
 SELECT 
		Id,
        Descricao
 FROM	dbo.tblGeneros (nolock) 
 Order by Descricao