CREATE PROCEDURE SProc_Pessoa_Update
(
    @Id             uniqueidentifier ,
    @Nome           varchar(100)  ,
    @SobreNome      varchar(100) ,
    @Regiao         varchar(100) ,
    @MaeId          uniqueidentifier ,
    @PaiId          uniqueidentifier ,
    @GeneroId       tinyint ,
    @EtniaId        tinyint ,
    @EscolaridadeId tinyint 
)
As

Update  [dbo].[tblPessoas] SET
        [Nome]              = @Nome
        ,[SobreNome]        = @SobreNome
        ,Regiao             = @Regiao
        ,[MaeId]            = @MaeId
        ,[PaiId]            = @PaiId
        ,[GeneroId]         = @GeneroId
        ,[EtniaId]          = @EtniaId
        ,[EscolaridadeId]   = @EscolaridadeId
Where   [Id]                = @Id