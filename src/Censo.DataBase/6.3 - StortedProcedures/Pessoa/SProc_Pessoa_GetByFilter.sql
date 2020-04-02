CREATE PROCEDURE [dbo].[SProc_Pessoa_GetByFilter]
(
	@Nome			varchar(100),
	@SobreNome		varchar(100),
	@NomeDaMae		varchar(100),
	@NomeDoPai		varchar(100),
	@GeneroId		tinyint,
	@EtniaId		tinyint,
	@EscolaridadeId	tinyint
)
As

SELECT   
  P.[Id]   
  ,P.[Nome]   
  ,P.[SobreNome]   
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
WHERE (@Nome IS NULL OR P.Nome = @Nome  )
AND  (@SobreNome IS NULL OR P.SobreNome = @SobreNome  )
AND  (@NomeDaMae IS NULL OR MAE.Nome = @NomeDaMae  )
AND  (@NomeDoPai IS NULL OR PAI.Nome = @NomeDoPai  )
AND  (@GeneroId IS NULL OR P.GeneroId = @GeneroId  )
AND  (@EtniaId IS NULL OR P.EtniaId = @EtniaId  )
AND  (@EscolaridadeId IS NULL OR P.EscolaridadeId = @EscolaridadeId  )
--AND		@DataCadastro = @DataCadastro OR (P.DataCadastro = @DataCadastro)