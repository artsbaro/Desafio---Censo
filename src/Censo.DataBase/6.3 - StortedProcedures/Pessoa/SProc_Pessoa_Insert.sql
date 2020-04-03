CREATE PROCEDURE SProc_Pessoa_Insert
(
    @Id             uniqueidentifier ,
    @Nome           varchar(100)  ,
    @SobreNome      varchar(100) ,
    @Regiao         varchar(100) ,
    @MaeId          uniqueidentifier ,
    @PaiId          uniqueidentifier ,
    @GeneroId       tinyint ,
    @EtniaId        tinyint ,
    @EscolaridadeId tinyint ,
	@DataCadastro   datetime 
)
As

INSERT INTO [dbo].[tblPessoas]
           ( [Id] 
            ,[Nome] 
            ,[SobreNome] 
            ,Regiao
            ,[MaeId] 
            ,[PaiId] 
            ,[GeneroId]
            ,[EtniaId] 
            ,[EscolaridadeId]
            ,[DataCadastro] )
     VALUES
           ( @Id
            ,@Nome 
            ,@SobreNome 
            ,@Regiao
            ,@MaeId 
            ,@PaiId 
            ,@GeneroId
            ,@EtniaId 
            ,@EscolaridadeId
            ,@DataCadastro )

