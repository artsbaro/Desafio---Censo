Create Procedure SProc_Pessoa_GetPercentPersonWhitNameByRegion
(

	@Regiao varchar(100),
	@Nome varchar(100)  
)
As

declare @qtdeRegiao decimal(18,5)
declare @qtdeMesmoNomeRegiao decimal(18,5)
declare @razao decimal (18,5)

Select		@qtdeRegiao = Count(*)
From		tblPessoas (nolock)
Where		Regiao = @Regiao


Select		@qtdeMesmoNomeRegiao = COUNT(*)
from		tblPessoas (nolock)
Where		Regiao = @Regiao
And			Nome = @Nome
Group by	Nome
Having		COUNT(*) > 1

if(@qtdeMesmoNomeRegiao Is null)
	Set @qtdeMesmoNomeRegiao = 0

if(@qtdeRegiao Is null OR @qtdeRegiao = 0)		
Begin
	Set @razao = 0
End
Else
Begin
	Set @razao = (@qtdeMesmoNomeRegiao/@qtdeRegiao)
End

Select (@razao * 100) as Razao