CREATE PROCEDURE [dbo].[SProc_Pessoa_GetByParentId]
(
	@idParent	uniqueidentifier
)
As

SELECT   
		P.[Id]   
		,P.[Nome]   
		,P.[SobreNome]   
		,P.Regiao
		,P.[MaeId]   
		,MAE.Nome as MaeNome  
		,P.[PaiId]   
		,PAI.Nome as PaiNome  
		,P.[GeneroId]   
		,P.[EtniaId]   
		,P.[EscolaridadeId]  
		,P.[DataCadastro]  
FROM    dbo.tblPessoas P (nolock)   
LEFT JOIN dbo.tblPessoas MAE (nolock) On MAE.Id = P.MaeId  
LEFT JOIN dbo.tblPessoas PAI (nolock) On PAI.Id = P.PaiId  
JOIN    dbo.tblGeneros G (nolock) On G.Id = P.GeneroId  
JOIN    dbo.tblEscolaridades E (nolock) On E.Id = P.EtniaId  
JOIN    dbo.tblEscolaridades ESC (nolock) On ESC.Id = P.EscolaridadeId  
WHERE	P.MaeId = @idParent OR P.PaiId = @idParent